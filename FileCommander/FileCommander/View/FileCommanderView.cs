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
using System.Diagnostics;

namespace FileCommander
{
    public partial class FileCommanderView : Form
    {
        public PresenterClass Presenter { get; set; }
        public string SelectedDrive { get; set; }
        public object EmpIDtextBox { get; private set; }

        public string NewDirectoryNameInput { get; set; }

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
        public event EventHandler listViewEvent;
        public event EventHandler listViewEventRight;
        public event EventHandler selectedItemsEvent;
        public event EventHandler listView1_KeySpaceEvent;
        public event EventHandler listView1_KeyBackSpaceEvent;
        public event EventHandler listView1_KeyEnterEvent;
        public event EventHandler listView1_KeyDeleteEvent;
        public event EventHandler listView1_KeyF7Event;
        public event EventHandler listView1_MouseDoubleClickEvent;
        
      
        // ListView listView1 = new ListView();
        //  listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));


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
                        listView1_KeySpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case Keys.Back:
                    try
                    {
                        listView1_KeyBackSpaceEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Enter:
                    try
                    {
                        listView1_KeyEnterEvent(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Keys.Delete:
                    var confirmResult = MessageBox.Show("Are you sure to delete <"+listView1.SelectedItems[0].Text+">?", 
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {

                        try
                        {
                            listView1_KeyDeleteEvent(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                    case Keys.F7:
                   
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
            
            listView1_MouseDoubleClickEvent(sender, e);
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
                listView1_KeyF7Event(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete <" + listView1.SelectedItems[0].Text + ">?",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                try
                {
                    listView1_KeyDeleteEvent(sender, e);
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
                listView1_KeyEnterEvent(sender, e);
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
                listView1_KeyBackSpaceEvent(sender, e);
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
    }
}
