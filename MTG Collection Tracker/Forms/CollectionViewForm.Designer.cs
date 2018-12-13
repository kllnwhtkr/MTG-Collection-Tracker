﻿namespace MTG_Collection_Tracker
{
    partial class CollectionViewForm
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
            this.cardListView = new BrightIdeasSoftware.FastObjectListView();
            this.CardName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FoilColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ManaCost = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CostColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TagsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TimeAddedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.cardListView)).BeginInit();
            this.SuspendLayout();
            // 
            // cardListView
            // 
            this.cardListView.AllColumns.Add(this.CardName);
            this.cardListView.AllColumns.Add(this.FoilColumn);
            this.cardListView.AllColumns.Add(this.olvColumn10);
            this.cardListView.AllColumns.Add(this.olvColumn11);
            this.cardListView.AllColumns.Add(this.olvColumn2);
            this.cardListView.AllColumns.Add(this.ManaCost);
            this.cardListView.AllColumns.Add(this.olvColumn4);
            this.cardListView.AllColumns.Add(this.olvColumn5);
            this.cardListView.AllColumns.Add(this.CountColumn);
            this.cardListView.AllColumns.Add(this.CostColumn);
            this.cardListView.AllColumns.Add(this.TagsColumn);
            this.cardListView.AllColumns.Add(this.olvColumn9);
            this.cardListView.AllColumns.Add(this.olvColumn1);
            this.cardListView.AllColumns.Add(this.TimeAddedColumn);
            this.cardListView.AllColumns.Add(this.olvColumn3);
            this.cardListView.AllColumns.Add(this.olvColumn6);
            this.cardListView.AllowDrop = true;
            this.cardListView.BackColor = System.Drawing.Color.White;
            this.cardListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.cardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardName,
            this.FoilColumn,
            this.olvColumn2,
            this.ManaCost,
            this.olvColumn4,
            this.olvColumn5,
            this.CountColumn,
            this.CostColumn,
            this.TagsColumn,
            this.TimeAddedColumn,
            this.olvColumn3,
            this.olvColumn6});
            this.cardListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.cardListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardListView.FullRowSelect = true;
            this.cardListView.GridLines = true;
            this.cardListView.HideSelection = false;
            this.cardListView.IsSimpleDropSink = true;
            this.cardListView.Location = new System.Drawing.Point(0, 0);
            this.cardListView.Name = "cardListView";
            this.cardListView.SelectedBackColor = System.Drawing.Color.SteelBlue;
            this.cardListView.SelectedForeColor = System.Drawing.Color.White;
            this.cardListView.ShowGroups = false;
            this.cardListView.Size = new System.Drawing.Size(975, 435);
            this.cardListView.TabIndex = 0;
            this.cardListView.UnfocusedSelectedBackColor = System.Drawing.Color.LightGray;
            this.cardListView.UseCompatibleStateImageBehavior = false;
            this.cardListView.View = System.Windows.Forms.View.Details;
            this.cardListView.VirtualMode = true;
            this.cardListView.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.fastObjectListView1_CellEditFinished);
            this.cardListView.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.fastObjectListView1_CellClick);
            this.cardListView.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.fastObjectListView1_ModelCanDrop);
            this.cardListView.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.fastObjectListView1_ModelDropped);
            this.cardListView.SelectionChanged += new System.EventHandler(this.fastObjectListView1_SelectionChanged);
            this.cardListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fastObjectListView1_KeyPress);
            // 
            // CardName
            // 
            this.CardName.AspectName = "PaddedName";
            this.CardName.ImageAspectName = "ImageKey";
            this.CardName.IsEditable = false;
            this.CardName.MinimumWidth = 200;
            this.CardName.Text = "Card";
            this.CardName.Width = 200;
            // 
            // FoilColumn
            // 
            this.FoilColumn.CheckBoxes = true;
            this.FoilColumn.Text = "Foil";
            this.FoilColumn.Width = 30;
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "MVid";
            this.olvColumn10.DisplayIndex = 1;
            this.olvColumn10.IsVisible = false;
            this.olvColumn10.Text = "MVid";
            // 
            // olvColumn11
            // 
            this.olvColumn11.AspectName = "CardInstanceId";
            this.olvColumn11.DisplayIndex = 1;
            this.olvColumn11.IsVisible = false;
            this.olvColumn11.Text = "CardInstanceId";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Type";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MinimumWidth = 100;
            this.olvColumn2.Text = "Type";
            this.olvColumn2.Width = 100;
            // 
            // ManaCost
            // 
            this.ManaCost.AspectName = "ManaCost";
            this.ManaCost.IsEditable = false;
            this.ManaCost.MinimumWidth = 100;
            this.ManaCost.Text = "Mana Cost";
            this.ManaCost.Width = 100;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Edition";
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MinimumWidth = 100;
            this.olvColumn4.Text = "Set";
            this.olvColumn4.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "ColNumber";
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.MinimumWidth = 50;
            this.olvColumn5.Text = "#";
            // 
            // CountColumn
            // 
            this.CountColumn.AspectName = "Count";
            this.CountColumn.MinimumWidth = 50;
            this.CountColumn.Text = "Count";
            // 
            // CostColumn
            // 
            this.CostColumn.AspectName = "Cost";
            this.CostColumn.MinimumWidth = 50;
            this.CostColumn.Text = "Cost";
            // 
            // TagsColumn
            // 
            this.TagsColumn.AspectName = "Tags";
            this.TagsColumn.MinimumWidth = 200;
            this.TagsColumn.Text = "Tags";
            this.TagsColumn.Width = 200;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "SortableTimeAdded";
            this.olvColumn9.AspectToStringFormat = "";
            this.olvColumn9.DisplayIndex = 8;
            this.olvColumn9.IsEditable = false;
            this.olvColumn9.IsVisible = false;
            this.olvColumn9.MinimumWidth = 100;
            this.olvColumn9.Text = "Added";
            this.olvColumn9.Width = 100;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "InsertionIndex";
            this.olvColumn1.DisplayIndex = 9;
            this.olvColumn1.IsVisible = false;
            this.olvColumn1.Text = "InsertionIndex";
            // 
            // TimeAddedColumn
            // 
            this.TimeAddedColumn.AspectName = "TimeAdded";
            this.TimeAddedColumn.Text = "Added";
            this.TimeAddedColumn.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "multiverseId";
            this.olvColumn3.Text = "multiverseId";
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "multiverseId_1";
            this.olvColumn6.Text = "MVid";
            // 
            // CollectionViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 435);
            this.Controls.Add(this.cardListView);
            this.DoubleBuffered = true;
            this.Name = "CollectionViewForm";
            this.Text = "Collection View";
            ((System.ComponentModel.ISupportInitialize)(this.cardListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.OLVColumn CardName;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn ManaCost;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        internal BrightIdeasSoftware.FastObjectListView cardListView;
        private BrightIdeasSoftware.OLVColumn CountColumn;
        private BrightIdeasSoftware.OLVColumn CostColumn;
        private BrightIdeasSoftware.OLVColumn TagsColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvColumn11;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn TimeAddedColumn;
        private BrightIdeasSoftware.OLVColumn FoilColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
    }
}