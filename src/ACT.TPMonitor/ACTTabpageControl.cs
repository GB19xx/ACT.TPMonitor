using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Advanced_Combat_Tracker;

namespace ACT.TPMonitor
{
	public class ACTTabpageControl : UserControl, IActPluginV1
	{
		#region Designer Created Code (Avoid editing)
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxCharacterFolder = new System.Windows.Forms.TextBox();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.groupBoxCharacterFolder = new System.Windows.Forms.GroupBox();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
            this.labelACT = new System.Windows.Forms.Label();
            this.labelLoggedInStatus = new System.Windows.Forms.Label();
            this.labelFFXIVPlugin = new System.Windows.Forms.Label();
            this.labelFFXIVProcessStatus = new System.Windows.Forms.Label();
            this.labelFFXIVProcess = new System.Windows.Forms.Label();
            this.labelFFXIVPluginStatus = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelACTStatus = new System.Windows.Forms.Label();
            this.groupBoxFont = new System.Windows.Forms.GroupBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTPFont = new System.Windows.Forms.ComboBox();
            this.groupBoxRecommend = new System.Windows.Forms.GroupBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.textBoxRecommend = new System.Windows.Forms.TextBox();
            this.groupBoxOption = new System.Windows.Forms.GroupBox();
            this.checkBoxShowMyTP = new System.Windows.Forms.CheckBox();
            this.checkBoxHideOnDissolve = new System.Windows.Forms.CheckBox();
            this.groupBoxLocation = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxWhereNow = new System.Windows.Forms.GroupBox();
            this.labelHereNowX = new System.Windows.Forms.Label();
            this.labelHereNowY = new System.Windows.Forms.Label();
            this.labelFixedX = new System.Windows.Forms.Label();
            this.labelFixedY = new System.Windows.Forms.Label();
            this.labelOffsetY = new System.Windows.Forms.Label();
            this.labelOffsetX = new System.Windows.Forms.Label();
            this.numericUpDownFixedY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFixedX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetX = new System.Windows.Forms.NumericUpDown();
            this.radioButtonFixed = new System.Windows.Forms.RadioButton();
            this.radioButtonOffset = new System.Windows.Forms.RadioButton();
            this.groupBoxCharacterFolder.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tableLayoutPanelStatus.SuspendLayout();
            this.groupBoxFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.groupBoxRecommend.SuspendLayout();
            this.groupBoxOption.SuspendLayout();
            this.groupBoxLocation.SuspendLayout();
            this.groupBoxWhereNow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCharacterFolder
            // 
            this.textBoxCharacterFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCharacterFolder.Location = new System.Drawing.Point(6, 20);
            this.textBoxCharacterFolder.Name = "textBoxCharacterFolder";
            this.textBoxCharacterFolder.ReadOnly = true;
            this.textBoxCharacterFolder.Size = new System.Drawing.Size(651, 19);
            this.textBoxCharacterFolder.TabIndex = 0;
            this.textBoxCharacterFolder.Text = "%Appdata%";
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFolder.Location = new System.Drawing.Point(663, 18);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.TabIndex = 1;
            this.buttonOpenFolder.Text = "Open Folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // groupBoxCharacterFolder
            // 
            this.groupBoxCharacterFolder.Controls.Add(this.buttonOpenFolder);
            this.groupBoxCharacterFolder.Controls.Add(this.textBoxCharacterFolder);
            this.groupBoxCharacterFolder.Location = new System.Drawing.Point(19, 23);
            this.groupBoxCharacterFolder.Name = "groupBoxCharacterFolder";
            this.groupBoxCharacterFolder.Size = new System.Drawing.Size(744, 54);
            this.groupBoxCharacterFolder.TabIndex = 0;
            this.groupBoxCharacterFolder.TabStop = false;
            this.groupBoxCharacterFolder.Text = "Character Folder";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.tableLayoutPanelStatus);
            this.groupBoxStatus.Location = new System.Drawing.Point(19, 83);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(292, 96);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // tableLayoutPanelStatus
            // 
            this.tableLayoutPanelStatus.ColumnCount = 2;
            this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelStatus.Controls.Add(this.labelACT, 0, 0);
            this.tableLayoutPanelStatus.Controls.Add(this.labelLoggedInStatus, 1, 3);
            this.tableLayoutPanelStatus.Controls.Add(this.labelFFXIVPlugin, 0, 1);
            this.tableLayoutPanelStatus.Controls.Add(this.labelFFXIVProcessStatus, 1, 2);
            this.tableLayoutPanelStatus.Controls.Add(this.labelFFXIVProcess, 0, 2);
            this.tableLayoutPanelStatus.Controls.Add(this.labelFFXIVPluginStatus, 1, 1);
            this.tableLayoutPanelStatus.Controls.Add(this.labelLogin, 0, 3);
            this.tableLayoutPanelStatus.Controls.Add(this.labelACTStatus, 1, 0);
            this.tableLayoutPanelStatus.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
            this.tableLayoutPanelStatus.RowCount = 4;
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatus.Size = new System.Drawing.Size(280, 72);
            this.tableLayoutPanelStatus.TabIndex = 0;
            // 
            // labelACT
            // 
            this.labelACT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelACT.AutoSize = true;
            this.labelACT.Location = new System.Drawing.Point(3, 3);
            this.labelACT.Name = "labelACT";
            this.labelACT.Size = new System.Drawing.Size(30, 12);
            this.labelACT.TabIndex = 0;
            this.labelACT.Text = "ACT:";
            // 
            // labelLoggedInStatus
            // 
            this.labelLoggedInStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLoggedInStatus.AutoSize = true;
            this.labelLoggedInStatus.Location = new System.Drawing.Point(123, 57);
            this.labelLoggedInStatus.Name = "labelLoggedInStatus";
            this.labelLoggedInStatus.Size = new System.Drawing.Size(66, 12);
            this.labelLoggedInStatus.TabIndex = 7;
            this.labelLoggedInStatus.Text = "No Process.";
            // 
            // labelFFXIVPlugin
            // 
            this.labelFFXIVPlugin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFFXIVPlugin.AutoSize = true;
            this.labelFFXIVPlugin.Location = new System.Drawing.Point(3, 21);
            this.labelFFXIVPlugin.Name = "labelFFXIVPlugin";
            this.labelFFXIVPlugin.Size = new System.Drawing.Size(101, 12);
            this.labelFFXIVPlugin.TabIndex = 2;
            this.labelFFXIVPlugin.Text = "FFXIV ACT Plugin:";
            // 
            // labelFFXIVProcessStatus
            // 
            this.labelFFXIVProcessStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFFXIVProcessStatus.AutoSize = true;
            this.labelFFXIVProcessStatus.Location = new System.Drawing.Point(123, 39);
            this.labelFFXIVProcessStatus.Name = "labelFFXIVProcessStatus";
            this.labelFFXIVProcessStatus.Size = new System.Drawing.Size(66, 12);
            this.labelFFXIVProcessStatus.TabIndex = 5;
            this.labelFFXIVProcessStatus.Text = "No Process.";
            // 
            // labelFFXIVProcess
            // 
            this.labelFFXIVProcess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFFXIVProcess.AutoSize = true;
            this.labelFFXIVProcess.Location = new System.Drawing.Point(3, 39);
            this.labelFFXIVProcess.Name = "labelFFXIVProcess";
            this.labelFFXIVProcess.Size = new System.Drawing.Size(81, 12);
            this.labelFFXIVProcess.TabIndex = 4;
            this.labelFFXIVProcess.Text = "Game Process:";
            // 
            // labelFFXIVPluginStatus
            // 
            this.labelFFXIVPluginStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFFXIVPluginStatus.AutoSize = true;
            this.labelFFXIVPluginStatus.Location = new System.Drawing.Point(123, 21);
            this.labelFFXIVPluginStatus.Name = "labelFFXIVPluginStatus";
            this.labelFFXIVPluginStatus.Size = new System.Drawing.Size(66, 12);
            this.labelFFXIVPluginStatus.TabIndex = 3;
            this.labelFFXIVPluginStatus.Text = "No Process.";
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(3, 57);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(34, 12);
            this.labelLogin.TabIndex = 6;
            this.labelLogin.Text = "Login:";
            // 
            // labelACTStatus
            // 
            this.labelACTStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelACTStatus.AutoSize = true;
            this.labelACTStatus.Location = new System.Drawing.Point(123, 3);
            this.labelACTStatus.Name = "labelACTStatus";
            this.labelACTStatus.Size = new System.Drawing.Size(66, 12);
            this.labelACTStatus.TabIndex = 1;
            this.labelACTStatus.Text = "No Process.";
            // 
            // groupBoxFont
            // 
            this.groupBoxFont.Controls.Add(this.numericUpDownFontSize);
            this.groupBoxFont.Controls.Add(this.comboBoxTPFont);
            this.groupBoxFont.Location = new System.Drawing.Point(615, 261);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(148, 76);
            this.groupBoxFont.TabIndex = 4;
            this.groupBoxFont.TabStop = false;
            this.groupBoxFont.Text = "Font";
            this.groupBoxFont.Visible = false;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(17, 44);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(51, 19);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // comboBoxTPFont
            // 
            this.comboBoxTPFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTPFont.FormattingEnabled = true;
            this.comboBoxTPFont.Location = new System.Drawing.Point(17, 18);
            this.comboBoxTPFont.Name = "comboBoxTPFont";
            this.comboBoxTPFont.Size = new System.Drawing.Size(113, 20);
            this.comboBoxTPFont.TabIndex = 0;
            this.comboBoxTPFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxTPFont_SelectedIndexChanged);
            // 
            // groupBoxRecommend
            // 
            this.groupBoxRecommend.Controls.Add(this.buttonCopy);
            this.groupBoxRecommend.Controls.Add(this.textBoxRecommend);
            this.groupBoxRecommend.Location = new System.Drawing.Point(615, 83);
            this.groupBoxRecommend.Name = "groupBoxRecommend";
            this.groupBoxRecommend.Size = new System.Drawing.Size(148, 172);
            this.groupBoxRecommend.TabIndex = 5;
            this.groupBoxRecommend.TabStop = false;
            this.groupBoxRecommend.Text = "Recommend Macro";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(15, 139);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(119, 23);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "Clipbord Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // textBoxRecommend
            // 
            this.textBoxRecommend.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRecommend.Location = new System.Drawing.Point(6, 18);
            this.textBoxRecommend.Multiline = true;
            this.textBoxRecommend.Name = "textBoxRecommend";
            this.textBoxRecommend.ReadOnly = true;
            this.textBoxRecommend.Size = new System.Drawing.Size(136, 115);
            this.textBoxRecommend.TabIndex = 5;
            this.textBoxRecommend.Text = "/e TP 2:<2>\r\n/e TP 3:<3>\r\n/e TP 4:<4>\r\n/e TP 5:<5>\r\n/e TP 6:<6>\r\n/e TP 7:<7>\r\n/e " +
    "TP 8:<8>\r\n/e TP /show";
            // 
            // groupBoxOption
            // 
            this.groupBoxOption.Controls.Add(this.checkBoxShowMyTP);
            this.groupBoxOption.Controls.Add(this.checkBoxHideOnDissolve);
            this.groupBoxOption.Location = new System.Drawing.Point(19, 185);
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.Size = new System.Drawing.Size(292, 70);
            this.groupBoxOption.TabIndex = 2;
            this.groupBoxOption.TabStop = false;
            this.groupBoxOption.Text = "Option";
            // 
            // checkBoxShowMyTP
            // 
            this.checkBoxShowMyTP.AutoSize = true;
            this.checkBoxShowMyTP.Checked = true;
            this.checkBoxShowMyTP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMyTP.Location = new System.Drawing.Point(15, 44);
            this.checkBoxShowMyTP.Name = "checkBoxShowMyTP";
            this.checkBoxShowMyTP.Size = new System.Drawing.Size(184, 16);
            this.checkBoxShowMyTP.TabIndex = 0;
            this.checkBoxShowMyTP.Text = "Show my TP (Fixed mode only)";
            this.checkBoxShowMyTP.UseVisualStyleBackColor = true;
            this.checkBoxShowMyTP.CheckedChanged += new System.EventHandler(this.checkBoxShowMyTP_CheckedChanged);
            // 
            // checkBoxHideOnDissolve
            // 
            this.checkBoxHideOnDissolve.AutoSize = true;
            this.checkBoxHideOnDissolve.Checked = true;
            this.checkBoxHideOnDissolve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideOnDissolve.Location = new System.Drawing.Point(15, 22);
            this.checkBoxHideOnDissolve.Name = "checkBoxHideOnDissolve";
            this.checkBoxHideOnDissolve.Size = new System.Drawing.Size(262, 16);
            this.checkBoxHideOnDissolve.TabIndex = 0;
            this.checkBoxHideOnDissolve.Text = "TPMonitor is to hide when dissolved the party.";
            this.checkBoxHideOnDissolve.UseVisualStyleBackColor = true;
            this.checkBoxHideOnDissolve.CheckedChanged += new System.EventHandler(this.checkBoxHideOnDissolve_CheckedChanged);
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.buttonSave);
            this.groupBoxLocation.Controls.Add(this.groupBoxWhereNow);
            this.groupBoxLocation.Controls.Add(this.labelFixedX);
            this.groupBoxLocation.Controls.Add(this.labelFixedY);
            this.groupBoxLocation.Controls.Add(this.labelOffsetY);
            this.groupBoxLocation.Controls.Add(this.labelOffsetX);
            this.groupBoxLocation.Controls.Add(this.numericUpDownFixedY);
            this.groupBoxLocation.Controls.Add(this.numericUpDownFixedX);
            this.groupBoxLocation.Controls.Add(this.numericUpDownOffsetY);
            this.groupBoxLocation.Controls.Add(this.numericUpDownOffsetX);
            this.groupBoxLocation.Controls.Add(this.radioButtonFixed);
            this.groupBoxLocation.Controls.Add(this.radioButtonOffset);
            this.groupBoxLocation.Location = new System.Drawing.Point(317, 83);
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.Size = new System.Drawing.Size(292, 172);
            this.groupBoxLocation.TabIndex = 3;
            this.groupBoxLocation.TabStop = false;
            this.groupBoxLocation.Text = "Monitor Location";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(195, 127);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxWhereNow
            // 
            this.groupBoxWhereNow.Controls.Add(this.labelHereNowX);
            this.groupBoxWhereNow.Controls.Add(this.labelHereNowY);
            this.groupBoxWhereNow.Location = new System.Drawing.Point(16, 117);
            this.groupBoxWhereNow.Name = "groupBoxWhereNow";
            this.groupBoxWhereNow.Size = new System.Drawing.Size(152, 40);
            this.groupBoxWhereNow.TabIndex = 10;
            this.groupBoxWhereNow.TabStop = false;
            this.groupBoxWhereNow.Text = "Where now?";
            // 
            // labelHereNowX
            // 
            this.labelHereNowX.AutoSize = true;
            this.labelHereNowX.Location = new System.Drawing.Point(18, 15);
            this.labelHereNowX.Name = "labelHereNowX";
            this.labelHereNowX.Size = new System.Drawing.Size(14, 12);
            this.labelHereNowX.TabIndex = 6;
            this.labelHereNowX.Text = "X:";
            // 
            // labelHereNowY
            // 
            this.labelHereNowY.AutoSize = true;
            this.labelHereNowY.Location = new System.Drawing.Point(83, 15);
            this.labelHereNowY.Name = "labelHereNowY";
            this.labelHereNowY.Size = new System.Drawing.Size(14, 12);
            this.labelHereNowY.TabIndex = 8;
            this.labelHereNowY.Text = "Y:";
            // 
            // labelFixedX
            // 
            this.labelFixedX.AutoSize = true;
            this.labelFixedX.Location = new System.Drawing.Point(34, 88);
            this.labelFixedX.Name = "labelFixedX";
            this.labelFixedX.Size = new System.Drawing.Size(14, 12);
            this.labelFixedX.TabIndex = 6;
            this.labelFixedX.Text = "X:";
            // 
            // labelFixedY
            // 
            this.labelFixedY.AutoSize = true;
            this.labelFixedY.Location = new System.Drawing.Point(176, 88);
            this.labelFixedY.Name = "labelFixedY";
            this.labelFixedY.Size = new System.Drawing.Size(14, 12);
            this.labelFixedY.TabIndex = 8;
            this.labelFixedY.Text = "Y:";
            // 
            // labelOffsetY
            // 
            this.labelOffsetY.AutoSize = true;
            this.labelOffsetY.Location = new System.Drawing.Point(176, 41);
            this.labelOffsetY.Name = "labelOffsetY";
            this.labelOffsetY.Size = new System.Drawing.Size(14, 12);
            this.labelOffsetY.TabIndex = 3;
            this.labelOffsetY.Text = "Y:";
            // 
            // labelOffsetX
            // 
            this.labelOffsetX.AutoSize = true;
            this.labelOffsetX.Location = new System.Drawing.Point(34, 41);
            this.labelOffsetX.Name = "labelOffsetX";
            this.labelOffsetX.Size = new System.Drawing.Size(14, 12);
            this.labelOffsetX.TabIndex = 1;
            this.labelOffsetX.Text = "X:";
            // 
            // numericUpDownFixedY
            // 
            this.numericUpDownFixedY.Location = new System.Drawing.Point(196, 86);
            this.numericUpDownFixedY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFixedY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownFixedY.Name = "numericUpDownFixedY";
            this.numericUpDownFixedY.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownFixedY.TabIndex = 9;
            this.numericUpDownFixedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFixedY.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // numericUpDownFixedX
            // 
            this.numericUpDownFixedX.Location = new System.Drawing.Point(54, 86);
            this.numericUpDownFixedX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFixedX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownFixedX.Name = "numericUpDownFixedX";
            this.numericUpDownFixedX.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownFixedX.TabIndex = 7;
            this.numericUpDownFixedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFixedX.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // numericUpDownOffsetY
            // 
            this.numericUpDownOffsetY.Location = new System.Drawing.Point(196, 39);
            this.numericUpDownOffsetY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownOffsetY.Name = "numericUpDownOffsetY";
            this.numericUpDownOffsetY.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownOffsetY.TabIndex = 4;
            this.numericUpDownOffsetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownOffsetY.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // numericUpDownOffsetX
            // 
            this.numericUpDownOffsetX.Location = new System.Drawing.Point(54, 39);
            this.numericUpDownOffsetX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOffsetX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownOffsetX.Name = "numericUpDownOffsetX";
            this.numericUpDownOffsetX.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownOffsetX.TabIndex = 2;
            this.numericUpDownOffsetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownOffsetX.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // radioButtonFixed
            // 
            this.radioButtonFixed.AutoSize = true;
            this.radioButtonFixed.Location = new System.Drawing.Point(6, 64);
            this.radioButtonFixed.Name = "radioButtonFixed";
            this.radioButtonFixed.Size = new System.Drawing.Size(82, 16);
            this.radioButtonFixed.TabIndex = 5;
            this.radioButtonFixed.Text = "Fixed Mode";
            this.radioButtonFixed.UseVisualStyleBackColor = true;
            this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // radioButtonOffset
            // 
            this.radioButtonOffset.AutoSize = true;
            this.radioButtonOffset.Checked = true;
            this.radioButtonOffset.Location = new System.Drawing.Point(6, 17);
            this.radioButtonOffset.Name = "radioButtonOffset";
            this.radioButtonOffset.Size = new System.Drawing.Size(119, 16);
            this.radioButtonOffset.TabIndex = 0;
            this.radioButtonOffset.TabStop = true;
            this.radioButtonOffset.Text = "Party List + Offset";
            this.radioButtonOffset.UseVisualStyleBackColor = true;
            this.radioButtonOffset.CheckedChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // ACTTabpageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLocation);
            this.Controls.Add(this.groupBoxOption);
            this.Controls.Add(this.groupBoxFont);
            this.Controls.Add(this.groupBoxRecommend);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxCharacterFolder);
            this.Name = "ACTTabpageControl";
            this.Size = new System.Drawing.Size(786, 344);
            this.groupBoxCharacterFolder.ResumeLayout(false);
            this.groupBoxCharacterFolder.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.tableLayoutPanelStatus.ResumeLayout(false);
            this.tableLayoutPanelStatus.PerformLayout();
            this.groupBoxFont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.groupBoxRecommend.ResumeLayout(false);
            this.groupBoxRecommend.PerformLayout();
            this.groupBoxOption.ResumeLayout(false);
            this.groupBoxOption.PerformLayout();
            this.groupBoxLocation.ResumeLayout(false);
            this.groupBoxLocation.PerformLayout();
            this.groupBoxWhereNow.ResumeLayout(false);
            this.groupBoxWhereNow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion


        #endregion

        public ACTTabpageControl()
		{
			InitializeComponent();

            textBoxCharacterFolder.Text = (Directory.GetDirectories(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"My Games\FINAL FANTASY XIV - A Realm Reborn")), @"FFXIV_*"))[0]; 
            comboBoxTPFont.Text = "PIRULEN";
		}

		Label lblStatus;	// The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT.TPMonitor.config.xml");
        private TextBox textBoxCharacterFolder;
        private Button buttonOpenFolder;
        private GroupBox groupBoxCharacterFolder;
        private GroupBox groupBoxStatus;
        private Label labelFFXIVProcessStatus;
        private Label labelFFXIVPluginStatus;
        private Label labelACTStatus;
        private Label labelLogin;
        private Label labelFFXIVPlugin;
        private Label labelACT;
		SettingsSerializer xmlSettings;
        private Label labelFFXIVProcess;
        private Label labelLoggedInStatus;
       
        private GroupBox groupBoxFont;
        private ComboBox comboBoxTPFont;
        private TableLayoutPanel tableLayoutPanelStatus;
        private GroupBox groupBoxRecommend;
        private NumericUpDown numericUpDownFontSize;

        private TPMonitorController controller;
        private TextBox textBoxRecommend;
        private GroupBox groupBoxOption;
        private CheckBox checkBoxHideOnDissolve;
        private Button buttonCopy;
        private GroupBox groupBoxLocation;
        private NumericUpDown numericUpDownFixedY;
        private NumericUpDown numericUpDownFixedX;
        private NumericUpDown numericUpDownOffsetY;
        private NumericUpDown numericUpDownOffsetX;
        private RadioButton radioButtonFixed;
        private RadioButton radioButtonOffset;
        private Label labelFixedX;
        private Label labelFixedY;
        private Label labelOffsetY;
        private Label labelOffsetX;
        private CheckBox checkBoxShowMyTP;
        private GroupBox groupBoxWhereNow;
        private Label labelHereNowX;
        private Label labelHereNowY;
        private Button buttonSave;
        private Font selectedFont;

		#region IActPluginV1 Members
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
            pluginScreenSpace.Text = "TPMonitor"; 
			lblStatus = pluginStatusText;	// Hand the status label's reference to our local var
			pluginScreenSpace.Controls.Add(this);	// Add this UserControl to the tab ACT provides
			this.Dock = DockStyle.Fill;	// Expand the UserControl to fill the tab's client space            
			xmlSettings = new SettingsSerializer(this);	// Create a new settings serializer and pass it this instance
			LoadSettings();

            // Load FFXIV plugin's assembly if needed
            AppDomain.CurrentDomain.AssemblyResolve += (o, e) =>
            {
                var simpleName = new string(e.Name.TakeWhile(x => x != ',').ToArray());
                if (simpleName == "FFXIV_ACT_Plugin")
                {
                    var query = ActGlobals.oFormActMain.ActPlugins.Where(x => x.lblPluginTitle.Text == "FFXIV_ACT_Plugin.dll");
                    if (query.Any())
                    {
                        return System.Reflection.Assembly.LoadFrom(query.First().pluginFile.FullName);
                    }
                }

                return null;
            };

			lblStatus.Text = "Plugin Started.";

            controller = new TPMonitorController(this);
            controller.CharFolder = textBoxCharacterFolder.Text;
            controller.PartyListUI = Util.GetPartyListLocation(textBoxCharacterFolder.Text);
            controller.HideOnDissolve = checkBoxHideOnDissolve.Checked;
            controller.ShowMyTP = checkBoxShowMyTP.Checked;
            controller.IsFixedMode = radioButtonFixed.Checked;
            controller.OffsetX = numericUpDownOffsetX.Value;
            controller.OffsetY = numericUpDownOffsetY.Value;
            controller.FixedX = numericUpDownFixedX.Value;
            controller.FixedY = numericUpDownFixedY.Value;
            controller.ChangedStatus += new EventHandler(this.ChangedStatus);

            OnChangeLocation();

            SetFontName();
        }

        public void DeInitPlugin()
		{
			SaveSettings();
            if (pfc != null) pfc.Dispose();

            controller.Dispose();

            lblStatus.Text = "Plugin Exited.";
		}
		#endregion

        private void ChangedStatus(object sender, EventArgs e)
        {
            if (ActGlobals.oFormActMain.Visible)
            {
                labelACTStatus.Text = controller.ACTVisible ? "Started." : "Not started.";
                labelFFXIVPluginStatus.Text = controller.FFXIVPluginStatus ? "Started." : "Not started.";
                labelFFXIVProcessStatus.Text = controller.FFXIVProcess ? "Started." : "No process.";
                labelLoggedInStatus.Text = controller.LoggedIn ? "Logged in." : "Not logged in.";
                labelHereNowX.Text = string.Format("X:{0}", controller.ViewLocation.X);
                labelHereNowY.Text = string.Format("Y:{0}", controller.ViewLocation.Y);
            }
        }

		private void LoadSettings()
		{
            xmlSettings.AddControlSetting(textBoxCharacterFolder.Name, textBoxCharacterFolder);
            xmlSettings.AddControlSetting(comboBoxTPFont.Name, comboBoxTPFont);
            xmlSettings.AddControlSetting(numericUpDownFontSize.Name, numericUpDownFontSize);
            xmlSettings.AddControlSetting(checkBoxHideOnDissolve.Name, checkBoxHideOnDissolve);
            xmlSettings.AddControlSetting(checkBoxShowMyTP.Name, checkBoxShowMyTP);
            xmlSettings.AddControlSetting(radioButtonFixed.Name, radioButtonFixed);
            xmlSettings.AddControlSetting(numericUpDownOffsetX.Name, numericUpDownOffsetX);
            xmlSettings.AddControlSetting(numericUpDownOffsetY.Name, numericUpDownOffsetY);
            xmlSettings.AddControlSetting(numericUpDownFixedX.Name, numericUpDownFixedX);
            xmlSettings.AddControlSetting(numericUpDownFixedY.Name, numericUpDownFixedY);

			if (File.Exists(settingsFile))
			{
				FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlTextReader xReader = new XmlTextReader(fs);

				try
				{
					while (xReader.Read())
					{
						if (xReader.NodeType == XmlNodeType.Element)
						{
							if (xReader.LocalName == "SettingsSerializer")
							{
								xmlSettings.ImportFromXml(xReader);
							}
						}
					}
				}
				catch (Exception ex)
				{
					lblStatus.Text = "Error loading settings: " + ex.Message;
				}
				xReader.Close();
			}
		}

		private void SaveSettings()
		{
			FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");	// <Config>
			xWriter.WriteStartElement("SettingsSerializer");	// <Config><SettingsSerializer>
			xmlSettings.ExportToXml(xWriter);	// Fill the SettingsSerializer XML
			xWriter.WriteEndElement();	// </SettingsSerializer>
			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
			xWriter.Close();
		}

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.RootFolder = Environment.SpecialFolder.MyDocuments;
            f.SelectedPath = textBoxCharacterFolder.Text;
            f.ShowNewFolderButton = false;
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (Path.GetFileName(f.SelectedPath).StartsWith("FFXIV_CHR"))
                {
                    textBoxCharacterFolder.Text = f.SelectedPath;
                    controller.PartyListUI = Util.GetPartyListLocation(textBoxCharacterFolder.Text);
                }
                else
                {
                    MessageBox.Show("Please select a folder that starts with 'FFXIV_CHR'");
                }
            }
        }

        private void SetFontName()
        {
            comboBoxTPFont.Items.Add("PIRULEN");

            using (System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection())
            {
                FontFamily[] ffs = ifc.Families;

                foreach (FontFamily ff in ffs)
                {
                    if (ff.IsStyleAvailable(FontStyle.Regular))
                    {
                        comboBoxTPFont.Items.Add(ff.Name);
                    }
                }

                comboBoxTPFont.SelectedIndex = 0;
            }
        }

        private System.Drawing.Text.PrivateFontCollection pfc = null;
        private void comboBoxTPFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTPFont.SelectedIndex == -1) return;

            switch (comboBoxTPFont.SelectedIndex)
            {
                case 0:
                    if (pfc != null)
                    {
                        pfc.Dispose();
                        pfc = null;
                    }

                    //PrivateFontCollectionオブジェクトを作成する
                    pfc = new System.Drawing.Text.PrivateFontCollection();
                    byte[] fontBuf = null;
                    if (comboBoxTPFont.SelectedIndex == 0)
                    {
                        fontBuf = Properties.Resources.pirulen_rg;
                    }

                    IntPtr fontBufPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontBuf.Length);
                    System.Runtime.InteropServices.Marshal.Copy(fontBuf, 0, fontBufPtr, fontBuf.Length);

                    pfc.AddMemoryFont(fontBufPtr, fontBuf.Length);
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontBufPtr);

                    //PrivateFontCollectionの先頭のフォントのFontオブジェクトを作成する
                    System.Drawing.Font f = new System.Drawing.Font(pfc.Families[0], (int)numericUpDownFontSize.Value);

                    selectedFont = f;
                    break;
                default:
                    if (pfc != null) 
                    {
                        pfc.Dispose();
                        pfc = null; 
                    }

                    selectedFont = new Font(comboBoxTPFont.Text, (int)numericUpDownFontSize.Value);
                    break;
            }
            controller.TPFont = selectedFont;
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            comboBoxTPFont_SelectedIndexChanged(this, e);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxRecommend.Text);
        }

        private void checkBoxHideOnDissolve_CheckedChanged(object sender, EventArgs e)
        {
            if (controller != null) controller.HideOnDissolve = checkBoxHideOnDissolve.Checked;
        }

        private void checkBoxShowMyTP_CheckedChanged(object sender, EventArgs e)
        {
            if (controller != null) controller.ShowMyTP = checkBoxShowMyTP.Checked;
        }

        private void ChangedLocation(object sender, EventArgs e)
        {
            OnChangeLocation();
        }

        public class ChangeLocationEventArgs : EventArgs
        {
            public Point location;
        }

        public delegate void ChangeLocationEventHandler(object sender, ChangeLocationEventArgs e);
        public event ChangeLocationEventHandler ChangeLocation;
        public void OnChangeLocation()
        {
            if (ChangeLocation != null)
            {
                if (controller != null)
                {
                    controller.IsFixedMode = radioButtonFixed.Checked;
                    controller.OffsetX = numericUpDownOffsetX.Value;
                    controller.OffsetY = numericUpDownOffsetY.Value;
                    controller.FixedX = numericUpDownFixedX.Value;
                    controller.FixedY = numericUpDownFixedY.Value;

                    ChangeLocationEventArgs arg = new ChangeLocationEventArgs();
                    if (radioButtonOffset.Checked)
                    {
                        controller.PartyListUI = Util.GetPartyListLocation(textBoxCharacterFolder.Text);
                        arg.location = new Point(
                            controller.PartyListUI.Rect.Location.X + (int)numericUpDownOffsetX.Value,
                            controller.PartyListUI.Rect.Location.Y + (int)numericUpDownOffsetY.Value);
                    }
                    else if (radioButtonFixed.Checked)
                    {
                        arg.location = new Point((int)numericUpDownFixedX.Value, (int)numericUpDownFixedY.Value);
                    }

                    ChangeLocation(this, arg);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
