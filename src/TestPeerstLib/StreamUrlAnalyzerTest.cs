﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeerstLib.PeerCast;

namespace TestPeerstLib
{
	[TestClass]
	public class StreamUrlAnalyzerTest
	{
		[TestMethod]
		public void Test_StreamUrlAnalyzerTest_GetUrlInfo()
		{
			// ストリームURL情報が正しく取得できること
			// ホスト：localhost
			GetUrlInfoTest(
				"http://localhost:7144/pls/1234567890ABCDEFGHIJKLMNOPQRSTUV?tip=123.456.789.012:7144",
				"localhost",
				"7144",
				"1234567890ABCDEFGHIJKLMNOPQRSTUV"
				);

			// ホスト：IP
			GetUrlInfoTest(
				"http://127.0.0.1:7144/pls/1234567890ABCDEFGHIJKLMNOPQRSTUV?tip=123.456.789.012:7144",
				"127.0.0.1",
				"7144",
				"1234567890ABCDEFGHIJKLMNOPQRSTUV"
				);

			// ホスト：ドメイン
			GetUrlInfoTest(
				"http://shule517.ddo.jp:7144/pls/1234567890ABCDEFGHIJKLMNOPQRSTUV?tip=123.456.789.012:7144",
				"shule517.ddo.jp",
				"7144",
				"1234567890ABCDEFGHIJKLMNOPQRSTUV"
				);
		}

		// GetUrlInfoテスト用
		private static void GetUrlInfoTest(string streamUrl, string host, string portNo, string streamId)
		{
			StreamUrlInfo info = StreamUrlAnalyzer.GetUrlInfo(streamUrl);

			Assert.AreEqual(info.Host, host);
			Assert.AreEqual(info.PortNo, portNo);
			Assert.AreEqual(info.StreamId, streamId);
		}
	}
}
