using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileCommander.Model;
using FileCommander.Presenter;

namespace FileCommander
{
    public partial class FileCommanderView : Form
    {
        public PresenterClass Presenter { get; set; }
        public string SelectedDrive { get; set; }
        public FileCommanderView()
        {
            InitializeComponent();
            
            DirectoryModel dirModel = new DirectoryModel();
                      

        }

        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //treeView1.Nodes.Clear();
            //LoadContent();
            //LoadGridContent();
            webBrowser1.Url = new Uri(comboBox1.Text);
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        //private void LoadContent()
        //{
          
        //        try
        //        {
        //            foreach (string name in Presenter.GetFoldersNames(comboBox1.Text))
        //            {
        //                TreeNode node = new TreeNode();
        //                node.Text = name;
        //                node.ImageIndex = 1;
        //                node.SelectedImageIndex = 1;
        //                treeView1.Nodes.Add(node);

        //            }

        //            foreach (string name in Presenter.GetFilesNames(comboBox1.Text))
        //            {
        //                TreeNode node = new TreeNode(name);
        //                treeView1.Nodes.Add(node);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
            
        //}

        //private void LoadGridContent()
        //{

        //    try
        //    {
                
        //            DataGridView gridView = new DataGridView();
        //            gridView.Rows.Add(Presenter.GetFoldersNames(comboBox1.Text));
        //            //node.ImageIndex = 1;
        //            //node.SelectedImageIndex = 1;
        //            //treeView1.Nodes.Add(node);
        //            gridView.Rows.Add(Presenter.GetFilesNames(comboBox1.Text));
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Presenter.GetDrives.ToArray());
        }
    }
}
