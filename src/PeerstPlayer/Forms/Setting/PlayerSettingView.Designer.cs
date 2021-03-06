﻿using PeerstLib.Controls;
namespace PeerstPlayer.Forms.Setting
{
	partial class PlayerSettingView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerSettingView));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.settingPage = new System.Windows.Forms.TabPage();
			this.volumeChangeGroupBox = new System.Windows.Forms.GroupBox();
			this.volumeChangeNoneLabel = new System.Windows.Forms.Label();
			this.volumeChangeShiftLabel = new System.Windows.Forms.Label();
			this.volumeChangeCtrlLabel = new System.Windows.Forms.Label();
			this.volumeChangeCtrlTextBox = new System.Windows.Forms.TextBox();
			this.volumeChangeNoneTextBox = new System.Windows.Forms.TextBox();
			this.volumeChangeShiftTextBox = new System.Windows.Forms.TextBox();
			this.windowGroupBox = new System.Windows.Forms.GroupBox();
			this.frameInvisibleCheckBox = new System.Windows.Forms.CheckBox();
			this.aspectRateFixCheckBox = new System.Windows.Forms.CheckBox();
			this.windowSnapEnableCheckBox = new System.Windows.Forms.CheckBox();
			this.initGroupBox = new System.Windows.Forms.GroupBox();
			this.returnSizeOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.returnPositionOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.initVolumeLabel = new System.Windows.Forms.Label();
			this.writeFieldVisibleCheckBox = new System.Windows.Forms.CheckBox();
			this.topMostCheckBox = new System.Windows.Forms.CheckBox();
			this.initVolumeTextBox = new System.Windows.Forms.TextBox();
			this.movieStartGroupBox = new System.Windows.Forms.GroupBox();
			this.movieStartComboBox = new System.Windows.Forms.ComboBox();
			this.closeGroupBox = new System.Windows.Forms.GroupBox();
			this.disconnectRealyOnCloseCheckBox = new System.Windows.Forms.CheckBox();
			this.statusBarGroupBox = new System.Windows.Forms.GroupBox();
			this.listenerNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.displayBitrateCheckBox = new System.Windows.Forms.CheckBox();
			this.displayFpsCheckBox = new System.Windows.Forms.CheckBox();
			this.shortcutPage = new System.Windows.Forms.TabPage();
			this.keyLabel = new System.Windows.Forms.Label();
			this.shortcutListView = new PeerstLib.Controls.BufferedListView();
			this.commandColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.shortcutColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gestureColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveReturnPositionCheckBox = new System.Windows.Forms.CheckBox();
			this.saveReturnSizeCheckBox = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.settingPage.SuspendLayout();
			this.volumeChangeGroupBox.SuspendLayout();
			this.windowGroupBox.SuspendLayout();
			this.initGroupBox.SuspendLayout();
			this.movieStartGroupBox.SuspendLayout();
			this.closeGroupBox.SuspendLayout();
			this.statusBarGroupBox.SuspendLayout();
			this.shortcutPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.settingPage);
			this.tabControl.Controls.Add(this.shortcutPage);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(461, 362);
			this.tabControl.TabIndex = 0;
			// 
			// settingPage
			// 
			this.settingPage.Controls.Add(this.volumeChangeGroupBox);
			this.settingPage.Controls.Add(this.windowGroupBox);
			this.settingPage.Controls.Add(this.initGroupBox);
			this.settingPage.Controls.Add(this.movieStartGroupBox);
			this.settingPage.Controls.Add(this.closeGroupBox);
			this.settingPage.Controls.Add(this.statusBarGroupBox);
			this.settingPage.Location = new System.Drawing.Point(4, 22);
			this.settingPage.Name = "settingPage";
			this.settingPage.Padding = new System.Windows.Forms.Padding(3);
			this.settingPage.Size = new System.Drawing.Size(453, 336);
			this.settingPage.TabIndex = 0;
			this.settingPage.Text = "各種設定";
			this.settingPage.UseVisualStyleBackColor = true;
			// 
			// volumeChangeGroupBox
			// 
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeNoneLabel);
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeShiftLabel);
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeCtrlLabel);
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeCtrlTextBox);
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeNoneTextBox);
			this.volumeChangeGroupBox.Controls.Add(this.volumeChangeShiftTextBox);
			this.volumeChangeGroupBox.Location = new System.Drawing.Point(11, 221);
			this.volumeChangeGroupBox.Name = "volumeChangeGroupBox";
			this.volumeChangeGroupBox.Size = new System.Drawing.Size(210, 102);
			this.volumeChangeGroupBox.TabIndex = 2;
			this.volumeChangeGroupBox.TabStop = false;
			this.volumeChangeGroupBox.Text = "音量変化";
			// 
			// volumeChangeNoneLabel
			// 
			this.volumeChangeNoneLabel.AutoSize = true;
			this.volumeChangeNoneLabel.Location = new System.Drawing.Point(52, 24);
			this.volumeChangeNoneLabel.Name = "volumeChangeNoneLabel";
			this.volumeChangeNoneLabel.Size = new System.Drawing.Size(74, 12);
			this.volumeChangeNoneLabel.TabIndex = 0;
			this.volumeChangeNoneLabel.Text = "ホイール回転：";
			// 
			// volumeChangeShiftLabel
			// 
			this.volumeChangeShiftLabel.AutoSize = true;
			this.volumeChangeShiftLabel.Location = new System.Drawing.Point(14, 74);
			this.volumeChangeShiftLabel.Name = "volumeChangeShiftLabel";
			this.volumeChangeShiftLabel.Size = new System.Drawing.Size(112, 12);
			this.volumeChangeShiftLabel.TabIndex = 4;
			this.volumeChangeShiftLabel.Text = "Shift + ホイール回転：";
			// 
			// volumeChangeCtrlLabel
			// 
			this.volumeChangeCtrlLabel.AutoSize = true;
			this.volumeChangeCtrlLabel.Location = new System.Drawing.Point(19, 49);
			this.volumeChangeCtrlLabel.Name = "volumeChangeCtrlLabel";
			this.volumeChangeCtrlLabel.Size = new System.Drawing.Size(107, 12);
			this.volumeChangeCtrlLabel.TabIndex = 2;
			this.volumeChangeCtrlLabel.Text = "Ctrl + ホイール回転：";
			// 
			// volumeChangeCtrlTextBox
			// 
			this.volumeChangeCtrlTextBox.Location = new System.Drawing.Point(135, 46);
			this.volumeChangeCtrlTextBox.Name = "volumeChangeCtrlTextBox";
			this.volumeChangeCtrlTextBox.Size = new System.Drawing.Size(35, 19);
			this.volumeChangeCtrlTextBox.TabIndex = 3;
			this.volumeChangeCtrlTextBox.Text = "5";
			// 
			// volumeChangeNoneTextBox
			// 
			this.volumeChangeNoneTextBox.Location = new System.Drawing.Point(135, 21);
			this.volumeChangeNoneTextBox.Name = "volumeChangeNoneTextBox";
			this.volumeChangeNoneTextBox.Size = new System.Drawing.Size(35, 19);
			this.volumeChangeNoneTextBox.TabIndex = 1;
			this.volumeChangeNoneTextBox.Text = "10";
			// 
			// volumeChangeShiftTextBox
			// 
			this.volumeChangeShiftTextBox.Location = new System.Drawing.Point(135, 71);
			this.volumeChangeShiftTextBox.Name = "volumeChangeShiftTextBox";
			this.volumeChangeShiftTextBox.Size = new System.Drawing.Size(35, 19);
			this.volumeChangeShiftTextBox.TabIndex = 5;
			this.volumeChangeShiftTextBox.Text = "1";
			// 
			// windowGroupBox
			// 
			this.windowGroupBox.Controls.Add(this.frameInvisibleCheckBox);
			this.windowGroupBox.Controls.Add(this.aspectRateFixCheckBox);
			this.windowGroupBox.Controls.Add(this.windowSnapEnableCheckBox);
			this.windowGroupBox.Location = new System.Drawing.Point(11, 14);
			this.windowGroupBox.Name = "windowGroupBox";
			this.windowGroupBox.Size = new System.Drawing.Size(210, 90);
			this.windowGroupBox.TabIndex = 0;
			this.windowGroupBox.TabStop = false;
			this.windowGroupBox.Text = "ウィンドウ";
			// 
			// frameInvisibleCheckBox
			// 
			this.frameInvisibleCheckBox.AutoSize = true;
			this.frameInvisibleCheckBox.Location = new System.Drawing.Point(17, 64);
			this.frameInvisibleCheckBox.Name = "frameInvisibleCheckBox";
			this.frameInvisibleCheckBox.Size = new System.Drawing.Size(169, 16);
			this.frameInvisibleCheckBox.TabIndex = 2;
			this.frameInvisibleCheckBox.Text = "枠を消す（仮実装・要再起動）";
			this.frameInvisibleCheckBox.UseVisualStyleBackColor = true;
			// 
			// aspectRateFixCheckBox
			// 
			this.aspectRateFixCheckBox.AutoSize = true;
			this.aspectRateFixCheckBox.Location = new System.Drawing.Point(17, 40);
			this.aspectRateFixCheckBox.Name = "aspectRateFixCheckBox";
			this.aspectRateFixCheckBox.Size = new System.Drawing.Size(113, 16);
			this.aspectRateFixCheckBox.TabIndex = 1;
			this.aspectRateFixCheckBox.Text = "アスペクト比を維持";
			this.aspectRateFixCheckBox.UseVisualStyleBackColor = true;
			// 
			// windowSnapEnableCheckBox
			// 
			this.windowSnapEnableCheckBox.AutoSize = true;
			this.windowSnapEnableCheckBox.Location = new System.Drawing.Point(17, 18);
			this.windowSnapEnableCheckBox.Name = "windowSnapEnableCheckBox";
			this.windowSnapEnableCheckBox.Size = new System.Drawing.Size(126, 16);
			this.windowSnapEnableCheckBox.TabIndex = 0;
			this.windowSnapEnableCheckBox.Text = "ウィンドウスナップ有効";
			this.windowSnapEnableCheckBox.UseVisualStyleBackColor = true;
			// 
			// initGroupBox
			// 
			this.initGroupBox.Controls.Add(this.returnSizeOnStartCheckBox);
			this.initGroupBox.Controls.Add(this.returnPositionOnStartCheckBox);
			this.initGroupBox.Controls.Add(this.initVolumeLabel);
			this.initGroupBox.Controls.Add(this.writeFieldVisibleCheckBox);
			this.initGroupBox.Controls.Add(this.topMostCheckBox);
			this.initGroupBox.Controls.Add(this.initVolumeTextBox);
			this.initGroupBox.Location = new System.Drawing.Point(231, 14);
			this.initGroupBox.Name = "initGroupBox";
			this.initGroupBox.Size = new System.Drawing.Size(210, 135);
			this.initGroupBox.TabIndex = 3;
			this.initGroupBox.TabStop = false;
			this.initGroupBox.Text = "初期表示";
			// 
			// returnSizeOnStartCheckBox
			// 
			this.returnSizeOnStartCheckBox.AutoSize = true;
			this.returnSizeOnStartCheckBox.Location = new System.Drawing.Point(18, 84);
			this.returnSizeOnStartCheckBox.Name = "returnSizeOnStartCheckBox";
			this.returnSizeOnStartCheckBox.Size = new System.Drawing.Size(148, 16);
			this.returnSizeOnStartCheckBox.TabIndex = 0;
			this.returnSizeOnStartCheckBox.Text = "ウィンドウサイズを復帰する";
			this.returnSizeOnStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// returnPositionOnStartCheckBox
			// 
			this.returnPositionOnStartCheckBox.AutoSize = true;
			this.returnPositionOnStartCheckBox.Location = new System.Drawing.Point(18, 62);
			this.returnPositionOnStartCheckBox.Name = "returnPositionOnStartCheckBox";
			this.returnPositionOnStartCheckBox.Size = new System.Drawing.Size(143, 16);
			this.returnPositionOnStartCheckBox.TabIndex = 0;
			this.returnPositionOnStartCheckBox.Text = "ウィンドウ位置を復帰する";
			this.returnPositionOnStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// initVolumeLabel
			// 
			this.initVolumeLabel.AutoSize = true;
			this.initVolumeLabel.Location = new System.Drawing.Point(16, 109);
			this.initVolumeLabel.Name = "initVolumeLabel";
			this.initVolumeLabel.Size = new System.Drawing.Size(59, 12);
			this.initVolumeLabel.TabIndex = 2;
			this.initVolumeLabel.Text = "初期音量：";
			// 
			// writeFieldVisibleCheckBox
			// 
			this.writeFieldVisibleCheckBox.AutoSize = true;
			this.writeFieldVisibleCheckBox.Location = new System.Drawing.Point(18, 18);
			this.writeFieldVisibleCheckBox.Name = "writeFieldVisibleCheckBox";
			this.writeFieldVisibleCheckBox.Size = new System.Drawing.Size(104, 16);
			this.writeFieldVisibleCheckBox.TabIndex = 0;
			this.writeFieldVisibleCheckBox.Text = "書き込み欄表示";
			this.writeFieldVisibleCheckBox.UseVisualStyleBackColor = true;
			// 
			// topMostCheckBox
			// 
			this.topMostCheckBox.AutoSize = true;
			this.topMostCheckBox.Location = new System.Drawing.Point(18, 40);
			this.topMostCheckBox.Name = "topMostCheckBox";
			this.topMostCheckBox.Size = new System.Drawing.Size(84, 16);
			this.topMostCheckBox.TabIndex = 1;
			this.topMostCheckBox.Text = "最前列表示";
			this.topMostCheckBox.UseVisualStyleBackColor = true;
			// 
			// initVolumeTextBox
			// 
			this.initVolumeTextBox.Location = new System.Drawing.Point(81, 106);
			this.initVolumeTextBox.Name = "initVolumeTextBox";
			this.initVolumeTextBox.Size = new System.Drawing.Size(35, 19);
			this.initVolumeTextBox.TabIndex = 3;
			this.initVolumeTextBox.Text = "50";
			// 
			// movieStartGroupBox
			// 
			this.movieStartGroupBox.Controls.Add(this.movieStartComboBox);
			this.movieStartGroupBox.Location = new System.Drawing.Point(231, 274);
			this.movieStartGroupBox.Name = "movieStartGroupBox";
			this.movieStartGroupBox.Size = new System.Drawing.Size(210, 49);
			this.movieStartGroupBox.TabIndex = 4;
			this.movieStartGroupBox.TabStop = false;
			this.movieStartGroupBox.Text = "動画再生時";
			// 
			// movieStartComboBox
			// 
			this.movieStartComboBox.FormattingEnabled = true;
			this.movieStartComboBox.Location = new System.Drawing.Point(9, 18);
			this.movieStartComboBox.Name = "movieStartComboBox";
			this.movieStartComboBox.Size = new System.Drawing.Size(195, 20);
			this.movieStartComboBox.TabIndex = 0;
			// 
			// closeGroupBox
			// 
			this.closeGroupBox.Controls.Add(this.saveReturnSizeCheckBox);
			this.closeGroupBox.Controls.Add(this.saveReturnPositionCheckBox);
			this.closeGroupBox.Controls.Add(this.disconnectRealyOnCloseCheckBox);
			this.closeGroupBox.Location = new System.Drawing.Point(231, 155);
			this.closeGroupBox.Name = "closeGroupBox";
			this.closeGroupBox.Size = new System.Drawing.Size(210, 90);
			this.closeGroupBox.TabIndex = 4;
			this.closeGroupBox.TabStop = false;
			this.closeGroupBox.Text = "終了時";
			// 
			// disconnectRealyOnCloseCheckBox
			// 
			this.disconnectRealyOnCloseCheckBox.AutoSize = true;
			this.disconnectRealyOnCloseCheckBox.Location = new System.Drawing.Point(21, 18);
			this.disconnectRealyOnCloseCheckBox.Name = "disconnectRealyOnCloseCheckBox";
			this.disconnectRealyOnCloseCheckBox.Size = new System.Drawing.Size(74, 16);
			this.disconnectRealyOnCloseCheckBox.TabIndex = 0;
			this.disconnectRealyOnCloseCheckBox.Text = "リレー切断";
			this.disconnectRealyOnCloseCheckBox.UseVisualStyleBackColor = true;
			// 
			// statusBarGroupBox
			// 
			this.statusBarGroupBox.Controls.Add(this.listenerNumberCheckBox);
			this.statusBarGroupBox.Controls.Add(this.displayBitrateCheckBox);
			this.statusBarGroupBox.Controls.Add(this.displayFpsCheckBox);
			this.statusBarGroupBox.Location = new System.Drawing.Point(11, 115);
			this.statusBarGroupBox.Name = "statusBarGroupBox";
			this.statusBarGroupBox.Size = new System.Drawing.Size(210, 96);
			this.statusBarGroupBox.TabIndex = 1;
			this.statusBarGroupBox.TabStop = false;
			this.statusBarGroupBox.Text = "ステータスバー";
			// 
			// listenerNumberCheckBox
			// 
			this.listenerNumberCheckBox.AutoSize = true;
			this.listenerNumberCheckBox.Location = new System.Drawing.Point(17, 62);
			this.listenerNumberCheckBox.Name = "listenerNumberCheckBox";
			this.listenerNumberCheckBox.Size = new System.Drawing.Size(105, 16);
			this.listenerNumberCheckBox.TabIndex = 1;
			this.listenerNumberCheckBox.Text = "リスナー数を表示";
			this.listenerNumberCheckBox.UseVisualStyleBackColor = true;
			// 
			// displayBitrateCheckBox
			// 
			this.displayBitrateCheckBox.AutoSize = true;
			this.displayBitrateCheckBox.Location = new System.Drawing.Point(17, 40);
			this.displayBitrateCheckBox.Name = "displayBitrateCheckBox";
			this.displayBitrateCheckBox.Size = new System.Drawing.Size(107, 16);
			this.displayBitrateCheckBox.TabIndex = 1;
			this.displayBitrateCheckBox.Text = "ビットレートを表示";
			this.displayBitrateCheckBox.UseVisualStyleBackColor = true;
			// 
			// displayFpsCheckBox
			// 
			this.displayFpsCheckBox.AutoSize = true;
			this.displayFpsCheckBox.Location = new System.Drawing.Point(17, 18);
			this.displayFpsCheckBox.Name = "displayFpsCheckBox";
			this.displayFpsCheckBox.Size = new System.Drawing.Size(78, 16);
			this.displayFpsCheckBox.TabIndex = 0;
			this.displayFpsCheckBox.Text = "FPSを表示";
			this.displayFpsCheckBox.UseVisualStyleBackColor = true;
			// 
			// shortcutPage
			// 
			this.shortcutPage.Controls.Add(this.keyLabel);
			this.shortcutPage.Controls.Add(this.shortcutListView);
			this.shortcutPage.Location = new System.Drawing.Point(4, 22);
			this.shortcutPage.Name = "shortcutPage";
			this.shortcutPage.Padding = new System.Windows.Forms.Padding(3);
			this.shortcutPage.Size = new System.Drawing.Size(453, 336);
			this.shortcutPage.TabIndex = 1;
			this.shortcutPage.Text = "ショートカット";
			this.shortcutPage.UseVisualStyleBackColor = true;
			// 
			// keyLabel
			// 
			this.keyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.keyLabel.AutoSize = true;
			this.keyLabel.Location = new System.Drawing.Point(8, 261);
			this.keyLabel.Name = "keyLabel";
			this.keyLabel.Size = new System.Drawing.Size(274, 72);
			this.keyLabel.TabIndex = 1;
			this.keyLabel.Text = "【登録方法】\r\n　ショートカット：コマンドを選択後、キー入力\r\n　マウスジェスチャ：コマンドを選択後、マウスジェスチャ入力\r\n【削除方法】\r\n　ショートカット：削" +
    "除したいショートカットをダブルクリック(左)\r\n　マウスジェスチャ：削除したいジェスチャをダブルクリック(右)";
			// 
			// shortcutListView
			// 
			this.shortcutListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shortcutListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.commandColumnHeader,
            this.shortcutColumnHeader,
            this.gestureColumnHeader});
			this.shortcutListView.FullRowSelect = true;
			this.shortcutListView.GridLines = true;
			this.shortcutListView.Location = new System.Drawing.Point(8, 6);
			this.shortcutListView.MultiSelect = false;
			this.shortcutListView.Name = "shortcutListView";
			this.shortcutListView.Size = new System.Drawing.Size(434, 252);
			this.shortcutListView.TabIndex = 0;
			this.shortcutListView.UseCompatibleStateImageBehavior = false;
			this.shortcutListView.View = System.Windows.Forms.View.Details;
			// 
			// commandColumnHeader
			// 
			this.commandColumnHeader.Text = "コマンド";
			this.commandColumnHeader.Width = 140;
			// 
			// shortcutColumnHeader
			// 
			this.shortcutColumnHeader.Text = "ショートカット";
			this.shortcutColumnHeader.Width = 127;
			// 
			// gestureColumnHeader
			// 
			this.gestureColumnHeader.Text = "マウスジェスチャ";
			this.gestureColumnHeader.Width = 127;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(290, 368);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "保存";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(371, 368);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "キャンセル";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// saveReturnPositionCheckBox
			// 
			this.saveReturnPositionCheckBox.AutoSize = true;
			this.saveReturnPositionCheckBox.Location = new System.Drawing.Point(21, 40);
			this.saveReturnPositionCheckBox.Name = "saveReturnPositionCheckBox";
			this.saveReturnPositionCheckBox.Size = new System.Drawing.Size(143, 16);
			this.saveReturnPositionCheckBox.TabIndex = 0;
			this.saveReturnPositionCheckBox.Text = "ウィンドウ位置を保存する";
			this.saveReturnPositionCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveReturnSizeCheckBox
			// 
			this.saveReturnSizeCheckBox.AutoSize = true;
			this.saveReturnSizeCheckBox.Location = new System.Drawing.Point(21, 62);
			this.saveReturnSizeCheckBox.Name = "saveReturnSizeCheckBox";
			this.saveReturnSizeCheckBox.Size = new System.Drawing.Size(148, 16);
			this.saveReturnSizeCheckBox.TabIndex = 0;
			this.saveReturnSizeCheckBox.Text = "ウィンドウサイズを保存する";
			this.saveReturnSizeCheckBox.UseVisualStyleBackColor = true;
			// 
			// PlayerSettingView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 397);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PlayerSettingView";
			this.Text = "設定";
			this.tabControl.ResumeLayout(false);
			this.settingPage.ResumeLayout(false);
			this.volumeChangeGroupBox.ResumeLayout(false);
			this.volumeChangeGroupBox.PerformLayout();
			this.windowGroupBox.ResumeLayout(false);
			this.windowGroupBox.PerformLayout();
			this.initGroupBox.ResumeLayout(false);
			this.initGroupBox.PerformLayout();
			this.movieStartGroupBox.ResumeLayout(false);
			this.closeGroupBox.ResumeLayout(false);
			this.closeGroupBox.PerformLayout();
			this.statusBarGroupBox.ResumeLayout(false);
			this.statusBarGroupBox.PerformLayout();
			this.shortcutPage.ResumeLayout(false);
			this.shortcutPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage settingPage;
		private System.Windows.Forms.TabPage shortcutPage;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox windowGroupBox;
		private System.Windows.Forms.GroupBox initGroupBox;
		private System.Windows.Forms.GroupBox closeGroupBox;
		private System.Windows.Forms.GroupBox statusBarGroupBox;
		private System.Windows.Forms.CheckBox disconnectRealyOnCloseCheckBox;
		private System.Windows.Forms.CheckBox windowSnapEnableCheckBox;
		private System.Windows.Forms.CheckBox topMostCheckBox;
		private System.Windows.Forms.CheckBox aspectRateFixCheckBox;
		private System.Windows.Forms.CheckBox writeFieldVisibleCheckBox;
		private BufferedListView shortcutListView;
		private System.Windows.Forms.ColumnHeader commandColumnHeader;
		private System.Windows.Forms.ColumnHeader shortcutColumnHeader;
		private System.Windows.Forms.Label keyLabel;
		private System.Windows.Forms.Label initVolumeLabel;
		private System.Windows.Forms.ColumnHeader gestureColumnHeader;
		private System.Windows.Forms.CheckBox displayBitrateCheckBox;
		private System.Windows.Forms.CheckBox displayFpsCheckBox;
		private System.Windows.Forms.TextBox initVolumeTextBox;
		private System.Windows.Forms.GroupBox volumeChangeGroupBox;
		private System.Windows.Forms.Label volumeChangeShiftLabel;
		private System.Windows.Forms.Label volumeChangeCtrlLabel;
		private System.Windows.Forms.TextBox volumeChangeCtrlTextBox;
		private System.Windows.Forms.TextBox volumeChangeShiftTextBox;
		private System.Windows.Forms.Label volumeChangeNoneLabel;
		private System.Windows.Forms.TextBox volumeChangeNoneTextBox;
		private System.Windows.Forms.CheckBox listenerNumberCheckBox;
		private System.Windows.Forms.GroupBox movieStartGroupBox;
		private System.Windows.Forms.ComboBox movieStartComboBox;
		private System.Windows.Forms.CheckBox frameInvisibleCheckBox;
		private System.Windows.Forms.CheckBox returnSizeOnStartCheckBox;
		private System.Windows.Forms.CheckBox returnPositionOnStartCheckBox;
		private System.Windows.Forms.CheckBox saveReturnSizeCheckBox;
		private System.Windows.Forms.CheckBox saveReturnPositionCheckBox;

	}
}