﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PeerstLib.Util;
using PeerstPlayer.Controls.PecaPlayer;
using PeerstPlayer.Controls.StatusBar;
using PeerstPlayer.Forms.Setting;
using PeerstPlayer.Shortcut.Command;

namespace PeerstPlayer.Shortcut
{
	//-------------------------------------------------------------
	// 概要：ショートカットコマンドクラス
	//-------------------------------------------------------------
	class ShortcutManager
	{
		//-------------------------------------------------------------
		// 非公開プロパティ
		//-------------------------------------------------------------

		// コマンドMap (コマンドID -> コマンドクラスを取得)
		private Dictionary<ShortcutCommands, IShortcutCommand> commandMap = new Dictionary<ShortcutCommands, IShortcutCommand>();

		// イベントMap (イベントID -> コマンドIDを取得)
		private Dictionary<ShortcutEvents, ShortcutCommands> eventMap = new Dictionary<ShortcutEvents, ShortcutCommands>();

		// マウスジェスチャーMap (ジェスチャー -> コマンドIDを取得)
		private Dictionary<string, ShortcutCommands> gestureMap = new Dictionary<string, ShortcutCommands>();

		// キー入力Map (キー入力 -> コマンドIDを取得)
		private Dictionary<Keys, ShortcutCommands> keyMap = new Dictionary<Keys, ShortcutCommands>();

		//-------------------------------------------------------------
		// 概要：初期化
		//-------------------------------------------------------------
		public void Init(PlayerView playerView, PecaPlayerControl pecaPlayer, StatusBarControl statusBar)
		{
			CreateCommand(playerView, pecaPlayer, statusBar);

			// キー設定
			SettingEvent();
			SettingGesture();
			SettingKey();
		}

		//-------------------------------------------------------------
		// 概要：イベント実行
		//-------------------------------------------------------------
		public void RaiseEvent(ShortcutEvents eventId)
		{
			Logger.Instance.InfoFormat("イベント実行 [イベントID:{0}]", eventId);
			ShortcutCommands commandId;
			if (eventMap.TryGetValue(eventId, out commandId))
			{
				ExecCommand(commandId);
			}
			else
			{
				Logger.Instance.ErrorFormat("イベントに紐付くコマンドがありません [eventid : {0}]", eventId);
			}
		}

		//-------------------------------------------------------------
		// 概要：キー押下イベント実行
		//-------------------------------------------------------------
		public void RaiseKeyEvent(AxWMPLib._WMPOCXEvents_KeyDownEvent e)
		{
			// 入力値をKeysへ変換
			Keys keyCode = (Keys)e.nKeyCode;
			Keys modifierKey = (Keys)(e.nShiftState << 16);
			Keys key = keyCode | modifierKey;

			Logger.Instance.InfoFormat("キー押下イベント実行 [イベントID:{0}, keyCode{0}, modifierKey{1}]", keyCode, modifierKey);

			// コマンド実行
			ShortcutCommands command;
			if (keyMap.TryGetValue(key, out command))
			{
				ExecCommand(command);
			}
		}

		//-------------------------------------------------------------
		// 概要：マウスジェスチャー実行
		//-------------------------------------------------------------
		public void ExecGesture(string gesture)
		{
			ShortcutCommands commandId;
			if (gestureMap.TryGetValue(gesture, out commandId))
			{
				Logger.Instance.InfoFormat("マウスジェスチャー実行 [ジェスチャー:{0}, コマンドID:{1}]", gesture, commandId);
				ExecCommand(commandId);
			}
		}

		//-------------------------------------------------------------
		// 概要：ジェスチャーの詳細を取得
		//-------------------------------------------------------------
		public string GetGestureDetail(string gesture)
		{
			ShortcutCommands commandId;
			if (gestureMap.TryGetValue(gesture, out commandId))
			{
				return commandMap[commandId].Detail;
			}

			return String.Empty;
		}

		//-------------------------------------------------------------
		// 概要：コマンド実行
		//-------------------------------------------------------------
		private void ExecCommand(ShortcutCommands commandId)
		{
			Logger.Instance.InfoFormat("コマンド実行 [コマンドID:{0}]", commandId);
			commandMap[commandId].Execute();
		}

		//-------------------------------------------------------------
		// 概要：コマンド作成
		//-------------------------------------------------------------
		private void CreateCommand(Form form, PecaPlayerControl pecaPlayer, StatusBarControl statusBar)
		{
			commandMap = new Dictionary<ShortcutCommands, IShortcutCommand>()
			{
				{	ShortcutCommands.VolumeUp,			new VolumeUpCommand(pecaPlayer)					}, // 音量UP
				{	ShortcutCommands.VolumeDown,		new VolumeDownCommand(pecaPlayer)				}, // 音量DOWN
				{	ShortcutCommands.Mute,				new MuteCommand(pecaPlayer)						}, // ミュート切替
				{	ShortcutCommands.WindowMinimize,	new WindowMinimize(form)						}, // ウィンドウを最小化
				{	ShortcutCommands.WindowMaximize,	new WindowMaximize(form)						}, // ウィンドウを最大化
				{	ShortcutCommands.MiniMute,			new MiniMuteCommand(form, pecaPlayer)			}, // 最小化ミュート
				{	ShortcutCommands.Close,				new CloseCommand(form, pecaPlayer)				}, // 閉じる
				{	ShortcutCommands.VisibleStatusBar,	new VisibleStatusBarCommand(form, statusBar)	}, // ステータスバーの表示切り替え
				{	ShortcutCommands.OpenPeerstViewer,	new OpenPeerstViewerCommand(statusBar)			}, // PeerstViewerを開く
				{	ShortcutCommands.UpdateChannelInfo,	new UpdateChannelInfoCommand(pecaPlayer)		}, // チャンネル情報更新
				{	ShortcutCommands.ShowNewRes,		new ShowNewResCommand()							}, // 新着レス表示
				{	ShortcutCommands.TopMost,			new TopMostCommand(form)						}, // 最前列表示切り替え
				{	ShortcutCommands.WindowSizeUp,		new WindowSizeUpCommand(form, pecaPlayer)		}, // ウィンドウサイズUP
				{	ShortcutCommands.WindowSizeDown,	new WindowSizeDownCommand(form, pecaPlayer)		}, // ウィンドウサイズDOWN
				{	ShortcutCommands.DisconnectRelay,	new DisconnectRelayCommand(form, pecaPlayer)	}, // リレー切断
				{	ShortcutCommands.Bump,				new BumpCommand(pecaPlayer)						}, // Bump
				{	ShortcutCommands.WindowSize,		new WindowSizeCommand(form, pecaPlayer)			}, // ウィンドウサイズ指定
				{	ShortcutCommands.WindowScale,		new WindowScaleCommand(form, pecaPlayer)		}, // ウィンドウサイズ拡大率指定
				// TODO 画面分割		{	ShortcutCommands.ScreenSplit,	new ScreenSplitWidthCommand(form, pecaPlayer)	}, // 画面分割
				// TODO 動画にフィット	{	ShortcutCommands.FitMovieSize,	new FitMovieSizeCommand(form, pecaPlayer)		}, // 黒枠を消す
			};
		}

		//-------------------------------------------------------------
		// 概要：イベントの設定
		//-------------------------------------------------------------
		private void SettingEvent()
		{
			// TODO 設定によって切り替えを行う
			eventMap.Add(ShortcutEvents.WheelUp,				ShortcutCommands.VolumeUp);
			eventMap.Add(ShortcutEvents.WheelDown,				ShortcutCommands.VolumeDown);
			eventMap.Add(ShortcutEvents.MiddleClick,			ShortcutCommands.MiniMute);
			eventMap.Add(ShortcutEvents.Mute,					ShortcutCommands.Mute);
			eventMap.Add(ShortcutEvents.DoubleClick,			ShortcutCommands.WindowMaximize);
			eventMap.Add(ShortcutEvents.StatusbarRightClick,	ShortcutCommands.OpenPeerstViewer);
			eventMap.Add(ShortcutEvents.StatusbarLeftClick,		ShortcutCommands.VisibleStatusBar);
			eventMap.Add(ShortcutEvents.MinButtonClick,			ShortcutCommands.WindowMinimize);
			eventMap.Add(ShortcutEvents.MaxButtonClick,			ShortcutCommands.WindowMaximize);
			eventMap.Add(ShortcutEvents.CloseButtonClick,		ShortcutCommands.Close);
			eventMap.Add(ShortcutEvents.ThreadTitleRightClick,	ShortcutCommands.OpenPeerstViewer);
			eventMap.Add(ShortcutEvents.StatusbarHover,			ShortcutCommands.ShowNewRes);
			eventMap.Add(ShortcutEvents.RightClickWheelUp,		ShortcutCommands.WindowSizeDown);
			eventMap.Add(ShortcutEvents.RightClickWheelDown,	ShortcutCommands.WindowSizeUp);
		}

		//-------------------------------------------------------------
		// 概要：マウスジェスチャーの設定
		//-------------------------------------------------------------
		private void SettingGesture()
		{
			// TODO 設定によって切り替えを行う
			gestureMap.Add("↓→",	ShortcutCommands.Close);
			gestureMap.Add("↓",	ShortcutCommands.OpenPeerstViewer);
			gestureMap.Add("↓↑",	ShortcutCommands.UpdateChannelInfo);
			gestureMap.Add("↑",	ShortcutCommands.Bump);
		}

		//-------------------------------------------------------------
		// 概要：キー入力の設定
		//-------------------------------------------------------------
		private void SettingKey()
		{
			// TODO 設定によって切り替えを行う
			keyMap.Add(Keys.T,				ShortcutCommands.TopMost);
			keyMap.Add(Keys.Alt | Keys.B,	ShortcutCommands.Bump);
			keyMap.Add(Keys.Alt | Keys.X,	ShortcutCommands.DisconnectRelay);
			keyMap.Add(Keys.Up,				ShortcutCommands.VolumeUp);
			keyMap.Add(Keys.Down,			ShortcutCommands.VolumeDown);
			keyMap.Add(Keys.Delete,			ShortcutCommands.Mute);
			keyMap.Add(Keys.Enter,			ShortcutCommands.VisibleStatusBar);
			keyMap.Add(Keys.Escape,			ShortcutCommands.Close);
			keyMap.Add(Keys.D1,				ShortcutCommands.WindowScale);
			keyMap.Add(Keys.Alt | Keys.D1,	ShortcutCommands.WindowSize);
		}
	}
}