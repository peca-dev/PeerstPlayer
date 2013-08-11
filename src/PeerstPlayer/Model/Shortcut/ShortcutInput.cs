using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstPlayer.Model.Shortcut
{
	/// <summary>
	/// ショートカット入力情報クラス
	/// </summary>
	class ShortcutInput
	{
		/// <summary>イベント</summary>
		public ShortcutEvents ShortcutEvent { get; private set; }

		/// <summary>修飾キー</summary>
		public ModifierKeys ModifierKey { get; private set; }

		/// <summary>
		/// 修飾キー + イベントを設定
		/// </summary>
		public ShortcutInput(ShortcutEvents shortcutEvent, ModifierKeys modifier)
		{
			this.ShortcutEvent = shortcutEvent;
			this.ModifierKey = modifier;
		}

		/// <summary>
		/// イベントを設定
		/// </summary>
		public ShortcutInput(ShortcutEvents shortcutEvent)
			: this(shortcutEvent, (short)ModifierKeys.None)
		{
		}
	}
}
