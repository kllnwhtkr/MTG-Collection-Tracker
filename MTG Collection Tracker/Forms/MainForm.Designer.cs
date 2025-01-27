﻿namespace MTG_Librarian
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.vS2015LightTheme1 = new KW.WinFormsUI.Docking.VS2015LightTheme();
            this.CheckForNewSetsWorker = new System.ComponentModel.BackgroundWorker();
            this.InitUIWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dockPanel1 = new KW.WinFormsUI.Docking.DockPanel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDeckcollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainStatusLabel = new System.Windows.Forms.Label();
            this.statusBarActionButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.TasksProgressBar = new CustomControls.BlockProgressBar();
            this.TasksLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckForNewSetsWorker
            // 
            this.CheckForNewSetsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkForNewSetsWorker_DoWork);
            // 
            // InitUIWorker
            // 
            this.InitUIWorker.WorkerReportsProgress = true;
            this.InitUIWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitUIWorker_DoWork);
            this.InitUIWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.InitUIWorker_ProgressChanged);
            this.InitUIWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InitUIWorker_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dockPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.mainMenuStrip);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 782);
            this.splitContainer1.SplitterDistance = 722;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // dockPanel1
            // 
            this.dockPanel1.AllowEndUserNestedDocking = false;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel1.DockBottomPortion = 0.5D;
            this.dockPanel1.DockLeftPortion = 0.15D;
            this.dockPanel1.DockRightPortion = 0.15D;
            this.dockPanel1.DockTopPortion = 0.5D;
            this.dockPanel1.Theme = this.vS2015LightTheme1;
            this.dockPanel1.DocumentStyle = KW.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.DoubleClickCaptionAction = KW.WinFormsUI.Docking.DockPanel.DoubleClickCaptionActionEnum.SendToBack;
            this.dockPanel1.Location = new System.Drawing.Point(0, 28);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.Size = new System.Drawing.Size(1924, 694);
            this.dockPanel1.TabIndex = 1;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1924, 28);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDeckcollectionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportDeckcollectionToolStripMenuItem
            // 
            this.exportDeckcollectionToolStripMenuItem.Name = "exportDeckcollectionToolStripMenuItem";
            this.exportDeckcollectionToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.exportDeckcollectionToolStripMenuItem.Text = "Export deck/collection";
            this.exportDeckcollectionToolStripMenuItem.Click += new System.EventHandler(this.exportDeckcollectionToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardInfoToolStripMenuItem,
            this.dBToolStripMenuItem,
            this.navigatorToolStripMenuItem,
            this.tasksToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // cardInfoToolStripMenuItem
            // 
            this.cardInfoToolStripMenuItem.Name = "cardInfoToolStripMenuItem";
            this.cardInfoToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.cardInfoToolStripMenuItem.Text = "Card Info";
            this.cardInfoToolStripMenuItem.Click += new System.EventHandler(this.cardInfoToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.dBToolStripMenuItem.Text = "DB";
            this.dBToolStripMenuItem.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // navigatorToolStripMenuItem
            // 
            this.navigatorToolStripMenuItem.Name = "navigatorToolStripMenuItem";
            this.navigatorToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.navigatorToolStripMenuItem.Text = "Navigator";
            this.navigatorToolStripMenuItem.Click += new System.EventHandler(this.navigatorToolStripMenuItem_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.tasksToolStripMenuItem.Text = "Tasks";
            this.tasksToolStripMenuItem.Click += new System.EventHandler(this.tasksToolStripMenuItem_Click);
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusPanel.Controls.Add(this.panel1);
            this.statusPanel.Controls.Add(this.mainPanel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(4);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(1924, 59);
            this.statusPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainStatusLabel);
            this.panel1.Controls.Add(this.statusBarActionButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 59);
            this.panel1.TabIndex = 2;
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.AutoSize = true;
            this.mainStatusLabel.ForeColor = System.Drawing.Color.White;
            this.mainStatusLabel.Location = new System.Drawing.Point(16, 11);
            this.mainStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(44, 16);
            this.mainStatusLabel.TabIndex = 0;
            this.mainStatusLabel.Text = "label1";
            this.mainStatusLabel.Visible = false;
            // 
            // statusBarActionButton
            // 
            this.statusBarActionButton.AutoSize = true;
            this.statusBarActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusBarActionButton.FlatAppearance.BorderSize = 0;
            this.statusBarActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusBarActionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarActionButton.ForeColor = System.Drawing.Color.White;
            this.statusBarActionButton.Location = new System.Drawing.Point(71, 4);
            this.statusBarActionButton.Margin = new System.Windows.Forms.Padding(4);
            this.statusBarActionButton.Name = "statusBarActionButton";
            this.statusBarActionButton.Size = new System.Drawing.Size(203, 27);
            this.statusBarActionButton.TabIndex = 1;
            this.statusBarActionButton.Text = "[ Click here to update library ]";
            this.statusBarActionButton.UseVisualStyleBackColor = true;
            this.statusBarActionButton.Visible = false;
            this.statusBarActionButton.Click += new System.EventHandler(this.statusBarActionButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.TasksProgressBar);
            this.mainPanel.Controls.Add(this.TasksLabel);
            this.mainPanel.Location = new System.Drawing.Point(1079, 28);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(841, 31);
            this.mainPanel.TabIndex = 0;
            // 
            // TasksProgressBar
            // 
            this.TasksProgressBar.BarColor = System.Drawing.Color.White;
            this.TasksProgressBar.BlankBarColor = System.Drawing.Color.DodgerBlue;
            this.TasksProgressBar.BorderColor = System.Drawing.Color.White;
            this.TasksProgressBar.CurrentBlocks = 3;
            this.TasksProgressBar.Location = new System.Drawing.Point(696, 14);
            this.TasksProgressBar.Margin = new System.Windows.Forms.Padding(5);
            this.TasksProgressBar.MaxBlocks = 0;
            this.TasksProgressBar.Name = "TasksProgressBar";
            this.TasksProgressBar.Progress = 0;
            this.TasksProgressBar.Size = new System.Drawing.Size(133, 9);
            this.TasksProgressBar.TabIndex = 1;
            // 
            // TasksLabel
            // 
            this.TasksLabel.ForeColor = System.Drawing.Color.White;
            this.TasksLabel.Location = new System.Drawing.Point(263, 9);
            this.TasksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TasksLabel.Name = "TasksLabel";
            this.TasksLabel.Size = new System.Drawing.Size(425, 16);
            this.TasksLabel.TabIndex = 0;
            this.TasksLabel.Text = "No active tasks";
            this.TasksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 782);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MTG Librarian";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private KW.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private System.ComponentModel.BackgroundWorker CheckForNewSetsWorker;
        private System.ComponentModel.BackgroundWorker InitUIWorker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private KW.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Panel mainPanel;
        public System.Windows.Forms.ImageList largeIconLists;
        public System.Windows.Forms.Label TasksLabel;
        public CustomControls.BlockProgressBar TasksProgressBar;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.Button statusBarActionButton;
        private System.Windows.Forms.Label mainStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDeckcollectionToolStripMenuItem;
    }
}

