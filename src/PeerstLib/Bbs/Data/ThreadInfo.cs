﻿
namespace PeerstLib.Bbs.Data
{
	//-------------------------------------------------------------
	// 概要：スレッド情報クラス
	//-------------------------------------------------------------
	public class ThreadInfo
	{
		//-------------------------------------------------------------
		// 公開プロパティ
		//-------------------------------------------------------------

		/// <summary>
		/// スレッド番号
		/// </summary>
		public string ThreadNo { get; set; }

		/// <summary>
		/// スレッドタイトル
		/// </summary>
		public string ThreadTitle { get; set; }

		/// <summary>
		/// レス数
		/// </summary>
		public int ResCount { get; set; }
	
		/// <summary>
		/// レス勢い
		/// </summary>
		public float ThreadSpeed { get; set; }

		/// <summary>
		/// スレッド作成からの経過日数
		/// </summary>
		public double ThreadSince { get; set; }

		/// <summary>
		/// スレッドストップ
		/// </summary>
		public bool IsStopThread { get { return ResCount >= MaxResCount; } }

		/// <summary>
		/// 最大レス数
		/// </summary>
		public int MaxResCount { get { return 1000; } } // TODO 掲示板情報から取得する
	}
}
