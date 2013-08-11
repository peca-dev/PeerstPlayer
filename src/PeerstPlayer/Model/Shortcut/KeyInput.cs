using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeerstPlayer.Model.Shortcut
{
	/// <summary>
	/// キー入力情報クラス
	/// </summary>
	class KeyInput
	{
		/// <summary>入力キー</summary>
		public Keys Key { get; private set; }

		/// <summary>修飾キー</summary>
		public ModifierKeys ModifierKey { get; private set; }

		/// <summary>
		/// 修飾キー + 入力キーを設定
		/// </summary>
		public KeyInput(Keys key, ModifierKeys modifier)
		{
			Key = key;
			ModifierKey = modifier;
		}

		/// <summary>
		/// 入力キーを設定
		/// </summary>
		public KeyInput(Keys key)
			: this(key, (short)ModifierKeys.None)
		{
		}
	}

	/// <summary>
	/// 修飾キー
	/// </summary>
	enum ModifierKeys : short
	{
		None	= 0,
		Shift	= 1 << 0,
		Contrl	= 1 << 1,
		Alt		= 1 << 2
	};
}
