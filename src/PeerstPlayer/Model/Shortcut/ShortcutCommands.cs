using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstPlayer.Model.Shortcut
{
	class ShortcutCommand
	{
		/// <summary>コマンド</summary>
		public Commands Command { get; set; }
		/// <summary>引数</summary>
		public CommandArgs Args { get; set; }
		/*
		// TODO 詳細を返すメソッドを指定
		/// <summary>コマンドの詳細(マウスジェスチャー時に表示)</summary>
		public Func Detail { get; set; }
		 */

		/// <summary>コマンド、パラメータの設定</summary>
		public ShortcutCommand(Commands command, CommandArgs args/*, Func detail*/)
		{
			this.Command = command;
			this.Args = args;
		}

		/// <summary>コマンドの設定</summary>
		public ShortcutCommand(Commands command/*, Func detail*/)
			: this(command, new CommandArgs()/*, detail*/)
		{
		}
	};

	// コマンド種類
	public enum Commands
	{
		[CommandDetail("音量UP")]
		VolumeUp,			// 音量Up
		[CommandDetail("音量DOWN")]
		VolumeDown,			// 音量Down
		[CommandDetail("ミュート切り替え")]
		Mute,				// ミュート切り替え
		[CommandDetail("ウィンドウ最大化")]
		WindowMaximize,		// ウィンドウ最大化
		[CommandDetail("ウィンドウ最小化")]
		WindowMinimization,	// ウィンドウ最小化
		[CommandDetail("最小化ミュート")]
		MiniMute,			// 最小化ミュート
		[CommandDetail("閉じる")]
		Close,				// 閉じる
		[CommandDetail("ビューワを開く")]
		OpenPeerstViewer,	// ビューワを開く
		[CommandDetail("ステータスバーの表示切り替え")]
		VisibleStatusBar,	// ステータスバーの表示切り替え
		[CommandDetail("チャンネル情報更新")]
		UpdateChannelInfo,	// チャンネル情報更新
		[CommandDetail("新着レス表示")]
		ShowNewRes,			// 新着レス表示
		[CommandDetail("最前列表示切り替え")]
		TopMost,			// 最前列表示切り替え
		[CommandDetail("ウィンドウサイズ指定")]
		WindowSize,			// ウィンドウサイズ指定
		[CommandDetail("ウィンドウ拡大率")]
		WindowSizeScale,	// ウィンドウ拡大率
		[CommandDetail("画面分割(幅×高さ)")]
		ScreenSplit,		// 画面分割(幅×高さ)
		[CommandDetail("画面分割(幅)")]
		ScreenSplitWidth,	// 画面分割(幅)
		[CommandDetail("画面分割(高さ)")]
		ScreenSplitHeight,	// 画面分割(高さ)
	};
}
