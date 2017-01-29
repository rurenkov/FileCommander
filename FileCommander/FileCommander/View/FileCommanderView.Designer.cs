namespace FileCommander
{
    partial class FileCommanderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCommanderView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.btnChangePanel = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemChanged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.configToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.folderToolStripMenuItem2});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // folderToolStripMenuItem2
            // 
            this.folderToolStripMenuItem2.Name = "folderToolStripMenuItem2";
            this.folderToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem2.Text = "Folder";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.folderToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "File";
            // 
            // folderToolStripMenuItem1
            // 
            this.folderToolStripMenuItem1.Name = "folderToolStripMenuItem1";
            this.folderToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem1.Text = "Folder";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file.png");
            this.imageList1.Images.SetKeyName(1, "images.jpg");
            this.imageList1.Images.SetKeyName(2, "back_small.ico");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnBack);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnNewFolder);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnChangePanel);
            this.flowLayoutPanel1.Controls.Add(this.btnRename);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1005, 58);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(239, 3);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(70, 28);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "Open";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChangePanel
            // 
            this.btnChangePanel.Location = new System.Drawing.Point(315, 3);
            this.btnChangePanel.Name = "btnChangePanel";
            this.btnChangePanel.Size = new System.Drawing.Size(121, 51);
            this.btnChangePanel.TabIndex = 1;
            this.btnChangePanel.Text = "<--ChangePanel-->";
            this.btnChangePanel.UseVisualStyleBackColor = true;
            this.btnChangePanel.Click += new System.EventHandler(this.btnChangePanel_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.ItemType,
            this.ItemSize,
            this.ItemChanged});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(502, 593);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // ItemName
            // 
            this.ItemName.Text = "ItemName";
            this.ItemName.Width = 158;
            // 
            // ItemType
            // 
            this.ItemType.Text = "ItemType";
            this.ItemType.Width = 82;
            // 
            // ItemSize
            // 
            this.ItemSize.Text = "ItemSize";
            this.ItemSize.Width = 118;
            // 
            // ItemChanged
            // 
            this.ItemChanged.Text = "ItemChanged";
            this.ItemChanged.Width = 122;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.comboBox1);
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 92);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(283, 22);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "r";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(1, 1);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "f";
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textBox1.Location = new System.Drawing.Point(77, 1);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 1, 10, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(5, 120);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 597);
            this.splitContainer1.SplitterDistance = 506;
            this.splitContainer1.TabIndex = 6;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(498, 593);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ItemName";
            this.columnHeader1.Width = 158;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ItemType";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ItemSize";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ItemChanged";
            this.columnHeader4.Width = 122;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.comboBox2);
            this.flowLayoutPanel3.Controls.Add(this.textBox2);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(516, 91);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(332, 22);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1, 1);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(1, 1, 10, 10);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(73, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // textBox2
            // 
            this.textBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textBox2.Location = new System.Drawing.Point(87, 1);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 1, 10, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(53, 51);
            this.btnBack.TabIndex = 6;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(62, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(53, 51);
            this.btnNext.TabIndex = 5;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFolder.Image")));
            this.btnNewFolder.Location = new System.Drawing.Point(121, 3);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(53, 51);
            this.btnNewFolder.TabIndex = 2;
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::FileCommander.Properties.Resources.Button_Delete_icon;
            this.btnDelete.Location = new System.Drawing.Point(180, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 51);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnRename
            // 
            this.btnRename.Image = global::FileCommander.Properties.Resources.folder;
            this.btnRename.Location = new System.Drawing.Point(442, 3);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(53, 51);
            this.btnRename.TabIndex = 7;
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // FileCommanderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 727);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FileCommanderView";
            this.Text = "File Commander";
            this.Load += new System.EventHandler(this.FileCommanderView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOpenFiles;
        internal System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader ItemType;
        private System.Windows.Forms.ColumnHeader ItemSize;
        private System.Windows.Forms.ColumnHeader ItemChanged;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnChangePanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.ListView listView2;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
    }
}

