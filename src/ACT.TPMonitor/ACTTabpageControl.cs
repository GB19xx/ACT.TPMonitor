/* The CheckForUpdate() function is:
 * 
 * Copyright (c) 2014, grindingcoil
 * All rights reserved.
 * 
 * Originally under 3-clause BSD license, https://github.com/grindingcoil/act_timeline/blob/master/LICENSE.txt
 * 
 */
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACTTabpageControl));
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
            this.checkBoxHideWhenEnded = new System.Windows.Forms.CheckBox();
            this.checkBoxHideWhenDissolve = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.tabControlStyle = new System.Windows.Forms.TabControl();
            this.tabPagePartyList = new System.Windows.Forms.TabPage();
            this.radioButtonOffset = new System.Windows.Forms.RadioButton();
            this.radioButtonFixed = new System.Windows.Forms.RadioButton();
            this.numericUpDownOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFixedX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFixedY = new System.Windows.Forms.NumericUpDown();
            this.labelOffsetX = new System.Windows.Forms.Label();
            this.labelFixedX = new System.Windows.Forms.Label();
            this.labelOffsetY = new System.Windows.Forms.Label();
            this.labelFixedY = new System.Windows.Forms.Label();
            this.tabPageAlliance = new System.Windows.Forms.TabPage();
            this.numericUpDownAllianceX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAllianceY = new System.Windows.Forms.NumericUpDown();
            this.labelAllianceX = new System.Windows.Forms.Label();
            this.labelAllianceY = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupBoxScale = new System.Windows.Forms.GroupBox();
            this.checkBoxUserScale = new System.Windows.Forms.CheckBox();
            this.numericUpDownUserScale = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewColor = new System.Windows.Forms.DataGridView();
            this.ColumnStartTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDialog = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxWhereNow = new System.Windows.Forms.GroupBox();
            this.labelHereNowX = new System.Windows.Forms.Label();
            this.labelHereNowY = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxDisplayJob = new System.Windows.Forms.GroupBox();
            this.checkBoxNIN = new System.Windows.Forms.CheckBox();
            this.imageListJob = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxROG = new System.Windows.Forms.CheckBox();
            this.checkBoxSCH = new System.Windows.Forms.CheckBox();
            this.checkBoxSMN = new System.Windows.Forms.CheckBox();
            this.checkBoxACN = new System.Windows.Forms.CheckBox();
            this.checkBoxBLM = new System.Windows.Forms.CheckBox();
            this.checkBoxTHM = new System.Windows.Forms.CheckBox();
            this.checkBoxWHM = new System.Windows.Forms.CheckBox();
            this.checkBoxCNJ = new System.Windows.Forms.CheckBox();
            this.checkBoxBRD = new System.Windows.Forms.CheckBox();
            this.checkBoxARC = new System.Windows.Forms.CheckBox();
            this.checkBoxDRG = new System.Windows.Forms.CheckBox();
            this.checkBoxLNC = new System.Windows.Forms.CheckBox();
            this.checkBoxWAR = new System.Windows.Forms.CheckBox();
            this.checkBoxMRD = new System.Windows.Forms.CheckBox();
            this.checkBoxMNK = new System.Windows.Forms.CheckBox();
            this.checkBoxPGL = new System.Windows.Forms.CheckBox();
            this.checkBoxPLD = new System.Windows.Forms.CheckBox();
            this.checkBoxGLD = new System.Windows.Forms.CheckBox();
            this.imageListJobOff = new System.Windows.Forms.ImageList(this.components);
            this.textBoxColors = new System.Windows.Forms.TextBox();
            this.checkBoxAllianceStyle = new System.Windows.Forms.CheckBox();
            this.groupBoxUpdateCheck = new System.Windows.Forms.GroupBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.checkBoxDisappears = new System.Windows.Forms.CheckBox();
            this.groupBoxCharacterFolder.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tableLayoutPanelStatus.SuspendLayout();
            this.groupBoxFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.groupBoxRecommend.SuspendLayout();
            this.groupBoxOption.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.tabControlStyle.SuspendLayout();
            this.tabPagePartyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedY)).BeginInit();
            this.tabPageAlliance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllianceX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllianceY)).BeginInit();
            this.groupBoxScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColor)).BeginInit();
            this.groupBoxWhereNow.SuspendLayout();
            this.groupBoxDisplayJob.SuspendLayout();
            this.groupBoxUpdateCheck.SuspendLayout();
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
            this.groupBoxCharacterFolder.Location = new System.Drawing.Point(19, 12);
            this.groupBoxCharacterFolder.Name = "groupBoxCharacterFolder";
            this.groupBoxCharacterFolder.Size = new System.Drawing.Size(744, 54);
            this.groupBoxCharacterFolder.TabIndex = 0;
            this.groupBoxCharacterFolder.TabStop = false;
            this.groupBoxCharacterFolder.Text = "Character Folder";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.tableLayoutPanelStatus);
            this.groupBoxStatus.Location = new System.Drawing.Point(19, 72);
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
            this.groupBoxFont.Location = new System.Drawing.Point(769, 72);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(148, 70);
            this.groupBoxFont.TabIndex = 3;
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
            this.numericUpDownFontSize.TabStop = false;
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
            this.comboBoxTPFont.TabStop = false;
            this.comboBoxTPFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxTPFont_SelectedIndexChanged);
            // 
            // groupBoxRecommend
            // 
            this.groupBoxRecommend.Controls.Add(this.buttonCopy);
            this.groupBoxRecommend.Controls.Add(this.textBoxRecommend);
            this.groupBoxRecommend.Location = new System.Drawing.Point(615, 72);
            this.groupBoxRecommend.Name = "groupBoxRecommend";
            this.groupBoxRecommend.Size = new System.Drawing.Size(148, 172);
            this.groupBoxRecommend.TabIndex = 6;
            this.groupBoxRecommend.TabStop = false;
            this.groupBoxRecommend.Text = "Recommend Macro";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(15, 139);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(119, 23);
            this.buttonCopy.TabIndex = 1;
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
            this.textBoxRecommend.TabIndex = 0;
            this.textBoxRecommend.Text = "/e TP 2:<2>\r\n/e TP 3:<3>\r\n/e TP 4:<4>\r\n/e TP 5:<5>\r\n/e TP 6:<6>\r\n/e TP 7:<7>\r\n/e " +
    "TP 8:<8>\r\n/e TP /show";
            // 
            // groupBoxOption
            // 
            this.groupBoxOption.Controls.Add(this.checkBoxDisappears);
            this.groupBoxOption.Controls.Add(this.checkBoxShowMyTP);
            this.groupBoxOption.Controls.Add(this.checkBoxHideWhenEnded);
            this.groupBoxOption.Controls.Add(this.checkBoxHideWhenDissolve);
            this.groupBoxOption.Location = new System.Drawing.Point(317, 72);
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.Size = new System.Drawing.Size(292, 118);
            this.groupBoxOption.TabIndex = 2;
            this.groupBoxOption.TabStop = false;
            this.groupBoxOption.Text = "Option";
            // 
            // checkBoxShowMyTP
            // 
            this.checkBoxShowMyTP.AutoSize = true;
            this.checkBoxShowMyTP.Checked = true;
            this.checkBoxShowMyTP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMyTP.Location = new System.Drawing.Point(15, 66);
            this.checkBoxShowMyTP.Name = "checkBoxShowMyTP";
            this.checkBoxShowMyTP.Size = new System.Drawing.Size(184, 16);
            this.checkBoxShowMyTP.TabIndex = 2;
            this.checkBoxShowMyTP.Text = "Show my TP (Fixed mode only)";
            this.checkBoxShowMyTP.UseVisualStyleBackColor = true;
            this.checkBoxShowMyTP.CheckedChanged += new System.EventHandler(this.checkBoxShowMyTP_CheckedChanged);
            // 
            // checkBoxHideWhenEnded
            // 
            this.checkBoxHideWhenEnded.AutoSize = true;
            this.checkBoxHideWhenEnded.Checked = true;
            this.checkBoxHideWhenEnded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideWhenEnded.Location = new System.Drawing.Point(15, 44);
            this.checkBoxHideWhenEnded.Name = "checkBoxHideWhenEnded";
            this.checkBoxHideWhenEnded.Size = new System.Drawing.Size(128, 16);
            this.checkBoxHideWhenEnded.TabIndex = 1;
            this.checkBoxHideWhenEnded.Text = "Hide when ID ended.";
            this.checkBoxHideWhenEnded.UseVisualStyleBackColor = true;
            this.checkBoxHideWhenEnded.CheckedChanged += new System.EventHandler(this.checkBoxHideWhenEnded_CheckedChanged);
            // 
            // checkBoxHideWhenDissolve
            // 
            this.checkBoxHideWhenDissolve.AutoSize = true;
            this.checkBoxHideWhenDissolve.Checked = true;
            this.checkBoxHideWhenDissolve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideWhenDissolve.Location = new System.Drawing.Point(15, 22);
            this.checkBoxHideWhenDissolve.Name = "checkBoxHideWhenDissolve";
            this.checkBoxHideWhenDissolve.Size = new System.Drawing.Size(181, 16);
            this.checkBoxHideWhenDissolve.TabIndex = 0;
            this.checkBoxHideWhenDissolve.Text = "Hide when dissolved the party.";
            this.checkBoxHideWhenDissolve.UseVisualStyleBackColor = true;
            this.checkBoxHideWhenDissolve.CheckedChanged += new System.EventHandler(this.checkBoxHideWhenDissolve_CheckedChanged);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.tabControlStyle);
            this.groupBoxSettings.Controls.Add(this.buttonCancel);
            this.groupBoxSettings.Controls.Add(this.buttonApply);
            this.groupBoxSettings.Controls.Add(this.buttonDefault);
            this.groupBoxSettings.Controls.Add(this.groupBoxScale);
            this.groupBoxSettings.Controls.Add(this.dataGridViewColor);
            this.groupBoxSettings.Controls.Add(this.groupBoxWhereNow);
            this.groupBoxSettings.Location = new System.Drawing.Point(19, 308);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(744, 217);
            this.groupBoxSettings.TabIndex = 5;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // tabControlStyle
            // 
            this.tabControlStyle.Controls.Add(this.tabPagePartyList);
            this.tabControlStyle.Controls.Add(this.tabPageAlliance);
            this.tabControlStyle.Location = new System.Drawing.Point(6, 18);
            this.tabControlStyle.Name = "tabControlStyle";
            this.tabControlStyle.SelectedIndex = 0;
            this.tabControlStyle.Size = new System.Drawing.Size(286, 126);
            this.tabControlStyle.TabIndex = 10;
            this.tabControlStyle.SelectedIndexChanged += new System.EventHandler(this.tabControlStyle_SelectedIndexChanged);
            // 
            // tabPagePartyList
            // 
            this.tabPagePartyList.Controls.Add(this.radioButtonOffset);
            this.tabPagePartyList.Controls.Add(this.radioButtonFixed);
            this.tabPagePartyList.Controls.Add(this.numericUpDownOffsetX);
            this.tabPagePartyList.Controls.Add(this.numericUpDownOffsetY);
            this.tabPagePartyList.Controls.Add(this.numericUpDownFixedX);
            this.tabPagePartyList.Controls.Add(this.numericUpDownFixedY);
            this.tabPagePartyList.Controls.Add(this.labelOffsetX);
            this.tabPagePartyList.Controls.Add(this.labelFixedX);
            this.tabPagePartyList.Controls.Add(this.labelOffsetY);
            this.tabPagePartyList.Controls.Add(this.labelFixedY);
            this.tabPagePartyList.Location = new System.Drawing.Point(4, 22);
            this.tabPagePartyList.Name = "tabPagePartyList";
            this.tabPagePartyList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePartyList.Size = new System.Drawing.Size(278, 100);
            this.tabPagePartyList.TabIndex = 0;
            this.tabPagePartyList.Text = "Party List";
            this.tabPagePartyList.UseVisualStyleBackColor = true;
            // 
            // radioButtonOffset
            // 
            this.radioButtonOffset.AutoSize = true;
            this.radioButtonOffset.Checked = true;
            this.radioButtonOffset.Location = new System.Drawing.Point(5, 6);
            this.radioButtonOffset.Name = "radioButtonOffset";
            this.radioButtonOffset.Size = new System.Drawing.Size(55, 16);
            this.radioButtonOffset.TabIndex = 0;
            this.radioButtonOffset.TabStop = true;
            this.radioButtonOffset.Text = "Offset";
            this.radioButtonOffset.UseVisualStyleBackColor = true;
            this.radioButtonOffset.CheckedChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // radioButtonFixed
            // 
            this.radioButtonFixed.AutoSize = true;
            this.radioButtonFixed.Location = new System.Drawing.Point(5, 53);
            this.radioButtonFixed.Name = "radioButtonFixed";
            this.radioButtonFixed.Size = new System.Drawing.Size(82, 16);
            this.radioButtonFixed.TabIndex = 5;
            this.radioButtonFixed.Text = "Fixed Mode";
            this.radioButtonFixed.UseVisualStyleBackColor = true;
            this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // numericUpDownOffsetX
            // 
            this.numericUpDownOffsetX.Location = new System.Drawing.Point(53, 28);
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
            // numericUpDownOffsetY
            // 
            this.numericUpDownOffsetY.Location = new System.Drawing.Point(195, 28);
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
            // numericUpDownFixedX
            // 
            this.numericUpDownFixedX.Location = new System.Drawing.Point(53, 75);
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
            // numericUpDownFixedY
            // 
            this.numericUpDownFixedY.Location = new System.Drawing.Point(195, 75);
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
            // labelOffsetX
            // 
            this.labelOffsetX.AutoSize = true;
            this.labelOffsetX.Location = new System.Drawing.Point(33, 30);
            this.labelOffsetX.Name = "labelOffsetX";
            this.labelOffsetX.Size = new System.Drawing.Size(14, 12);
            this.labelOffsetX.TabIndex = 1;
            this.labelOffsetX.Text = "X:";
            // 
            // labelFixedX
            // 
            this.labelFixedX.AutoSize = true;
            this.labelFixedX.Location = new System.Drawing.Point(33, 77);
            this.labelFixedX.Name = "labelFixedX";
            this.labelFixedX.Size = new System.Drawing.Size(14, 12);
            this.labelFixedX.TabIndex = 6;
            this.labelFixedX.Text = "X:";
            // 
            // labelOffsetY
            // 
            this.labelOffsetY.AutoSize = true;
            this.labelOffsetY.Location = new System.Drawing.Point(175, 30);
            this.labelOffsetY.Name = "labelOffsetY";
            this.labelOffsetY.Size = new System.Drawing.Size(14, 12);
            this.labelOffsetY.TabIndex = 3;
            this.labelOffsetY.Text = "Y:";
            // 
            // labelFixedY
            // 
            this.labelFixedY.AutoSize = true;
            this.labelFixedY.Location = new System.Drawing.Point(175, 77);
            this.labelFixedY.Name = "labelFixedY";
            this.labelFixedY.Size = new System.Drawing.Size(14, 12);
            this.labelFixedY.TabIndex = 8;
            this.labelFixedY.Text = "Y:";
            // 
            // tabPageAlliance
            // 
            this.tabPageAlliance.Controls.Add(this.numericUpDownAllianceX);
            this.tabPageAlliance.Controls.Add(this.numericUpDownAllianceY);
            this.tabPageAlliance.Controls.Add(this.labelAllianceX);
            this.tabPageAlliance.Controls.Add(this.labelAllianceY);
            this.tabPageAlliance.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlliance.Name = "tabPageAlliance";
            this.tabPageAlliance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlliance.Size = new System.Drawing.Size(278, 100);
            this.tabPageAlliance.TabIndex = 1;
            this.tabPageAlliance.Text = "Alliance";
            this.tabPageAlliance.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAllianceX
            // 
            this.numericUpDownAllianceX.Location = new System.Drawing.Point(53, 28);
            this.numericUpDownAllianceX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAllianceX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownAllianceX.Name = "numericUpDownAllianceX";
            this.numericUpDownAllianceX.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownAllianceX.TabIndex = 6;
            this.numericUpDownAllianceX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAllianceX.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // numericUpDownAllianceY
            // 
            this.numericUpDownAllianceY.Location = new System.Drawing.Point(195, 28);
            this.numericUpDownAllianceY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAllianceY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownAllianceY.Name = "numericUpDownAllianceY";
            this.numericUpDownAllianceY.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownAllianceY.TabIndex = 8;
            this.numericUpDownAllianceY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAllianceY.ValueChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // labelAllianceX
            // 
            this.labelAllianceX.AutoSize = true;
            this.labelAllianceX.Location = new System.Drawing.Point(33, 30);
            this.labelAllianceX.Name = "labelAllianceX";
            this.labelAllianceX.Size = new System.Drawing.Size(14, 12);
            this.labelAllianceX.TabIndex = 5;
            this.labelAllianceX.Text = "X:";
            // 
            // labelAllianceY
            // 
            this.labelAllianceY.AutoSize = true;
            this.labelAllianceY.Location = new System.Drawing.Point(175, 30);
            this.labelAllianceY.Name = "labelAllianceY";
            this.labelAllianceY.Size = new System.Drawing.Size(14, 12);
            this.labelAllianceY.TabIndex = 7;
            this.labelAllianceY.Text = "Y:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(663, 188);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(582, 188);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 14;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(316, 188);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 13;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // groupBoxScale
            // 
            this.groupBoxScale.Controls.Add(this.checkBoxUserScale);
            this.groupBoxScale.Controls.Add(this.numericUpDownUserScale);
            this.groupBoxScale.Location = new System.Drawing.Point(6, 163);
            this.groupBoxScale.Name = "groupBoxScale";
            this.groupBoxScale.Size = new System.Drawing.Size(152, 48);
            this.groupBoxScale.TabIndex = 11;
            this.groupBoxScale.TabStop = false;
            // 
            // checkBoxUserScale
            // 
            this.checkBoxUserScale.AutoSize = true;
            this.checkBoxUserScale.Location = new System.Drawing.Point(6, -1);
            this.checkBoxUserScale.Name = "checkBoxUserScale";
            this.checkBoxUserScale.Size = new System.Drawing.Size(52, 16);
            this.checkBoxUserScale.TabIndex = 0;
            this.checkBoxUserScale.Text = "Scale";
            this.checkBoxUserScale.UseVisualStyleBackColor = true;
            this.checkBoxUserScale.CheckedChanged += new System.EventHandler(this.ChangedScale);
            // 
            // numericUpDownUserScale
            // 
            this.numericUpDownUserScale.Enabled = false;
            this.numericUpDownUserScale.Location = new System.Drawing.Point(48, 18);
            this.numericUpDownUserScale.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownUserScale.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownUserScale.Name = "numericUpDownUserScale";
            this.numericUpDownUserScale.Size = new System.Drawing.Size(71, 19);
            this.numericUpDownUserScale.TabIndex = 1;
            this.numericUpDownUserScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownUserScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownUserScale.ValueChanged += new System.EventHandler(this.ChangedScale);
            // 
            // dataGridViewColor
            // 
            this.dataGridViewColor.AllowUserToResizeColumns = false;
            this.dataGridViewColor.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this.dataGridViewColor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStartTP,
            this.ColumnEndTP,
            this.ColumnColor,
            this.ColumnDialog});
            this.dataGridViewColor.Location = new System.Drawing.Point(316, 18);
            this.dataGridViewColor.MultiSelect = false;
            this.dataGridViewColor.Name = "dataGridViewColor";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewColor.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewColor.RowTemplate.Height = 21;
            this.dataGridViewColor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewColor.Size = new System.Drawing.Size(422, 164);
            this.dataGridViewColor.TabIndex = 12;
            this.dataGridViewColor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewColor_CellContentClick);
            // 
            // ColumnStartTP
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.ColumnStartTP.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnStartTP.HeaderText = "StartTP";
            this.ColumnStartTP.Name = "ColumnStartTP";
            this.ColumnStartTP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnStartTP.Width = 80;
            // 
            // ColumnEndTP
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.ColumnEndTP.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnEndTP.HeaderText = "EndTP";
            this.ColumnEndTP.Name = "ColumnEndTP";
            this.ColumnEndTP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEndTP.Width = 80;
            // 
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "Color";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.ReadOnly = true;
            this.ColumnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDialog
            // 
            this.ColumnDialog.HeaderText = "";
            this.ColumnDialog.Name = "ColumnDialog";
            this.ColumnDialog.Text = "Edit Color";
            this.ColumnDialog.UseColumnTextForButtonValue = true;
            // 
            // groupBoxWhereNow
            // 
            this.groupBoxWhereNow.Controls.Add(this.labelHereNowX);
            this.groupBoxWhereNow.Controls.Add(this.labelHereNowY);
            this.groupBoxWhereNow.Location = new System.Drawing.Point(164, 163);
            this.groupBoxWhereNow.Name = "groupBoxWhereNow";
            this.groupBoxWhereNow.Size = new System.Drawing.Size(128, 48);
            this.groupBoxWhereNow.TabIndex = 10;
            this.groupBoxWhereNow.TabStop = false;
            this.groupBoxWhereNow.Text = "Where now?";
            // 
            // labelHereNowX
            // 
            this.labelHereNowX.AutoSize = true;
            this.labelHereNowX.Location = new System.Drawing.Point(17, 20);
            this.labelHereNowX.Name = "labelHereNowX";
            this.labelHereNowX.Size = new System.Drawing.Size(14, 12);
            this.labelHereNowX.TabIndex = 0;
            this.labelHereNowX.Text = "X:";
            // 
            // labelHereNowY
            // 
            this.labelHereNowY.AutoSize = true;
            this.labelHereNowY.Location = new System.Drawing.Point(70, 20);
            this.labelHereNowY.Name = "labelHereNowY";
            this.labelHereNowY.Size = new System.Drawing.Size(14, 12);
            this.labelHereNowY.TabIndex = 1;
            this.labelHereNowY.Text = "Y:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(688, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxDisplayJob
            // 
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxNIN);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxROG);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxSCH);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxSMN);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxACN);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxBLM);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxTHM);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxWHM);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxCNJ);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxBRD);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxARC);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxDRG);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxLNC);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxWAR);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxMRD);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxMNK);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxPGL);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxPLD);
            this.groupBoxDisplayJob.Controls.Add(this.checkBoxGLD);
            this.groupBoxDisplayJob.Location = new System.Drawing.Point(19, 196);
            this.groupBoxDisplayJob.Name = "groupBoxDisplayJob";
            this.groupBoxDisplayJob.Size = new System.Drawing.Size(590, 106);
            this.groupBoxDisplayJob.TabIndex = 4;
            this.groupBoxDisplayJob.TabStop = false;
            this.groupBoxDisplayJob.Text = "Display Job";
            // 
            // checkBoxNIN
            // 
            this.checkBoxNIN.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxNIN.AutoSize = true;
            this.checkBoxNIN.Checked = true;
            this.checkBoxNIN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNIN.ImageIndex = 19;
            this.checkBoxNIN.ImageList = this.imageListJob;
            this.checkBoxNIN.Location = new System.Drawing.Point(226, 62);
            this.checkBoxNIN.Name = "checkBoxNIN";
            this.checkBoxNIN.Size = new System.Drawing.Size(38, 38);
            this.checkBoxNIN.TabIndex = 11;
            this.checkBoxNIN.UseVisualStyleBackColor = true;
            this.checkBoxNIN.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // imageListJob
            // 
            this.imageListJob.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListJob.ImageStream")));
            this.imageListJob.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListJob.Images.SetKeyName(0, "noimage.png");
            this.imageListJob.Images.SetKeyName(1, "Gladiator.png");
            this.imageListJob.Images.SetKeyName(2, "Pugilist.png");
            this.imageListJob.Images.SetKeyName(3, "Marauder.png");
            this.imageListJob.Images.SetKeyName(4, "Lancer.png");
            this.imageListJob.Images.SetKeyName(5, "Archer.png");
            this.imageListJob.Images.SetKeyName(6, "Conjurer.png");
            this.imageListJob.Images.SetKeyName(7, "Thaumaturge.png");
            this.imageListJob.Images.SetKeyName(8, "Paladin.png");
            this.imageListJob.Images.SetKeyName(9, "Monk.png");
            this.imageListJob.Images.SetKeyName(10, "Warrior.png");
            this.imageListJob.Images.SetKeyName(11, "Dragoon.png");
            this.imageListJob.Images.SetKeyName(12, "Bard.png");
            this.imageListJob.Images.SetKeyName(13, "WhiteMage.png");
            this.imageListJob.Images.SetKeyName(14, "BlackMage.png");
            this.imageListJob.Images.SetKeyName(15, "Arcanist.png");
            this.imageListJob.Images.SetKeyName(16, "Summoner.png");
            this.imageListJob.Images.SetKeyName(17, "Scholar.png");
            this.imageListJob.Images.SetKeyName(18, "Rogue.png");
            this.imageListJob.Images.SetKeyName(19, "Ninja.png");
            // 
            // checkBoxROG
            // 
            this.checkBoxROG.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxROG.AutoSize = true;
            this.checkBoxROG.Checked = true;
            this.checkBoxROG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxROG.ImageIndex = 18;
            this.checkBoxROG.ImageList = this.imageListJob;
            this.checkBoxROG.Location = new System.Drawing.Point(226, 18);
            this.checkBoxROG.Name = "checkBoxROG";
            this.checkBoxROG.Size = new System.Drawing.Size(38, 38);
            this.checkBoxROG.TabIndex = 10;
            this.checkBoxROG.UseVisualStyleBackColor = true;
            this.checkBoxROG.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxSCH
            // 
            this.checkBoxSCH.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSCH.AutoSize = true;
            this.checkBoxSCH.Checked = true;
            this.checkBoxSCH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSCH.ImageIndex = 17;
            this.checkBoxSCH.ImageList = this.imageListJob;
            this.checkBoxSCH.Location = new System.Drawing.Point(402, 62);
            this.checkBoxSCH.Name = "checkBoxSCH";
            this.checkBoxSCH.Size = new System.Drawing.Size(38, 38);
            this.checkBoxSCH.TabIndex = 18;
            this.checkBoxSCH.UseVisualStyleBackColor = true;
            this.checkBoxSCH.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxSMN
            // 
            this.checkBoxSMN.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSMN.AutoSize = true;
            this.checkBoxSMN.Checked = true;
            this.checkBoxSMN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSMN.ImageIndex = 16;
            this.checkBoxSMN.ImageList = this.imageListJob;
            this.checkBoxSMN.Location = new System.Drawing.Point(358, 62);
            this.checkBoxSMN.Name = "checkBoxSMN";
            this.checkBoxSMN.Size = new System.Drawing.Size(38, 38);
            this.checkBoxSMN.TabIndex = 17;
            this.checkBoxSMN.UseVisualStyleBackColor = true;
            this.checkBoxSMN.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxACN
            // 
            this.checkBoxACN.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxACN.AutoSize = true;
            this.checkBoxACN.Checked = true;
            this.checkBoxACN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxACN.ImageIndex = 15;
            this.checkBoxACN.ImageList = this.imageListJob;
            this.checkBoxACN.Location = new System.Drawing.Point(358, 18);
            this.checkBoxACN.Name = "checkBoxACN";
            this.checkBoxACN.Size = new System.Drawing.Size(38, 38);
            this.checkBoxACN.TabIndex = 16;
            this.checkBoxACN.UseVisualStyleBackColor = true;
            this.checkBoxACN.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxBLM
            // 
            this.checkBoxBLM.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBLM.AutoSize = true;
            this.checkBoxBLM.Checked = true;
            this.checkBoxBLM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBLM.ImageIndex = 14;
            this.checkBoxBLM.ImageList = this.imageListJob;
            this.checkBoxBLM.Location = new System.Drawing.Point(314, 62);
            this.checkBoxBLM.Name = "checkBoxBLM";
            this.checkBoxBLM.Size = new System.Drawing.Size(38, 38);
            this.checkBoxBLM.TabIndex = 15;
            this.checkBoxBLM.UseVisualStyleBackColor = true;
            this.checkBoxBLM.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxTHM
            // 
            this.checkBoxTHM.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTHM.AutoSize = true;
            this.checkBoxTHM.Checked = true;
            this.checkBoxTHM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTHM.ImageIndex = 7;
            this.checkBoxTHM.ImageList = this.imageListJob;
            this.checkBoxTHM.Location = new System.Drawing.Point(314, 18);
            this.checkBoxTHM.Name = "checkBoxTHM";
            this.checkBoxTHM.Size = new System.Drawing.Size(38, 38);
            this.checkBoxTHM.TabIndex = 14;
            this.checkBoxTHM.UseVisualStyleBackColor = true;
            this.checkBoxTHM.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxWHM
            // 
            this.checkBoxWHM.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxWHM.AutoSize = true;
            this.checkBoxWHM.Checked = true;
            this.checkBoxWHM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWHM.ImageIndex = 13;
            this.checkBoxWHM.ImageList = this.imageListJob;
            this.checkBoxWHM.Location = new System.Drawing.Point(270, 62);
            this.checkBoxWHM.Name = "checkBoxWHM";
            this.checkBoxWHM.Size = new System.Drawing.Size(38, 38);
            this.checkBoxWHM.TabIndex = 13;
            this.checkBoxWHM.UseVisualStyleBackColor = true;
            this.checkBoxWHM.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxCNJ
            // 
            this.checkBoxCNJ.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCNJ.AutoSize = true;
            this.checkBoxCNJ.Checked = true;
            this.checkBoxCNJ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCNJ.ImageIndex = 6;
            this.checkBoxCNJ.ImageList = this.imageListJob;
            this.checkBoxCNJ.Location = new System.Drawing.Point(270, 18);
            this.checkBoxCNJ.Name = "checkBoxCNJ";
            this.checkBoxCNJ.Size = new System.Drawing.Size(38, 38);
            this.checkBoxCNJ.TabIndex = 12;
            this.checkBoxCNJ.UseVisualStyleBackColor = true;
            this.checkBoxCNJ.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxBRD
            // 
            this.checkBoxBRD.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBRD.AutoSize = true;
            this.checkBoxBRD.Checked = true;
            this.checkBoxBRD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBRD.ImageIndex = 12;
            this.checkBoxBRD.ImageList = this.imageListJob;
            this.checkBoxBRD.Location = new System.Drawing.Point(182, 62);
            this.checkBoxBRD.Name = "checkBoxBRD";
            this.checkBoxBRD.Size = new System.Drawing.Size(38, 38);
            this.checkBoxBRD.TabIndex = 9;
            this.checkBoxBRD.UseVisualStyleBackColor = true;
            this.checkBoxBRD.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxARC
            // 
            this.checkBoxARC.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxARC.AutoSize = true;
            this.checkBoxARC.Checked = true;
            this.checkBoxARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxARC.ImageIndex = 5;
            this.checkBoxARC.ImageList = this.imageListJob;
            this.checkBoxARC.Location = new System.Drawing.Point(182, 18);
            this.checkBoxARC.Name = "checkBoxARC";
            this.checkBoxARC.Size = new System.Drawing.Size(38, 38);
            this.checkBoxARC.TabIndex = 8;
            this.checkBoxARC.UseVisualStyleBackColor = true;
            this.checkBoxARC.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxDRG
            // 
            this.checkBoxDRG.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxDRG.AutoSize = true;
            this.checkBoxDRG.Checked = true;
            this.checkBoxDRG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDRG.ImageIndex = 11;
            this.checkBoxDRG.ImageList = this.imageListJob;
            this.checkBoxDRG.Location = new System.Drawing.Point(138, 62);
            this.checkBoxDRG.Name = "checkBoxDRG";
            this.checkBoxDRG.Size = new System.Drawing.Size(38, 38);
            this.checkBoxDRG.TabIndex = 7;
            this.checkBoxDRG.UseVisualStyleBackColor = true;
            this.checkBoxDRG.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxLNC
            // 
            this.checkBoxLNC.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLNC.AutoSize = true;
            this.checkBoxLNC.Checked = true;
            this.checkBoxLNC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLNC.ImageIndex = 4;
            this.checkBoxLNC.ImageList = this.imageListJob;
            this.checkBoxLNC.Location = new System.Drawing.Point(138, 18);
            this.checkBoxLNC.Name = "checkBoxLNC";
            this.checkBoxLNC.Size = new System.Drawing.Size(38, 38);
            this.checkBoxLNC.TabIndex = 6;
            this.checkBoxLNC.UseVisualStyleBackColor = true;
            this.checkBoxLNC.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxWAR
            // 
            this.checkBoxWAR.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxWAR.AutoSize = true;
            this.checkBoxWAR.Checked = true;
            this.checkBoxWAR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWAR.ImageIndex = 10;
            this.checkBoxWAR.ImageList = this.imageListJob;
            this.checkBoxWAR.Location = new System.Drawing.Point(50, 62);
            this.checkBoxWAR.Name = "checkBoxWAR";
            this.checkBoxWAR.Size = new System.Drawing.Size(38, 38);
            this.checkBoxWAR.TabIndex = 3;
            this.checkBoxWAR.UseVisualStyleBackColor = true;
            this.checkBoxWAR.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxMRD
            // 
            this.checkBoxMRD.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxMRD.AutoSize = true;
            this.checkBoxMRD.Checked = true;
            this.checkBoxMRD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMRD.ImageIndex = 3;
            this.checkBoxMRD.ImageList = this.imageListJob;
            this.checkBoxMRD.Location = new System.Drawing.Point(50, 18);
            this.checkBoxMRD.Name = "checkBoxMRD";
            this.checkBoxMRD.Size = new System.Drawing.Size(38, 38);
            this.checkBoxMRD.TabIndex = 2;
            this.checkBoxMRD.UseVisualStyleBackColor = true;
            this.checkBoxMRD.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxMNK
            // 
            this.checkBoxMNK.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxMNK.AutoSize = true;
            this.checkBoxMNK.Checked = true;
            this.checkBoxMNK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMNK.ImageIndex = 9;
            this.checkBoxMNK.ImageList = this.imageListJob;
            this.checkBoxMNK.Location = new System.Drawing.Point(94, 62);
            this.checkBoxMNK.Name = "checkBoxMNK";
            this.checkBoxMNK.Size = new System.Drawing.Size(38, 38);
            this.checkBoxMNK.TabIndex = 5;
            this.checkBoxMNK.UseVisualStyleBackColor = true;
            this.checkBoxMNK.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxPGL
            // 
            this.checkBoxPGL.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPGL.AutoSize = true;
            this.checkBoxPGL.Checked = true;
            this.checkBoxPGL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPGL.ImageIndex = 2;
            this.checkBoxPGL.ImageList = this.imageListJob;
            this.checkBoxPGL.Location = new System.Drawing.Point(94, 18);
            this.checkBoxPGL.Name = "checkBoxPGL";
            this.checkBoxPGL.Size = new System.Drawing.Size(38, 38);
            this.checkBoxPGL.TabIndex = 4;
            this.checkBoxPGL.UseVisualStyleBackColor = true;
            this.checkBoxPGL.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxPLD
            // 
            this.checkBoxPLD.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPLD.AutoSize = true;
            this.checkBoxPLD.Checked = true;
            this.checkBoxPLD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPLD.ImageIndex = 8;
            this.checkBoxPLD.ImageList = this.imageListJob;
            this.checkBoxPLD.Location = new System.Drawing.Point(6, 62);
            this.checkBoxPLD.Name = "checkBoxPLD";
            this.checkBoxPLD.Size = new System.Drawing.Size(38, 38);
            this.checkBoxPLD.TabIndex = 1;
            this.checkBoxPLD.UseVisualStyleBackColor = true;
            this.checkBoxPLD.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // checkBoxGLD
            // 
            this.checkBoxGLD.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxGLD.AutoSize = true;
            this.checkBoxGLD.Checked = true;
            this.checkBoxGLD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGLD.ImageIndex = 1;
            this.checkBoxGLD.ImageList = this.imageListJob;
            this.checkBoxGLD.Location = new System.Drawing.Point(6, 18);
            this.checkBoxGLD.Name = "checkBoxGLD";
            this.checkBoxGLD.Size = new System.Drawing.Size(38, 38);
            this.checkBoxGLD.TabIndex = 0;
            this.checkBoxGLD.UseVisualStyleBackColor = true;
            this.checkBoxGLD.CheckedChanged += new System.EventHandler(this.checkBoxJob_CheckedChanged);
            // 
            // imageListJobOff
            // 
            this.imageListJobOff.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListJobOff.ImageStream")));
            this.imageListJobOff.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListJobOff.Images.SetKeyName(0, "noimage.png");
            this.imageListJobOff.Images.SetKeyName(1, "Gladiator_off.png");
            this.imageListJobOff.Images.SetKeyName(2, "Pugilist_off.png");
            this.imageListJobOff.Images.SetKeyName(3, "Marauder_off.png");
            this.imageListJobOff.Images.SetKeyName(4, "Lancer_off.png");
            this.imageListJobOff.Images.SetKeyName(5, "Archer_off.png");
            this.imageListJobOff.Images.SetKeyName(6, "Conjurer_off.png");
            this.imageListJobOff.Images.SetKeyName(7, "Thaumaturge_off.png");
            this.imageListJobOff.Images.SetKeyName(8, "Paladin_off.png");
            this.imageListJobOff.Images.SetKeyName(9, "Monk_off.png");
            this.imageListJobOff.Images.SetKeyName(10, "Warrior_off.png");
            this.imageListJobOff.Images.SetKeyName(11, "Dragoon_off.png");
            this.imageListJobOff.Images.SetKeyName(12, "Bard_off.png");
            this.imageListJobOff.Images.SetKeyName(13, "WhiteMage_off.png");
            this.imageListJobOff.Images.SetKeyName(14, "BlackMage_off.png");
            this.imageListJobOff.Images.SetKeyName(15, "Arcanist_off.png");
            this.imageListJobOff.Images.SetKeyName(16, "Summoner_off.png");
            this.imageListJobOff.Images.SetKeyName(17, "Scholar_off.png");
            this.imageListJobOff.Images.SetKeyName(18, "Rogue_off.png");
            this.imageListJobOff.Images.SetKeyName(19, "Ninja_off.png");
            // 
            // textBoxColors
            // 
            this.textBoxColors.Location = new System.Drawing.Point(769, 380);
            this.textBoxColors.Name = "textBoxColors";
            this.textBoxColors.Size = new System.Drawing.Size(100, 19);
            this.textBoxColors.TabIndex = 8;
            this.textBoxColors.TabStop = false;
            this.textBoxColors.Visible = false;
            // 
            // checkBoxAllianceStyle
            // 
            this.checkBoxAllianceStyle.AutoSize = true;
            this.checkBoxAllianceStyle.Location = new System.Drawing.Point(769, 405);
            this.checkBoxAllianceStyle.Name = "checkBoxAllianceStyle";
            this.checkBoxAllianceStyle.Size = new System.Drawing.Size(91, 16);
            this.checkBoxAllianceStyle.TabIndex = 10;
            this.checkBoxAllianceStyle.TabStop = false;
            this.checkBoxAllianceStyle.Text = "AllianceStyle";
            this.checkBoxAllianceStyle.UseVisualStyleBackColor = true;
            this.checkBoxAllianceStyle.Visible = false;
            this.checkBoxAllianceStyle.CheckedChanged += new System.EventHandler(this.ChangedLocation);
            // 
            // groupBoxUpdateCheck
            // 
            this.groupBoxUpdateCheck.Controls.Add(this.buttonCheck);
            this.groupBoxUpdateCheck.Location = new System.Drawing.Point(769, 12);
            this.groupBoxUpdateCheck.Name = "groupBoxUpdateCheck";
            this.groupBoxUpdateCheck.Size = new System.Drawing.Size(148, 54);
            this.groupBoxUpdateCheck.TabIndex = 11;
            this.groupBoxUpdateCheck.TabStop = false;
            this.groupBoxUpdateCheck.Text = "Update Check";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(37, 18);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 0;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // checkBoxDisappears
            // 
            this.checkBoxDisappears.AutoSize = true;
            this.checkBoxDisappears.Checked = true;
            this.checkBoxDisappears.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisappears.Location = new System.Drawing.Point(15, 88);
            this.checkBoxDisappears.Name = "checkBoxDisappears";
            this.checkBoxDisappears.Size = new System.Drawing.Size(260, 16);
            this.checkBoxDisappears.TabIndex = 2;
            this.checkBoxDisappears.Text = "Disappears when the game window is inactive";
            this.checkBoxDisappears.UseVisualStyleBackColor = true;
            this.checkBoxDisappears.CheckedChanged += new System.EventHandler(this.checkBoxDisappears_CheckedChanged);
            // 
            // ACTTabpageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUpdateCheck);
            this.Controls.Add(this.checkBoxAllianceStyle);
            this.Controls.Add(this.textBoxColors);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxDisplayJob);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxOption);
            this.Controls.Add(this.groupBoxFont);
            this.Controls.Add(this.groupBoxRecommend);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxCharacterFolder);
            this.Name = "ACTTabpageControl";
            this.Size = new System.Drawing.Size(950, 539);
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
            this.groupBoxSettings.ResumeLayout(false);
            this.tabControlStyle.ResumeLayout(false);
            this.tabPagePartyList.ResumeLayout(false);
            this.tabPagePartyList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFixedY)).EndInit();
            this.tabPageAlliance.ResumeLayout(false);
            this.tabPageAlliance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllianceX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllianceY)).EndInit();
            this.groupBoxScale.ResumeLayout(false);
            this.groupBoxScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUserScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColor)).EndInit();
            this.groupBoxWhereNow.ResumeLayout(false);
            this.groupBoxWhereNow.PerformLayout();
            this.groupBoxDisplayJob.ResumeLayout(false);
            this.groupBoxDisplayJob.PerformLayout();
            this.groupBoxUpdateCheck.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        #endregion

        public ACTTabpageControl()
		{
			InitializeComponent();

            textBoxCharacterFolder.Text = (Directory.GetDirectories(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"My Games\FINAL FANTASY XIV - A Realm Reborn")), @"FFXIV_*"))[0]; 
            comboBoxTPFont.Text = "PIRULEN";

            checkBoxGLD.Tag = JOB.GLD;
            checkBoxPGL.Tag = JOB.PGL;
            checkBoxMRD.Tag = JOB.MRD;
            checkBoxLNC.Tag = JOB.LNC;
            checkBoxARC.Tag = JOB.ARC;
            checkBoxCNJ.Tag = JOB.CNJ;
            checkBoxTHM.Tag = JOB.THM;
            checkBoxPLD.Tag = JOB.PLD;
            checkBoxMNK.Tag = JOB.MNK;
            checkBoxWAR.Tag = JOB.WAR;
            checkBoxDRG.Tag = JOB.DRG;
            checkBoxBRD.Tag = JOB.BRD;
            checkBoxWHM.Tag = JOB.WHM;
            checkBoxBLM.Tag = JOB.BLM;
            checkBoxACN.Tag = JOB.ACN;
            checkBoxSMN.Tag = JOB.SMN;
            checkBoxSCH.Tag = JOB.SCH;
            checkBoxROG.Tag = JOB.ROG;
            checkBoxNIN.Tag = JOB.NIN;
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
        private CheckBox checkBoxHideWhenDissolve;
        private Button buttonCopy;
        private GroupBox groupBoxSettings;
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
        private GroupBox groupBoxDisplayJob;
        private ImageList imageListJob;
        private ImageList imageListJobOff;
        private CheckBox checkBoxGLD;
        private CheckBox checkBoxPGL;
        private CheckBox checkBoxMRD;
        private CheckBox checkBoxLNC;
        private CheckBox checkBoxARC;
        private CheckBox checkBoxCNJ;
        private CheckBox checkBoxTHM;
        private CheckBox checkBoxPLD;
        private CheckBox checkBoxMNK;
        private CheckBox checkBoxWAR;
        private CheckBox checkBoxDRG;
        private CheckBox checkBoxBRD;
        private CheckBox checkBoxWHM;
        private CheckBox checkBoxBLM;
        private CheckBox checkBoxACN;
        private CheckBox checkBoxSMN;
        private CheckBox checkBoxSCH;
        private Font selectedFont;
        private CheckBox checkBoxHideWhenEnded;
        private DataGridView dataGridViewColor;
        private Button buttonCancel;
        private Button buttonApply;
        private Button buttonDefault;
        private GroupBox groupBoxScale;
        private TextBox textBoxColors;
        private List<JOB> hideJob = new List<JOB>();
        private CheckBox checkBoxUserScale;
        private NumericUpDown numericUpDownUserScale;
        private DataGridViewTextBoxColumn ColumnStartTP;
        private DataGridViewTextBoxColumn ColumnEndTP;
        private DataGridViewTextBoxColumn ColumnColor;
        private DataGridViewButtonColumn ColumnDialog;
        private TabControl tabControlStyle;
        private TabPage tabPagePartyList;
        private TabPage tabPageAlliance;
        private NumericUpDown numericUpDownAllianceX;
        private NumericUpDown numericUpDownAllianceY;
        private Label labelAllianceX;
        private Label labelAllianceY;
        private CheckBox checkBoxAllianceStyle;
        private CheckBox checkBoxNIN;
        private CheckBox checkBoxROG;
        private GroupBox groupBoxUpdateCheck;
        private Button buttonCheck;
        private CheckBox checkBoxDisappears;
        private DataTable dtColor = new DataTable();

		#region IActPluginV1 Members
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
            ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(CheckForUpdate);
            if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())   // If ACT is set to automatically check for updates, check for updates to the plugin
                new Thread(new ThreadStart(CheckForUpdate)).Start();    // If we don't put this on a separate thread, web latency will delay the plugin init phase
            
            pluginScreenSpace.Text = "TPMonitor";
            lblStatus = pluginStatusText;	        // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);	// Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill;	            // Expand the UserControl to fill the tab's client space            

            controller = new TPMonitorController(this);
            
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

            controller.CharFolder = textBoxCharacterFolder.Text;
            controller.HideWhenDissolve = checkBoxHideWhenDissolve.Checked;
            controller.HideWhenEnded = checkBoxHideWhenEnded.Checked;
            controller.ShowMyTP = checkBoxShowMyTP.Checked;
            controller.IsFixedMode = radioButtonFixed.Checked;
            controller.ChangedStatus += new EventHandler(this.ChangedStatus);
            OnChangeLocation();
            SetFontName();

            if (string.IsNullOrEmpty(textBoxColors.Text))
            {
                SetDefaultColor();
                dtColor = GetDataTable();
            }
            SetColorSetting();
            buttonApply_Click(this, null);

            lblStatus.Text = "Plugin Started.";
        }

        public void DeInitPlugin()
		{
            ActGlobals.oFormActMain.UpdateCheckClicked -= CheckForUpdate;

			SaveSettings();
            if (pfc != null) pfc.Dispose();

            controller.Dispose();

            lblStatus.Text = "Plugin Exited.";
		}
		#endregion

        private void CheckForUpdate()
        {
            AutoUpdater.PluginDate = ActGlobals.oFormActMain.PluginGetSelfData(this);
            AutoUpdater.Owner = "GB19xx";
            AutoUpdater.RepositoryName = "ACT.TPMonitor";
#if DEBUG
            AutoUpdater.RepositoryName = "TestRepository";
#endif
            AutoUpdater.IsCoverdPreRelease = false;
            AutoUpdater.Start();
        }

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

        #region Config Settings
        private void LoadSettings()
		{
            xmlSettings.AddControlSetting(textBoxCharacterFolder.Name, textBoxCharacterFolder);
            xmlSettings.AddControlSetting(comboBoxTPFont.Name, comboBoxTPFont);
            xmlSettings.AddControlSetting(numericUpDownFontSize.Name, numericUpDownFontSize);
            xmlSettings.AddControlSetting(checkBoxHideWhenDissolve.Name, checkBoxHideWhenDissolve);
            xmlSettings.AddControlSetting(checkBoxHideWhenEnded.Name, checkBoxHideWhenEnded);
            xmlSettings.AddControlSetting(checkBoxShowMyTP.Name, checkBoxShowMyTP);
            xmlSettings.AddControlSetting(checkBoxDisappears.Name, checkBoxDisappears);
            xmlSettings.AddControlSetting(radioButtonFixed.Name, radioButtonFixed);
            xmlSettings.AddControlSetting(numericUpDownOffsetX.Name, numericUpDownOffsetX);
            xmlSettings.AddControlSetting(numericUpDownOffsetY.Name, numericUpDownOffsetY);
            xmlSettings.AddControlSetting(numericUpDownFixedX.Name, numericUpDownFixedX);
            xmlSettings.AddControlSetting(numericUpDownFixedY.Name, numericUpDownFixedY);
            xmlSettings.AddControlSetting(checkBoxAllianceStyle.Name, checkBoxAllianceStyle);
            xmlSettings.AddControlSetting(numericUpDownAllianceX.Name, numericUpDownAllianceX);
            xmlSettings.AddControlSetting(numericUpDownAllianceY.Name, numericUpDownAllianceY);

            xmlSettings.AddControlSetting(textBoxColors.Name, textBoxColors);
            xmlSettings.AddControlSetting(checkBoxUserScale.Name, checkBoxUserScale);
            xmlSettings.AddControlSetting(numericUpDownUserScale.Name, numericUpDownUserScale);

            xmlSettings.AddControlSetting(checkBoxGLD.Name, checkBoxGLD);
            xmlSettings.AddControlSetting(checkBoxPGL.Name, checkBoxPGL);
            xmlSettings.AddControlSetting(checkBoxMRD.Name, checkBoxMRD);
            xmlSettings.AddControlSetting(checkBoxLNC.Name, checkBoxLNC);
            xmlSettings.AddControlSetting(checkBoxARC.Name, checkBoxARC);
            xmlSettings.AddControlSetting(checkBoxCNJ.Name, checkBoxCNJ);
            xmlSettings.AddControlSetting(checkBoxTHM.Name, checkBoxTHM);
            xmlSettings.AddControlSetting(checkBoxPLD.Name, checkBoxPLD);
            xmlSettings.AddControlSetting(checkBoxMNK.Name, checkBoxMNK);
            xmlSettings.AddControlSetting(checkBoxWAR.Name, checkBoxWAR);
            xmlSettings.AddControlSetting(checkBoxDRG.Name, checkBoxDRG);
            xmlSettings.AddControlSetting(checkBoxBRD.Name, checkBoxBRD);
            xmlSettings.AddControlSetting(checkBoxWHM.Name, checkBoxWHM);
            xmlSettings.AddControlSetting(checkBoxBLM.Name, checkBoxBLM);
            xmlSettings.AddControlSetting(checkBoxACN.Name, checkBoxACN);
            xmlSettings.AddControlSetting(checkBoxSMN.Name, checkBoxSMN);
            xmlSettings.AddControlSetting(checkBoxSCH.Name, checkBoxSCH);
            xmlSettings.AddControlSetting(checkBoxROG.Name, checkBoxROG);
            xmlSettings.AddControlSetting(checkBoxNIN.Name, checkBoxNIN);

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
        #endregion

        #region Font Settings
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
        #endregion

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
        
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxRecommend.Text);
        }

        private void tabControlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxAllianceStyle.Checked = tabControlStyle.SelectedIndex == 0 ? false : true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #region Options
        private void checkBoxHideWhenDissolve_CheckedChanged(object sender, EventArgs e)
        {
            controller.HideWhenDissolve = checkBoxHideWhenDissolve.Checked;
        }

        private void checkBoxHideWhenEnded_CheckedChanged(object sender, EventArgs e)
        {
            controller.HideWhenEnded = checkBoxHideWhenEnded.Checked;
        }

        private void checkBoxShowMyTP_CheckedChanged(object sender, EventArgs e)
        {
            controller.ShowMyTP = checkBoxShowMyTP.Checked;
        }

        private void checkBoxDisappears_CheckedChanged(object sender, EventArgs e)
        {
            controller.DisappearsInActive = checkBoxDisappears.Checked;
        }
        #endregion

        #region Change Location 
        private void ChangedLocation(object sender, EventArgs e)
        {
            OnChangeLocation();
        }

        public class ChangeLocationEventArgs : EventArgs
        {
            public Point Location;
        }

        public delegate void ChangeLocationEventHandler(object sender, ChangeLocationEventArgs e);
        public event ChangeLocationEventHandler ChangeLocation;
        public void OnChangeLocation()
        {
            if (ChangeLocation != null)
            {
                controller.IsFixedMode = radioButtonFixed.Checked;
                controller.OffsetX = numericUpDownOffsetX.Value;
                controller.OffsetY = numericUpDownOffsetY.Value;
                controller.FixedX = numericUpDownFixedX.Value;
                controller.FixedY = numericUpDownFixedY.Value;
                controller.IsAllianceStyle = checkBoxAllianceStyle.Checked;
                controller.AllianceX = numericUpDownAllianceX.Value;
                controller.AllianceY = numericUpDownAllianceY.Value;

                ChangeLocationEventArgs arg = new ChangeLocationEventArgs();
                if (checkBoxAllianceStyle.Checked)
                {
                    tabControlStyle.SelectedIndex = 1;
                    arg.Location = new Point((int)numericUpDownAllianceX.Value, (int)numericUpDownAllianceY.Value);
                }
                else
                {
                    tabControlStyle.SelectedIndex = 0;
                    if (radioButtonOffset.Checked)
                    {
                        controller.PartyListUI = Util.GetPartyListLocation(textBoxCharacterFolder.Text);
                        arg.Location = new Point(
                            controller.PartyListUI.Rect.Location.X + (int)numericUpDownOffsetX.Value,
                            controller.PartyListUI.Rect.Location.Y + (int)numericUpDownOffsetY.Value);
                    }
                    else if (radioButtonFixed.Checked)
                    {
                        arg.Location = new Point((int)numericUpDownFixedX.Value, (int)numericUpDownFixedY.Value);
                    }
                }

                ChangeLocation(this, arg);
            }
        }
        #endregion

        #region Job Settings
        private void checkBoxJob_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkJob = (CheckBox)sender;

            if (chkJob.Checked)
            {
                chkJob.ImageList = imageListJob;
                controller.HideJob.Remove((JOB)chkJob.Tag);
            }
            else
            {
                chkJob.ImageList = imageListJobOff;
                controller.HideJob.Add((JOB)chkJob.Tag);
            }
        }
        #endregion

        #region Color Settings
        private void SetDefaultColor()
        {
            textBoxColors.Text = "0:1000:White";
        }

        private void SetColorSetting()
        {
            dataGridViewColor.Rows.Clear();
            string[] rows = textBoxColors.Text.Split('|');
            for (int i = 0; i < rows.Length; i++)
            {
                dataGridViewColor.Rows.Insert(i, rows[i].Split(':'));
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            SetDefaultColor();
            SetColorSetting();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataGridViewColor.Rows.Count - 1; i++)
            {
                sb.Append(dataGridViewColor[0, i].Value + ":");     //StartTP
                sb.Append(dataGridViewColor[1, i].Value + ":");     //EndTP
                sb.Append(dataGridViewColor[2, i].Value + "|");     //Color
            }

            if (sb.Length != 0)
            {
                sb.Remove(sb.Length - 1, 1);
                textBoxColors.Text = sb.ToString();
            }
            else
            {
                textBoxColors.Text = string.Empty;
            }

            dtColor = GetDataTable();
            controller.dtColor = dtColor;
        }
        
        private bool CheckInput()
        {
            int checkValue;
            DataGridView dgv = dataGridViewColor;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in dgv.Rows[row.Index].Cells)
                {
                    switch (cell.ColumnIndex)
                    {
                        case 0:
                        case 1:
                            if (cell.Value == null || cell.Value.ToString() == "")
                            {
                                dgv.Rows[row.Index].ErrorText = "Eter a value in all cells.";
                                return false;
                            }
                            else if (!int.TryParse(cell.Value.ToString(), out checkValue))
                            {
                                dgv.Rows[row.Index].ErrorText = "Valid only numbers.";
                                return false;
                            }

                            if (cell.ColumnIndex == 0)
                            {
                                if (row.Index > 0 &&
                                    int.Parse(dgv[0, row.Index].Value.ToString()) < int.Parse(dgv[1, row.Index - 1].Value.ToString()))
                                {
                                    dgv.Rows[row.Index].ErrorText = "Intersects the EndTP of another row.";
                                    return false;
                                }
                            }
                            else
                            {
                                if (cell.ColumnIndex == 1 &&
                                    int.Parse(dgv[0, row.Index].Value.ToString()) >= int.Parse(dgv[1, row.Index].Value.ToString()))
                                {
                                    dgv.Rows[row.Index].ErrorText = "Must have StartTP < EndTP.";
                                    return false;
                                }
                            }
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                }
                dgv.Rows[row.Index].ErrorText = null;
            }
            return true;
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            var cols = dataGridViewColor.Columns;
            foreach (DataGridViewColumn c in cols)
            {
                if (c.ValueType != null)
                {
                    dt.Columns.Add(c.Name, c.ValueType);
                }
                else
                {
                    dt.Columns.Add(c.Name);
                }
            }

            var rows = dataGridViewColor.Rows;
            foreach (DataGridViewRow r in rows)
            {
                List<object> array = new List<object>();
                foreach (DataGridViewCell cell in r.Cells)
                {
                    array.Add(cell.Value);
                }
                dt.Rows.Add(array.ToArray());
            }
            return dt;
        }

        private void dataGridViewColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "ColumnDialog")
            {
                ColorDialog diag = new ColorDialog();
                if (dgv[2, e.RowIndex].Value == null || dgv[2, e.RowIndex].Value.ToString() == "")
                    diag.Color = Color.White;
                else
                    diag.Color = Color.FromName(dgv[2, e.RowIndex].Value.ToString());

                if (diag.ShowDialog(this) == DialogResult.OK)
                {
                    if (diag.Color.IsNamedColor)
                        dgv[2, e.RowIndex].Value = diag.Color.Name;
                    else
                        dgv[2, e.RowIndex].Value = string.Format("{0}, {1}, {2}", diag.Color.R, diag.Color.G, diag.Color.B);
                }                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SetColorSetting();
        }
        #endregion

        #region Change Scale
        private void ChangedScale(object sender, EventArgs e)
        {
            OnChangeScale();
        }

        public class ChangeScaleEventArgs : EventArgs
        {
            public float Scale;
        }

        public delegate void ChangeScaleEventHandler(object sender, ChangeScaleEventArgs e);
        public event ChangeScaleEventHandler ChangeScale;
        public void OnChangeScale()
        {
            numericUpDownUserScale.Enabled = checkBoxUserScale.Checked;
            controller.IsUserScale = checkBoxUserScale.Checked;

            float scale = (float)numericUpDownUserScale.Value / 100;
            controller.UserScale = scale;

            if (lblStatus.Text.Equals("Plugin Started.") && ChangeScale != null)
            {
                ChangeScaleEventArgs arg = new ChangeScaleEventArgs();
                arg.Scale = scale;
                ChangeScale(this, arg);
            }
        }
        #endregion

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            AutoUpdater.IsCoverdPreRelease = true;
            AutoUpdater.Start();
        }
    }
}
