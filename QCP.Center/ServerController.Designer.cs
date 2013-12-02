﻿namespace QCP.Center
{
    partial class ServerController
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerController));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.labelServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageController = new System.Windows.Forms.TabPage();
            this.tabPageServerInfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIPV6 = new System.Windows.Forms.Label();
            this.labelIPV4 = new System.Windows.Forms.Label();
            this.labelHostName = new System.Windows.Forms.Label();
            this.statusStripMain.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageController.SuspendLayout();
            this.tabPageServerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelServerStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 390);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(284, 22);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(47, 17);
            this.labelServerStatus.Text = "Ready.";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Image = global::QCP.Center.Properties.Resources.media_controls_dark_play;
            this.buttonStart.Location = new System.Drawing.Point(176, 311);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(32, 32);
            this.buttonStart.TabIndex = 0;
            this.toolTipMain.SetToolTip(this.buttonStart, "Start Server");
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Image = global::QCP.Center.Properties.Resources.media_controls_dark_stop;
            this.buttonStop.Location = new System.Drawing.Point(214, 311);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(32, 32);
            this.buttonStop.TabIndex = 2;
            this.toolTipMain.SetToolTip(this.buttonStop, "Stop Server");
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Server.Controller";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(109, 76);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::QCP.Center.Properties.Resources.media_controls_dark_play;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Image = global::QCP.Center.Properties.Resources.media_controls_dark_stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageController);
            this.tabControlMain.Controls.Add(this.tabPageServerInfo);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(260, 375);
            this.tabControlMain.TabIndex = 4;
            // 
            // tabPageController
            // 
            this.tabPageController.Controls.Add(this.buttonStart);
            this.tabPageController.Controls.Add(this.buttonStop);
            this.tabPageController.Location = new System.Drawing.Point(4, 22);
            this.tabPageController.Name = "tabPageController";
            this.tabPageController.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageController.Size = new System.Drawing.Size(252, 349);
            this.tabPageController.TabIndex = 0;
            this.tabPageController.Text = "Controller";
            this.tabPageController.UseVisualStyleBackColor = true;
            // 
            // tabPageServerInfo
            // 
            this.tabPageServerInfo.Controls.Add(this.label2);
            this.tabPageServerInfo.Controls.Add(this.label4);
            this.tabPageServerInfo.Controls.Add(this.label3);
            this.tabPageServerInfo.Controls.Add(this.labelIPV6);
            this.tabPageServerInfo.Controls.Add(this.labelIPV4);
            this.tabPageServerInfo.Controls.Add(this.labelHostName);
            this.tabPageServerInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageServerInfo.Name = "tabPageServerInfo";
            this.tabPageServerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServerInfo.Size = new System.Drawing.Size(252, 349);
            this.tabPageServerInfo.TabIndex = 1;
            this.tabPageServerInfo.Text = "ServerInfo";
            this.tabPageServerInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "HostName:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "IP(V6):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "IP(V4):";
            // 
            // labelIPV6
            // 
            this.labelIPV6.Location = new System.Drawing.Point(74, 53);
            this.labelIPV6.Name = "labelIPV6";
            this.labelIPV6.Size = new System.Drawing.Size(172, 23);
            this.labelIPV6.TabIndex = 2;
            // 
            // labelIPV4
            // 
            this.labelIPV4.Location = new System.Drawing.Point(74, 30);
            this.labelIPV4.Name = "labelIPV4";
            this.labelIPV4.Size = new System.Drawing.Size(172, 23);
            this.labelIPV4.TabIndex = 1;
            // 
            // labelHostName
            // 
            this.labelHostName.Location = new System.Drawing.Point(76, 7);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(170, 23);
            this.labelHostName.TabIndex = 0;
            // 
            // ServerController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 412);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "ServerController";
            this.Text = "Server.Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerController_FormClosing);
            this.Load += new System.EventHandler(this.ServerController_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageController.ResumeLayout(false);
            this.tabPageServerInfo.ResumeLayout(false);
            this.tabPageServerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelServerStatus;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageController;
        private System.Windows.Forms.TabPage tabPageServerInfo;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelIPV6;
        private System.Windows.Forms.Label labelIPV4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}