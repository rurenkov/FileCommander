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
        public object EmpIDtextBox { get; private set; }
        public string NewDirectoryNameInput { get; set; }

        public string TextBox1 { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string TextBox2 { get { return textBox2.Text; } set { textBox2.Text = value; } }

        public bool IsListView1Active { get; set; }
        public bool IsListView2Active { get; set; }
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

        public string SelectedDrive1 { get { return comboBox1.Text; } set { comboBox1.Text = value; } }
        public string SelectedDrive2 { get { return comboBox2.Text; } set { comboBox2.Text = value; } }

        public event EventHandler renameDirEvent;
        public event EventHandler copyDirEvent;

        public event EventHandler listViewEvent;
        public event EventHandler listViewEventRight;
        public event EventHandler selectedItemsEvent;
        public event EventHandler listView_KeySpaceEvent;
        public event EventHandler listView_KeyBackSpaceEvent;
        public event EventHandler listView_KeyEnterEvent;
        public event EventHandler listView_KeyDeleteEvent;
        public event EventHandler listView_CreateNewFolderEvent;
        public event EventHandler listView_MouseDoubleClickEvent;

      //  public event EventHandler directoryExistNotification;

/*
        public void directoryExistNotification(bool val)
        {
            MessageBox.Show("Dyrectory already exists", "Confirmation window", MessageBoxButtons Yes)

        }
        */

        // ListView listView1 = new ListView();
        //  listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));

        private void PopulateListView(ListView listView, Dictionary<string, string[]> foldersDic, Dictionary<string, string[]> filesDic)
        {
            foreach (var dirInfo in foldersDic)
            {
                listView.Items.Add(dirInfo.Key, 1).SubItems.AddRange(dirInfo.Value);
            }

            foreach (var fileInfo in filesDic)
            {
                listView.Items.Add(fileInfo.Key, 0).SubItems.AddRange(fileInfo.Value);
            }
        }
        public void PopulateListView1(Dictionary<string, string[]> foldersDic, Dictionary<string, string[]> filesDic, int pathHistory1Count)
        {
            if (pathHistory1Count > 1)
            {
                listView1.Items.Add("..", 2).SubItems.Add(" ");
            }

            PopulateListView(listView1, foldersDic, filesDic);
        }

        public void PopulateListView2(Dictionary<string, string[]> foldersDic, Dictionary<string, string[]> filesDic, int pathHistory2Count)
        {
            if (pathHistory2Count > 1)
            {
                listView2.Items.Add("..", 2).SubItems.Add(" ");
            }

            PopulateListView(listView2, foldersDic, filesDic);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listViewEvent != null)
            {
                try
                {
                    listViewEvent(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Presenter.GetDrives.ToArray());

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(Presenter.GetDrives.ToArray());

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {


        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                selectedItemsEvent(sender, e);
            }

            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // change panels
        private void btnChangePanel_Click(object sender, EventArgs e)
        {

            Control[] array1 = new Control[splitContainer1.Panel1.Controls.Count];
            Control[] array2 = new Control[splitContainer1.Panel2.Controls.Count];
            splitContainer1.Panel1.Controls.CopyTo(array1, 0);
            splitContainer1.Panel2.Controls.CopyTo(array2, 0);
            splitContainer1.Panel1.Controls.AddRange(array2);
            splitContainer1.Panel2.Controls.AddRange(array1);
            if (splitContainer1.Orientation == Orientation.Horizontal)
            {
                splitContainer1.SplitterDistance = splitContainer1.Height - splitContainer1.SplitterDistance;
            }
            else if (splitContainer1.Orientation == Orientation.Vertical)
            {
                splitContainer1.SplitterDistance = splitContainer1.Width - splitContainer1.SplitterDistance;
            }


        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            listView1.Width = splitContainer1.Panel1.Width;
            listView2.Width = splitContainer1.Panel1.Width;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Space:
                    try
                    {
                        listView_KeySpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case Keys.Back:
                    
                    try
                    {
                        listView_KeyBackSpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Enter:
                    try
                    {
                        listView_KeyEnterEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Delete:
                    
                    var confirmResult = MessageBox.Show("Are you sure to delete <" + ActiveListViewSelectedItemText() + ">?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {

                        try
                        {
                            listView_KeyDeleteEvent(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case Keys.F7:
                    using (FolderNameDialogForm folderNameDialog = new FolderNameDialogForm())
                    {
                        if (folderNameDialog.ShowDialog() == DialogResult.OK)
                        {
                            NewDirectoryNameInput = folderNameDialog.newFolderNameInputTextBox1.Text;
                        }
                    }
                    try

                    {
                        listView_CreateNewFolderEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;

            }
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Space:
                    try
                    {
                        listView_KeySpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case Keys.Back:
                   
                    try
                    {
                        listView_KeyBackSpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Enter:
                    try
                    {
                        listView_KeyEnterEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Delete:

                    var confirmResult = MessageBox.Show("Are you sure to delete <" + ActiveListViewSelectedItemText() + ">?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {

                        try
                        {
                            listView_KeyDeleteEvent(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case Keys.F7:
                    using (FolderNameDialogForm folderNameDialog = new FolderNameDialogForm())
                    {
                        if (folderNameDialog.ShowDialog() == DialogResult.OK)
                        {
                            NewDirectoryNameInput = folderNameDialog.newFolderNameInputTextBox1.Text;
                        }
                    }
                    try

                    {
                        listView_CreateNewFolderEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;

            }
        }


        private void FileCommanderView_Load(object sender, EventArgs e)
        {

        }



        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listViewEventRight != null)
            {
                try
                {
                    listViewEventRight(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            listView_MouseDoubleClickEvent(sender, e);
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            listView_MouseDoubleClickEvent(sender, e);
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FolderNameDialogForm folderNameDialog = new FolderNameDialogForm())
            {
                if (folderNameDialog.ShowDialog() == DialogResult.OK)
                {
                    NewDirectoryNameInput = folderNameDialog.newFolderNameInputTextBox1.Text;
                }
            }
            try

            {
                listView_CreateNewFolderEvent(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if ((!IsItemSelectedView1()) & (!IsItemSelectedView2()))  
            {
                return;
            }
            var confirmResult = MessageBox.Show("Are you sure to delete <" + ActiveListViewSelectedItemText() + ">?",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                try
                {
                    listView_KeyDeleteEvent(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            try
            {
                listView_KeyEnterEvent(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                listView_KeyBackSpaceEvent(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_4(object sender, EventArgs e)
        {


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {

            if ((!IsItemSelectedView1()) & (!IsItemSelectedView2()))
            {
                return;
            }
            using (FolderNameDialogForm folderNameDialog = new FolderNameDialogForm())
            {
                if (folderNameDialog.ShowDialog() == DialogResult.OK)
                {
                    NewDirectoryNameInput = folderNameDialog.newFolderNameInputTextBox1.Text;
                }


                try
                {
                    renameDirEvent(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            ActiveListViewSelectedItemText();
            IsItemSelectedView1();
            IsItemSelectedView2();
           
            

            try
                {
                    copyDirEvent(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
        }

        public void ListView1Clear()
        {
            listView1.Items.Clear();
        }
        public void ListView2Clear()
        {
            listView2.Items.Clear();
        }

        private string SelectedItemText(ListView listView)
        {                     
            int intselectedindex = listView.SelectedIndices[0];
            return listView.Items[intselectedindex].Text;           

        }

        public string SelectedItemText1()
        {
           return SelectedItemText(listView1);

        }
        public string SelectedItemText2()
        {
            return SelectedItemText(listView2);

        }

        public string SelectedItem1Type()
        {
            return listView1.SelectedItems[0].SubItems[1].Text;            
        }

        public string SelectedItem2Type()
        {
            return listView2.SelectedItems[0].SubItems[1].Text;
        }

        public bool IsItemSelectedView1()
        {
            if (listView1.SelectedIndices.Count <= 0)
               return false;
            else return true;
        }

        public bool IsItemSelectedView2()
        {
            if (listView2.SelectedIndices.Count <= 0)
                return false;
            else return true;
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            IsListView2Active = false;
            IsListView1Active = true;
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            
        }

        private void listView2_Enter(object sender, EventArgs e)
        {
            IsListView1Active = false;
            IsListView2Active = true;
        }

        private void listView2_Leave(object sender, EventArgs e)
        {
           
        }
        // Name (string) of selected element in active window
        public string ActiveListViewSelectedItemText()
        {
            if (IsListView1Active)
                return listView1.SelectedItems[0].Text;
            else return listView2.SelectedItems[0].Text;
        }

        public void UpdateSelectedItem1Size(string size)
        {
            if (listView1.SelectedItems[0].SubItems[2].Text == "<DIR>")
                listView1.SelectedItems[0].SubItems[2].Text = size;
        }

        public void UpdateSelectedItem2Size(string size)
        {
            if (listView2.SelectedItems[0].SubItems[2].Text == "<DIR>")
                listView2.SelectedItems[0].SubItems[2].Text = size;
        }
        // Index (int) of selected element in active window
       


    }
    }







