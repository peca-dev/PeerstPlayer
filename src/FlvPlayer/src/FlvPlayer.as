package  
{
	import flash.display.Stage;
	import flash.events.TimerEvent;
	import flash.events.Event;
	import flash.events.NetStatusEvent;
	import flash.media.Video;
	import flash.net.NetConnection;
	import flash.net.NetStream;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.media.SoundTransform;
	import flash.external.ExternalInterface;
	import flash.utils.Timer;
	
	/**
	 * FLV Player
	 * @author shule517
	 */
	public class FlvPlayer 
	{
		private var stage:Stage;
		private var video:Video = new Video();
		private var netStr:NetStream = null;
		private var streamUrl:String = null;
		
		// 前回の時刻など
		private var prevTime:Number = 0;
		private var prevBytesLoaded:uint = 0;
		private var prevBitrate:int = 0;
		
		// 再接続監視タイマー
		private var retryTimer:Timer = null;
		private var volume:String = null;
		private var retryPrevTime:Number = 0;
		
		public function FlvPlayer(stage:Stage)
		{
			this.stage = stage;
			
			// リサイズされたときに呼び出されるイベント
			stage.addEventListener(Event.RESIZE, function (e:Event):void{
				SizeChanged(stage.stageWidth, stage.stageHeight);
			});
			
			// 監視用タイマー
			retryTimer = new Timer(2000);
			retryTimer.addEventListener(TimerEvent.TIMER, retryTimerHandler);
		}
		
		private function Call(functionName:String, ...args):void
		{
			if (ExternalInterface.available)
			{
				ExternalInterface.call.apply(this, [functionName].concat(args));
			}
		}

		// 音量変更
		public function ChangeVolume(vol:String):void
		{
			if (netStr == null)
			{
				return;
			}
			
			this.volume = vol;
			var volume:Number = parseInt(vol);
			
			if (volume <= 0)
			{
				netStr.soundTransform = new SoundTransform(0);
			}
			else if (volume >= 100)
			{
				netStr.soundTransform = new SoundTransform(1);
			}
			else
			{
				netStr.soundTransform = new SoundTransform(volume / 100.0);
			}
		}
		
		// サイズ変更
		public function SizeChanged(width:int, height:int):void
		{
			var w:Number = stage.stageWidth / video.videoWidth;
			var h:Number = stage.stageHeight / video.videoHeight;

			// 横の方が長い
			if (w > h)
			{
				video.width = stage.stageHeight * video.videoWidth / video.videoHeight;
				video.height = stage.stageHeight;
			}
			// 縦の方が長い
			else
			{
				video.width = stage.stageWidth;
				video.height = stage.stageWidth * video.videoHeight / video.videoWidth;
			}
			video.x = stage.stageWidth / 2 - video.width / 2;
			video.y = stage.stageHeight / 2 - video.height / 2;
		}
		
		// 動画幅取得
		public function GetVideoWidth():String
		{
			return video.videoWidth.toString();
		}
		
		// 動画高さ取得
		public function GetVideoHeight():String
		{
			return video.videoHeight.toString();
		}
		
		// 再生時間取得
		public function GetDurationString():String
		{
			if (netStr == null)
			{
				return "00:00:00";
			}
			
			var sec:String = new String(Math.floor(netStr.time % 60));
			var min:String = new String(Math.floor(netStr.time /60 % 60));
			var hour:String = new String(int(netStr.time / 60 / 60));
			if (hour.length <= 1)
			{
				hour = "0" + hour;
			}
			return hour + ":" +
				("0" + min.toString()).slice(-2) + ":" +
				("0" + sec.toString()).slice(-2);
		}
		
		// FPS取得
		public function GetNowFrameRate():String
		{
			if (netStr == null)
			{
				return "0";
			}
			return int(netStr.currentFPS).toString();
		}
		
		// FPS取得
		public function GetFrameRate():String
		{
			if (netStr == null || netStr.info.metaData == null)
			{
				return "0";
			}
			return netStr.info.metaData["framerate"].toString();
		}
		
		// ビットレート取得
		public function GetNowBitRate():String
		{
			if (netStr == null)
			{
				return "0";
			}
			var diffBytes:uint = netStr.bytesLoaded - prevBytesLoaded;
			var diffTime:Number = netStr.time - prevTime;
			var bitrate:int = int(diffBytes / diffTime * 8 / 1000);
			// 0bpsになることが少なくないので、前回との平均を取ってみる
			var averageBitrate:String = String(Math.floor((bitrate + prevBitrate) / 2));
			prevBytesLoaded = netStr.bytesLoaded;
			prevTime = netStr.time;
			prevBitrate = bitrate;
			return averageBitrate;
		}
		
		// ビットレート取得
		public function GetBitRate():String
		{
			if (netStr == null || netStr.info.metaData == null)
			{
				return "0";
			}
			return String(netStr.info.metaData["audiodatarate"] + netStr.info.metaData["videodatarate"]);
		}

		// 動画再生
		public function PlayVideo(streamUrl:String):void
		{
			this.streamUrl = streamUrl;
			// プレイリストURLをコマンドライン引数から取得
			var playlistUrl:String = streamUrl;
			var urlRequest:URLRequest = new URLRequest(playlistUrl);
			var urlLoader:URLLoader = new URLLoader;
			
			// 動画に接続するための変数
			var netCon:NetConnection = new NetConnection;
			netCon.connect(null);
			netStr = new NetStream(netCon);
			// 非アクティブかつプレイヤーが他のウィンドウの裏に隠れている場合に
			// 短時間バッファが発生して再生が遅れていく現象が緩和できるかも
			netStr.bufferTime = 0.2;

			netStr.client = new Object;

			// メタ情報を取得した時の処理
			netStr.client.onMetaData = function(obj:Object):void
			{
				prevTime = netStr.time;
				prevBytesLoaded = netStr.bytesLoaded;
				prevBitrate = netStr.info.metaData["audiodatarate"] + netStr.info.metaData["videodatarate"];
				
				// 再接続時に音量が初期化されるので、一度変更済みであればここ変えておく
				if (volume != null) {
					ChangeVolume(volume);
				}
				
				Call("OpenStateChange");
			}
			
			urlLoader.addEventListener(Event.COMPLETE, function (event:Event):void
			{
				// ストリームURLを取得
				var streamUrl:String = urlLoader.data;

				// 動画を再生
				netStr.play(streamUrl);

				// Videoをステージサイズにする
				video.width = stage.stageWidth;
				video.height = stage.stageHeight;

				// smoothingを有効にする
				video.smoothing = true;

				// videoをステージに追加
				if (video.parent == null)
				{
					stage.addChild(video);
				}

				video.attachNetStream(netStr);
				video.visible = true;
			});
			urlLoader.load(urlRequest);
			netStr.addEventListener(NetStatusEvent.NET_STATUS, netStatusHandler);
			
			if (!retryTimer.running)
			{
				retryTimer.start();
			}
		}
		
		// ネットステータス
		private function netStatusHandler(event:NetStatusEvent):void
		{
			switch (event.info.code)
			{
				case "NetStream.Buffer.Full":
					break;
				case "NetStream.Buffer.Empty":
					break;
				case "NetStream.Buffer.Flush":
					break;
				case "NetStream.Play.Start":
					break;
				case "NetStream.Play.Stop":
					break;
				case "NetStream.Play.StreamNotFound":
					break;
			}
		}
		
		// タイマー
		private function retryTimerHandler(event:TimerEvent):void
		{
			// NetStream.Buffer.Empty発動時からタイムが進んでいなければリコネクト
			if (retryPrevTime == netStr.time)
			{
				netStr.close();
				PlayVideo(streamUrl);
			}
			else
			{
				retryPrevTime = netStr.time;
			}
		}
	}
}