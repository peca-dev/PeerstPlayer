﻿using PeerstLib.Bbs;
using PeerstLib.Util;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PeerstViewer.ThreadViewer.Command
{
	/// <summary>
	/// スレッド更新コマンド
	/// </summary>
	class UpdateThreadCommand : ICommand, INotifyPropertyChanged
	{
		/// <summary>
		/// ドキュメント
		/// </summary>
		public string DocumentText;

		/// <summary>
		/// プロパティ変更イベント
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		/// <summary>
		/// 掲示板操作
		/// </summary>
		private OperationBbs operationBbs;

		/// <summary>
		/// スレッド更新ワーカー
		/// </summary>
		private BackgroundWorker worker = new BackgroundWorker();

		/// <summary>
		/// スレッドドキュメント生成
		/// </summary>
		private ThreadDocumentGenerator threadDocumentGenerator = new ThreadDocumentGenerator("./skin");

		/// <summary>
		/// 前回のドキュメント
		/// </summary>
		private string beforeDocumentText = "";

		public UpdateThreadCommand(OperationBbs operationBbs)
		{
			this.operationBbs = operationBbs;

			// キャンセル可能
			worker.WorkerSupportsCancellation = true;
			worker.DoWork += (sender, e) => e.Result = UpdateDocumentText();
			worker.RunWorkerCompleted += (sender, e) =>
			{
				if ((e.Error != null) || e.Cancelled)
				{
					return;
				}

				DocumentText = e.Result as string;

				// 更新があった時だけ通知
				if (DocumentText != beforeDocumentText)
				{
					try
					{
						PropertyChanged(this, new PropertyChangedEventArgs("DocumentText"));
					}
					catch (Exception exception)
					{
						Logger.Instance.ErrorFormat("UpdateThreadCommandError : {0}", exception.Message);
					}
				}
				beforeDocumentText = DocumentText;
			};
		}

		/// <summary>
		/// コマンド実行
		/// </summary>
		public void Execute(object parameter)
		{
			string url = parameter as string;
			if (url != null)
			{
				operationBbs.ChangeUrl(url);
				operationBbs.ThreadListChange += (sender, e) =>
				{
					// スレッドURL変更＋更新
					if (!worker.IsBusy)
					{
						worker.CancelAsync();
						worker.RunWorkerAsync();
					}
				};
			}
			else
			{
				// 更新のみ
				if (!worker.IsBusy)
				{
					worker.RunWorkerAsync();
				}
			}
		}

		/// <summary>
		/// ドキュメント更新
		/// </summary>
		private string UpdateDocumentText()
		{
			int oldResNum = operationBbs.ResList.Count;
			operationBbs.ReadThread(false);
			return threadDocumentGenerator.Generate(operationBbs, oldResNum);
		}

		public event System.EventHandler CanExecuteChanged = delegate { };
		public bool CanExecute(object parameter)
		{
			return true;
		}

	}
}
