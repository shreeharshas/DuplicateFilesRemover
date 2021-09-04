namespace DuplicateFilesManager
{
    partial class frmMain
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
            this.btnSelectDuplicates = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.chklstFilesList = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lstPotentialDuplicate = new System.Windows.Forms.ListBox();
            this.tvDuplicates = new System.Windows.Forms.TreeView();
            this.btnStopScan = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectDuplicates
            // 
            this.btnSelectDuplicates.Location = new System.Drawing.Point(192, 25);
            this.btnSelectDuplicates.Name = "btnSelectDuplicates";
            this.btnSelectDuplicates.Size = new System.Drawing.Size(112, 47);
            this.btnSelectDuplicates.TabIndex = 6;
            this.btnSelectDuplicates.Text = "Select all duplicates";
            this.btnSelectDuplicates.UseVisualStyleBackColor = true;
            this.btnSelectDuplicates.Click += new System.EventHandler(this.btnSelectDuplicates_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(478, 25);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(237, 47);
            this.btnDeleteSelected.TabIndex = 7;
            this.btnDeleteSelected.Text = "Permently Remove Selected Items";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // chklstFilesList
            // 
            this.chklstFilesList.FormattingEnabled = true;
            this.chklstFilesList.Location = new System.Drawing.Point(190, 72);
            this.chklstFilesList.Name = "chklstFilesList";
            this.chklstFilesList.Size = new System.Drawing.Size(212, 19);
            this.chklstFilesList.TabIndex = 3;
            this.chklstFilesList.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(50, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 47);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Start Scan";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Folder:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFolderPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txtFolderPath.Location = new System.Drawing.Point(130, 36);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(573, 20);
            this.txtFolderPath.TabIndex = 2;
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Location = new System.Drawing.Point(709, 36);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(33, 23);
            this.btnFolderSelect.TabIndex = 3;
            this.btnFolderSelect.Text = "...";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // lstPotentialDuplicate
            // 
            this.lstPotentialDuplicate.FormattingEnabled = true;
            this.lstPotentialDuplicate.Location = new System.Drawing.Point(51, 74);
            this.lstPotentialDuplicate.Name = "lstPotentialDuplicate";
            this.lstPotentialDuplicate.Size = new System.Drawing.Size(112, 17);
            this.lstPotentialDuplicate.TabIndex = 5;
            this.lstPotentialDuplicate.Visible = false;
            // 
            // tvDuplicates
            // 
            this.tvDuplicates.CheckBoxes = true;
            this.tvDuplicates.Location = new System.Drawing.Point(51, 65);
            this.tvDuplicates.Name = "tvDuplicates";
            this.tvDuplicates.Size = new System.Drawing.Size(691, 276);
            this.tvDuplicates.TabIndex = 4;
            this.tvDuplicates.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDuplicates_AfterCheck);
            this.tvDuplicates.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDuplicates_NodeMouseDoubleClick);
            // 
            // btnStopScan
            // 
            this.btnStopScan.Location = new System.Drawing.Point(50, 25);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(112, 47);
            this.btnStopScan.TabIndex = 5;
            this.btnStopScan.Text = "Stop Scan";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(335, 25);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(112, 47);
            this.btnDeselectAll.TabIndex = 8;
            this.btnDeselectAll.Text = "De-Select All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnDeselectAll);
            this.pnlButtons.Controls.Add(this.btnSelectDuplicates);
            this.pnlButtons.Controls.Add(this.btnDeleteSelected);
            this.pnlButtons.Controls.Add(this.btnStopScan);
            this.pnlButtons.Location = new System.Drawing.Point(12, 347);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(776, 100);
            this.pnlButtons.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tvDuplicates);
            this.Controls.Add(this.btnFolderSelect);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPotentialDuplicate);
            this.Controls.Add(this.chklstFilesList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmMain";
            this.Text = "Duplicate File Remover";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDuplicates;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.CheckedListBox chklstFilesList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lstPotentialDuplicate;
        private System.Windows.Forms.TreeView tvDuplicates;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Panel pnlButtons;
    }
}

