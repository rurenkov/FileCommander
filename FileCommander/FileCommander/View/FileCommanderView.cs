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

      
        private void FileCommanderView_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
