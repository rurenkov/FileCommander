﻿using System;
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
using System.Diagnostics;

namespace FileCommander
{
    public partial class FileCommanderView : Form
    {
        public PresenterClass Presenter { get; set; }
        public string SelectedDrive { get; set; }
        public FileCommanderView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


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

       // public event EventHandler webBrowserEvent;
        // VR
        public event EventHandler listViewEvent;

       // ListView listView1 = new ListView();
      //  listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            



            //treeView1.Nodes.Clear();
            //LoadContent();
            //LoadGridContent();
            //webBrowser1.Url = new Uri(comboBox1.Text);
            //if (webBrowserEvent != null)
            //{
            //    webBrowserEvent(sender, e);

            //}
            //VR
            

            if (listViewEvent != null)
            {
                listViewEvent(sender, e);
                
            }


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

        private void button1_Click(object sender, EventArgs e)
        {

             /// open file with default app
              OpenFileDialog openFileDialog = new OpenFileDialog();
              openFileDialog.InitialDirectory = "d:\\";
              openFileDialog.Filter = "All files (*.*)|*.*";
            
             if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
              {
                             
                 string file = openFileDialog.FileName;
                //textBox1.Text = file;
                
                  try
                  {
                    Process.Start(file);
                    
                }
                  catch (Exception ex)
                  {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
            }
              
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}