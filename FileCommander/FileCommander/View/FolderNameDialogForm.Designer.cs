namespace FileCommander
{
    partial class FolderNameDialogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.newFolderNameInputTextBox1 = new System.Windows.Forms.TextBox();
            this.okayButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New FolderName:";
            // 
            // newFolderNameInputTextBox1
            // 
            this.newFolderNameInputTextBox1.Location = new System.Drawing.Point(112, 13);
            this.newFolderNameInputTextBox1.Name = "newFolderNameInputTextBox1";
            this.newFolderNameInputTextBox1.Size = new System.Drawing.Size(216, 20);
            this.newFolderNameInputTextBox1.TabIndex = 1;
            // 
            // okayButton1
            // 
            this.okayButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okayButton1.Location = new System.Drawing.Point(112, 40);
            this.okayButton1.Name = "okayButton1";
            this.okayButton1.Size = new System.Drawing.Size(75, 23);
            this.okayButton1.TabIndex = 2;
            this.okayButton1.Text = "Okay";
            this.okayButton1.UseVisualStyleBackColor = true;
            this.okayButton1.Click += new System.EventHandler(this.okayButton1_Click);
            // 
            // FolderNameDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 70);
            this.Controls.Add(this.okayButton1);
            this.Controls.Add(this.newFolderNameInputTextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderNameDialogForm";
            this.Text = "New Folder Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox newFolderNameInputTextBox1;
        private System.Windows.Forms.Button okayButton1;
    }
}