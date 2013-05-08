﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstLib.Control
{
	public class FormUtility
	{
		//-------------------------------------------------------------
		// 概要：ウィンドウドラッグ開始
		// 詳細：タイトルバーをクリックしたことにする
		//-------------------------------------------------------------
		public static void WindowDragStart(IntPtr handle)
		{
			Win32API.SendMessage(handle, (int)WindowMessage.WM_NCLBUTTONDOWN, new IntPtr((int)HitTest.Caption), new IntPtr(0));
		}
	}
}