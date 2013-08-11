using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeerstLib.Utility;
using PeerstPlayer.Control;

namespace PeerstPlayer.Model.Shortcut
{
	//-------------------------------------------------------------
	// 概要：ショートカットコマンドクラス
	//-------------------------------------------------------------
	class ShortcutManager
	{
		//-------------------------------------------------------------
		// 非公開プロパティ
		//-------------------------------------------------------------

		// コマンドMap (コマンド -> 実行処理を取得)
		private Dictionary<Commands, Action<CommandArgs>> commandMap = new Dictionary<Commands, Action<CommandArgs>>();

		// イベントMap (イベント -> コマンドを取得)
		//private Dictionary<ShortcutInput, ShortcutCommand> eventMap = new Dictionary<ShortcutInput, ShortcutCommand>();
		private Dictionary<ShortcutEvents, Dictionary<Keys, ShortcutCommand>> eventMap = new Dictionary<ShortcutEvents, Dictionary<Keys, ShortcutCommand>>();

		// KeyMap (キー入力 -> コマンドを取得)
		private Dictionary<KeyInput, ShortcutCommand> keyMap = new Dictionary<KeyInput, ShortcutCommand>();

		// マウスジェスチャーMap (ジェスチャー -> コマンドを取得)
		private Dictionary<string, ShortcutCommand> gestureMap = new Dictionary<string, ShortcutCommand>();

		//-------------------------------------------------------------
		// 概要：初期化
		//-------------------------------------------------------------
		public void Init(PlayerView playerView, PecaPlayer pecaPlayer, Control.StatusBar statusBar)
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
		public void RaiseEvent(ShortcutEvents shortcutEvent)
		{
			Logger.Instance.InfoFormat("イベント実行 [イベント:{0}]", shortcutEvent);

			Keys keys = System.Windows.Forms.Control.ModifierKeys;

			try
			{
				ShortcutCommand command = eventMap[shortcutEvent][keys];
				ExecCommand(command);
			}
			catch
			{
				Logger.Instance.InfoFormat("イベント実行 [イベント:{0}] 登録されたコマンドはありません", shortcutEvent);
			}
			/*
			foreach (KeyValuePair<ShortcutInput, ShortcutCommand> data in eventMap)
			{
				ShortcutInput input = data.Key;
				ShortcutCommand command = data.Value;

				// (修飾キー + キー)が一致しているか
				if ((shortcutEvent == input.ShortcutEvent)
					// &&
					// (e.nShiftState == (short)input.ModifierKey)
					)
				{
					ExecCommand(command);
				}
			}
			 */
		}

		//-------------------------------------------------------------
		// 概要：キー押下イベント実行
		//-------------------------------------------------------------
		internal void RaiseKeyEvent(AxWMPLib._WMPOCXEvents_KeyDownEvent e)
		{
			// TODO ログの修正
			Logger.Instance.InfoFormat("キー押下イベント実行 [Keys:{0}]", ((Keys)e.nKeyCode).ToString());
			foreach (KeyValuePair<KeyInput, ShortcutCommand> data in keyMap)
			{
				KeyInput input = data.Key;
				ShortcutCommand command = data.Value;

				// (修飾キー + キー)が一致しているか
				if ((e.nKeyCode == (short)input.Key) &&
					(e.nShiftState == (short)input.ModifierKey))
				{
					ExecCommand(command);
				}
			}
		}

		//-------------------------------------------------------------
		// 概要：マウスジェスチャー実行
		//-------------------------------------------------------------
		public void ExecGesture(string gesture)
		{
			ShortcutCommand command;
			if (gestureMap.TryGetValue(gesture, out command))
			{
				Logger.Instance.InfoFormat("マウスジェスチャー実行 [ジェスチャー:{0}, コマンドID:{1}]", gesture, command.Command);
				ExecCommand(command);
			}
		}

		//-------------------------------------------------------------
		// 概要：ジェスチャーの詳細を取得
		//-------------------------------------------------------------
		public string GetGestureDetail(string gesture)
		{
			ShortcutCommand command;
			if (gestureMap.TryGetValue(gesture, out command))
			{
				// TODO ShorcutCommands.Funcを実行し、詳細を取得する
				return CommandDetailUtiliy.ToAliasName(command.Command);
			}

			return String.Empty;
		}

		//-------------------------------------------------------------
		// 概要：イベントの設定
		//-------------------------------------------------------------
		private void SettingEvent()
		{
			// TODO 設定によって切り替えを行う

			eventMap[ShortcutEvents.WheelUp] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.WheelDown] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.WheelUp] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.WheelDown] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.WheelUp] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.WheelDown] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.MiddleClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.Mute] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.DoubleClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.StatusbarRightClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.StatusbarLeftClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.MinButtonClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.MaxButtonClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.CloseButtonClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.ThreadTitleRightClick] = new Dictionary<Keys, ShortcutCommand>();
			eventMap[ShortcutEvents.StatusbarHover] = new Dictionary<Keys, ShortcutCommand>();

			eventMap[ShortcutEvents.WheelUp][Keys.None] = new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(10));
			eventMap[ShortcutEvents.WheelDown][Keys.None]				= new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(10));
			eventMap[ShortcutEvents.WheelUp][Keys.Control]				= new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(5));
			eventMap[ShortcutEvents.WheelDown][Keys.Control]				= new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(5));
			eventMap[ShortcutEvents.WheelUp][Keys.Shift]				= new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(1));
			eventMap[ShortcutEvents.WheelDown][Keys.Shift]				= new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(1));
			eventMap[ShortcutEvents.MiddleClick][Keys.None]				= new ShortcutCommand(Commands.MiniMute);
			eventMap[ShortcutEvents.Mute][Keys.None]					= new ShortcutCommand(Commands.Mute);
			eventMap[ShortcutEvents.DoubleClick][Keys.None]				= new ShortcutCommand(Commands.WindowMaximize);
			eventMap[ShortcutEvents.StatusbarRightClick][Keys.None]		= new ShortcutCommand(Commands.OpenPeerstViewer);
			eventMap[ShortcutEvents.StatusbarLeftClick][Keys.None]		= new ShortcutCommand(Commands.VisibleStatusBar);
			eventMap[ShortcutEvents.MinButtonClick][Keys.None]			= new ShortcutCommand(Commands.WindowMinimization);
			eventMap[ShortcutEvents.MaxButtonClick][Keys.None]			= new ShortcutCommand(Commands.WindowMaximize);
			eventMap[ShortcutEvents.CloseButtonClick][Keys.None]		= new ShortcutCommand(Commands.Close);
			eventMap[ShortcutEvents.ThreadTitleRightClick][Keys.None]	= new ShortcutCommand(Commands.OpenPeerstViewer);
			eventMap[ShortcutEvents.StatusbarHover]	[Keys.None]			= new ShortcutCommand(Commands.ShowNewRes);
			/*
			eventMap.Add(ShortcutEvents.WheelUp),							new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(10)));
			eventMap.Add(ShortcutEvents.WheelDown),						new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(10)));
			eventMap.Add(ShortcutEvents.WheelUp, ModifierKeys.Contrl),	new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(5)));
			eventMap.Add(ShortcutEvents.WheelDown, ModifierKeys.Contrl),	new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(5)));
			eventMap.Add(ShortcutEvents.WheelUp, ModifierKeys.Shift),		new ShortcutCommand(Commands.VolumeUp, new VolumeControlCommandArgs(1)));
			eventMap.Add(ShortcutEvents.WheelDown, ModifierKeys.Shift),	new ShortcutCommand(Commands.VolumeDown, new VolumeControlCommandArgs(1)));
			eventMap.Add(ShortcutEvents.MiddleClick),						new ShortcutCommand(Commands.MiniMute));
			eventMap.Add(ShortcutEvents.Mute),							new ShortcutCommand(Commands.Mute));
			eventMap.Add(ShortcutEvents.DoubleClick),						new ShortcutCommand(Commands.WindowMaximize));
			eventMap.Add(ShortcutEvents.StatusbarRightClick),				new ShortcutCommand(Commands.OpenPeerstViewer));
			eventMap.Add(ShortcutEvents.StatusbarLeftClick),				new ShortcutCommand(Commands.VisibleStatusBar));
			eventMap.Add(ShortcutEvents.MinButtonClick),					new ShortcutCommand(Commands.WindowMinimization));
			eventMap.Add(ShortcutEvents.MaxButtonClick),					new ShortcutCommand(Commands.WindowMaximize));
			eventMap.Add(ShortcutEvents.CloseButtonClick),				new ShortcutCommand(Commands.Close));
			eventMap.Add(ShortcutEvents.ThreadTitleRightClick),			new ShortcutCommand(Commands.OpenPeerstViewer));
			eventMap.Add(ShortcutEvents.StatusbarHover),					new ShortcutCommand(Commands.ShowNewRes));
			 */
		}

		//-------------------------------------------------------------
		// 概要：マウスジェスチャーの設定
		//-------------------------------------------------------------
		private void SettingGesture()
		{
			// TODO 設定によって切り替えを行う
			gestureMap.Add("↓→",	new ShortcutCommand(Commands.Close));
			gestureMap.Add("↓",	new ShortcutCommand(Commands.OpenPeerstViewer));
			gestureMap.Add("↓↑",	new ShortcutCommand(Commands.UpdateChannelInfo));
		}

		//-------------------------------------------------------------
		// 概要：キー入力の設定
		//-------------------------------------------------------------
		private void SettingKey()
		{
			// TODO 設定によって切り替えを行う
			keyMap.Add(new KeyInput(Keys.T),		new ShortcutCommand(Commands.TopMost));
			keyMap.Add(new KeyInput(Keys.D1),		new ShortcutCommand(Commands.WindowSize, new WindowSizeCommandArgs(160, 120)));
			keyMap.Add(new KeyInput(Keys.D2),		new ShortcutCommand(Commands.WindowSize, new WindowSizeCommandArgs(320, 240)));
			keyMap.Add(new KeyInput(Keys.D3),		new ShortcutCommand(Commands.WindowSize, new WindowSizeCommandArgs(480, 360)));
			keyMap.Add(new KeyInput(Keys.D4),		new ShortcutCommand(Commands.WindowSize, new WindowSizeCommandArgs(640, 480)));
			keyMap.Add(new KeyInput(Keys.D5),		new ShortcutCommand(Commands.WindowSize, new WindowSizeCommandArgs(800, 600)));
			keyMap.Add(new KeyInput(Keys.Escape),	new ShortcutCommand(Commands.Close));

			keyMap.Add(new KeyInput(Keys.A),						new ShortcutCommand(Commands.VolumeUp,		new VolumeControlCommandArgs(10)));
			keyMap.Add(new KeyInput(Keys.S),						new ShortcutCommand(Commands.VolumeDown,	new VolumeControlCommandArgs(10)));
			keyMap.Add(new KeyInput(Keys.A, ModifierKeys.Shift),	new ShortcutCommand(Commands.VolumeUp,		new VolumeControlCommandArgs(1)));
			keyMap.Add(new KeyInput(Keys.S, ModifierKeys.Shift),	new ShortcutCommand(Commands.VolumeDown,	new VolumeControlCommandArgs(1)));
			keyMap.Add(new KeyInput(Keys.A, ModifierKeys.Contrl),	new ShortcutCommand(Commands.VolumeUp,		new VolumeControlCommandArgs(5)));
			keyMap.Add(new KeyInput(Keys.S, ModifierKeys.Contrl),	new ShortcutCommand(Commands.VolumeDown,	new VolumeControlCommandArgs(5)));
			// TODO DEBUG END
		}

		//-------------------------------------------------------------
		// 概要：コマンド作成
		//-------------------------------------------------------------
		private void CreateCommand(Form form, PecaPlayer pecaPlayer, PeerstPlayer.Control.StatusBar statusBar)
		{
			// 音量UP
			commandMap.Add(Commands.VolumeUp, (CommandArgs args) =>
			{
				VolumeControlCommandArgs volume = (VolumeControlCommandArgs)args;
				pecaPlayer.Volume += volume.Volume;
			});
			// 音量UP
			commandMap.Add(Commands.VolumeDown, (CommandArgs args) =>
			{
				VolumeControlCommandArgs volume = (VolumeControlCommandArgs)args;
				pecaPlayer.Volume -= volume.Volume;
			});
			// ミュート切替
			commandMap.Add(Commands.Mute, (CommandArgs args) => pecaPlayer.Mute = !pecaPlayer.Mute);
			// ウィンドウを最小化
			commandMap.Add(Commands.WindowMinimization, (CommandArgs args) => form.WindowState = FormWindowState.Minimized);
			// ウィンドウを最大化
			commandMap.Add(Commands.WindowMaximize, (CommandArgs args) =>
			{
				if (form.WindowState == FormWindowState.Normal)
				{
					form.WindowState = FormWindowState.Maximized;
				}
				else
				{
					form.WindowState = FormWindowState.Normal;
				}
			});
			// 最小化ミュート
			commandMap.Add(Commands.MiniMute, (CommandArgs args) =>
			{
				pecaPlayer.Mute = true;
				form.WindowState = FormWindowState.Minimized;
			});
			// 閉じる
			commandMap.Add(Commands.Close, (CommandArgs args) =>
			{
				Application.Exit();
			});
			// ステータスバーの表示切り替え
			commandMap.Add(Commands.VisibleStatusBar, (CommandArgs args) =>
			{
				// ウィンドウ最大化時は一度通常に戻す
				if (form.WindowState == FormWindowState.Maximized)
				{
					form.WindowState = FormWindowState.Normal;
					statusBar.WriteFieldVisible = !statusBar.WriteFieldVisible;
					form.WindowState = FormWindowState.Maximized;
				}
				else
				{
					statusBar.WriteFieldVisible = !statusBar.WriteFieldVisible;
				}

				// ステータスバーにフォーカス
				if (statusBar.WriteFieldVisible)
				{
					statusBar.Focus();
				}
			});
			// PeerstViewerを開く
			commandMap.Add(Commands.OpenPeerstViewer, (CommandArgs args) =>
			{
				// スレッド選択しているスレッドURLを開く
				string viewerExePath = Path.Combine(Environment.CurrentDirectory, "PeerstViewer.exe");
				string param = statusBar.SelectThreadUrl;
				Logger.Instance.InfoFormat("PeerstViewer起動 [viewerExePath:{0} param:{1}]", viewerExePath, param);
				Process.Start(viewerExePath, param);
			});
			// チャンネル情報更新
			commandMap.Add(Commands.UpdateChannelInfo, (CommandArgs args) =>
			{
				pecaPlayer.UpdateChannelInfo();
			});
			// 新着レス表示
			commandMap.Add(Commands.ShowNewRes, (CommandArgs args) =>
			{
				// TODO 新着レス表示の実装
			});
			// 最前列表示切り替え
			commandMap.Add(Commands.TopMost, (CommandArgs args) =>
			{
				form.TopMost = !form.TopMost;
			});
			// ウィンドウサイズ指定
			commandMap.Add(Commands.WindowSize, (CommandArgs args) =>
			{
				WindowSizeCommandArgs windowSize = (WindowSizeCommandArgs)args;
				form.Width = windowSize.Width;
				form.Height = windowSize.Height;
			});
		}

		//-------------------------------------------------------------
		// 概要：コマンド実行
		//-------------------------------------------------------------
		private void ExecCommand(ShortcutCommand command)
		{
			Logger.Instance.InfoFormat("コマンド実行 [コマンドID:{0}]", command.Command);
			commandMap[command.Command](command.Args);
		}
	}
}
