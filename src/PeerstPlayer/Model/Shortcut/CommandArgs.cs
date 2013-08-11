using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstPlayer.Model.Shortcut
{
	/// <summary>
	/// コマンド引数(引数無し)
	/// </summary>
	class CommandArgs
	{
		public CommandArgs()
		{
		}
	}

	/// <summary>
	/// ウィンドウサイズ指定コマンド引数
	/// </summary>
	class WindowSizeCommandArgs : CommandArgs
	{
		/// <summary>幅</summary>
		public int Width { get; private set; }
		/// <summary>高さ</summary>
		public int Height { get; private set; }

		/// <summary>
		/// 幅・高さを設定
		/// </summary>
		public WindowSizeCommandArgs(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}
	}

	/// <summary>
	/// 音量調節コマンド引数
	/// </summary>
	class VolumeControlCommandArgs : CommandArgs
	{
		/// <summary>音量</summary>
		public int Volume { get; private set; }

		/// <summary>
		/// 音量を設定
		/// </summary>
		public VolumeControlCommandArgs(int volume)
		{
			this.Volume = volume;
		}
	}
}
