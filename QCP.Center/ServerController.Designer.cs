namespace QCP.Center
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
            this.toolStripStatusLabelHostName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageController = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageServers = new System.Windows.Forms.TabPage();
            this.listViewServers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageServerInfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIPV6 = new System.Windows.Forms.Label();
            this.labelIPV4 = new System.Windows.Forms.Label();
            this.labelHostName = new System.Windows.Forms.Label();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.statusStripMain.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageController.SuspendLayout();
            this.tabPageServers.SuspendLayout();
            this.tabPageServerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelServerStatus,
            this.toolStripStatusLabelHostName});
            resources.ApplyResources(this.statusStripMain, "statusStripMain");
            this.statusStripMain.Name = "statusStripMain";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.Name = "labelServerStatus";
            resources.ApplyResources(this.labelServerStatus, "labelServerStatus");
            // 
            // toolStripStatusLabelHostName
            // 
            this.toolStripStatusLabelHostName.Name = "toolStripStatusLabelHostName";
            resources.ApplyResources(this.toolStripStatusLabelHostName, "toolStripStatusLabelHostName");
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Image = global::QCP.Center.Properties.Resources.play_1_;
            this.buttonStart.Name = "buttonStart";
            this.toolTipMain.SetToolTip(this.buttonStart, resources.GetString("buttonStart.ToolTip"));
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Image = global::QCP.Center.Properties.Resources.stop_3_;
            this.buttonStop.Name = "buttonStop";
            this.toolTipMain.SetToolTip(this.buttonStop, resources.GetString("buttonStop.ToolTip"));
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            resources.ApplyResources(this.notifyIconMain, "notifyIconMain");
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            resources.ApplyResources(this.contextMenuStripNotifyIcon, "contextMenuStripNotifyIcon");
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::QCP.Center.Properties.Resources.media_controls_dark_play;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            resources.ApplyResources(this.startToolStripMenuItem, "startToolStripMenuItem");
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.Image = global::QCP.Center.Properties.Resources.media_controls_dark_stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageController);
            this.tabControlMain.Controls.Add(this.tabPageServers);
            this.tabControlMain.Controls.Add(this.tabPageServerInfo);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // tabPageController
            // 
            this.tabPageController.Controls.Add(this.label5);
            this.tabPageController.Controls.Add(this.label1);
            this.tabPageController.Controls.Add(this.buttonStart);
            this.tabPageController.Controls.Add(this.buttonStop);
            resources.ApplyResources(this.tabPageController, "tabPageController");
            this.tabPageController.Name = "tabPageController";
            this.tabPageController.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPageServers
            // 
            this.tabPageServers.Controls.Add(this.listViewServers);
            resources.ApplyResources(this.tabPageServers, "tabPageServers");
            this.tabPageServers.Name = "tabPageServers";
            this.tabPageServers.UseVisualStyleBackColor = true;
            // 
            // listViewServers
            // 
            this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.listViewServers, "listViewServers");
            this.listViewServers.Name = "listViewServers";
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // tabPageServerInfo
            // 
            this.tabPageServerInfo.Controls.Add(this.label2);
            this.tabPageServerInfo.Controls.Add(this.label4);
            this.tabPageServerInfo.Controls.Add(this.label3);
            this.tabPageServerInfo.Controls.Add(this.labelIPV6);
            this.tabPageServerInfo.Controls.Add(this.labelIPV4);
            this.tabPageServerInfo.Controls.Add(this.labelHostName);
            resources.ApplyResources(this.tabPageServerInfo, "tabPageServerInfo");
            this.tabPageServerInfo.Name = "tabPageServerInfo";
            this.tabPageServerInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // labelIPV6
            // 
            resources.ApplyResources(this.labelIPV6, "labelIPV6");
            this.labelIPV6.Name = "labelIPV6";
            // 
            // labelIPV4
            // 
            resources.ApplyResources(this.labelIPV4, "labelIPV4");
            this.labelIPV4.Name = "labelIPV4";
            // 
            // labelHostName
            // 
            resources.ApplyResources(this.labelHostName, "labelHostName");
            this.labelHostName.Name = "labelHostName";
            // 
            // tabPageAbout
            // 
            resources.ApplyResources(this.tabPageAbout, "tabPageAbout");
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // ServerController
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStripMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerController";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerController_FormClosing);
            this.Load += new System.EventHandler(this.ServerController_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageController.ResumeLayout(false);
            this.tabPageController.PerformLayout();
            this.tabPageServers.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHostName;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageServers;
        private System.Windows.Forms.ListView listViewServers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}