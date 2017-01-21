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
        public FileCommanderView()
        {
            InitializeComponent();
            LoadContent();
            DirectoryModel dirModel = new DirectoryModel();
            var a = dirModel.DirInfo;

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
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LoadContent()
        {
            treeView1.Nodes.Clear();

            DirectoryInfo directoryinfo = new DirectoryInfo(comboBox1.Text);
            if (directoryinfo != null)

            {


                try
                {
                    foreach (DirectoryInfo dirInfo in directoryinfo.GetDirectories())
                    {
                        TreeNode node = new TreeNode();
                        node.Text = dirInfo.FullName;
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        treeView1.Nodes.Add(node);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }
    }
}
