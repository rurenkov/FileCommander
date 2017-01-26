using FileCommander.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Windows.Forms;

namespace FileCommander.Presenter
{
    public class PresenterClass
    {
        DriveModel driveModel;
        DirectoryModel directoryModel;
        FileModel fileModel;
        DirectoryInfo dirInfo;

        public List<string> GetDrives { get { return driveModel.DrivesName; } }
        
        private FileCommanderView fileCommanderView;
        public PresenterClass (FileCommanderView fileCommanderView)
        {
            driveModel = new Model.DriveModel();
            directoryModel = new DirectoryModel();
            fileModel = new FileModel();
            this.fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;
            //this.fileCommanderView.webBrowserEvent += FileCommanderView_webBrowserEvent;
            //VR
            this.fileCommanderView.listViewEvent += FileCommanderView_listViewEvent;
            this.fileCommanderView.selectedItemsEvent += FileCommanderView_SelectedItemsEvent;

            // this.ListViewItem = ListViewItem;



    }
        //vr/
        // selectes item from list view
        //


        private void FileCommanderView_SelectedItemsEvent(object sender, EventArgs e)
        {
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                this.fileCommanderView.textBox1.Text = fileCommanderView.comboBox1.Text +  this.fileCommanderView.listView1.Items[intselectedindex].Text;
                DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.textBox1.Text);
                //string[] row1 = { "SELECTED FOLDER", GetFolderSize(dirInfo), dirInfo.LastWriteTime.ToShortDateString() };
                //this.fileCommanderView.listView1.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
                //ListViewItem item = this.fileCommanderView.listView1.SelectedItems[0];
                if (fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text == "<DIR>")
                {
                    fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text = GetFolderSize(dirInfo);
                }

                //     string pathy = null;

                //   this.fileCommanderView.textBox2.Text = this.fileCommanderView.d.ToString(); 
                // fileCommanderView.listView1.Items[intselectedindex].SubItems[0].Text;

            }
        }



    private void FileCommanderView_listViewEvent(object sender, EventArgs e)
        {
            
                this.fileCommanderView.listView1.Items.Clear();
                //foreach (string folderName in GetFoldersNames(this.fileCommanderView.comboBox1.Text))
                //{               
                //     this.fileCommanderView.listView1.Items.Add(folderName, 1);       
                //}
                List<DirectoryInfo> names = GetFolders(this.fileCommanderView.comboBox1.Text);

                foreach(DirectoryInfo dirInfo in GetFolders(this.fileCommanderView.comboBox1.Text))
                {
                    string[] row1 = { "FOLDER", "<DIR>", dirInfo.LastWriteTime.ToShortDateString() };
                    this.fileCommanderView.listView1.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
                }

                

                //foreach (string fileName in GetFilesNames(this.fileCommanderView.comboBox1.Text))
                //{
                //    string[] row1 = { "File", "", "" };
                //    this.fileCommanderView.listView1.Items.Add("ItemName").SubItems.AddRange(row1);
                //}

                foreach (FileInfo fileInfo in GetFiles(this.fileCommanderView.comboBox1.Text))
                {
                    string[] row1 = { "FILE", (((fileInfo.Length/1024)).ToString("0.00")), fileInfo.LastWriteTime.ToShortDateString() };
                    this.fileCommanderView.listView1.Items.Add(fileInfo.Name, 0).SubItems.AddRange(row1);
                }
         


         

        }

     
        public string[] GetFoldersNames(string selectedDrive)
        {
            return directoryModel.GetFoldersNames(selectedDrive);
        }

        public string[] GetFilesNames(string selectedDrive)
        {
            return fileModel.GetFilesNames(selectedDrive);
        }

        public List<FileInfo> GetFiles(string selectedDrive)
        {
            return fileModel.GetFiles(selectedDrive);
        }

        public List<DirectoryInfo> GetFolders(string selectedDrive)
        {
            return directoryModel.GetFolders(selectedDrive);
        }

        public string GetFolderSize(DirectoryInfo dirInfo)
        {
            string size = directoryModel.GetFolderSize(dirInfo).ToString();
            return size;
        }


    }
}
