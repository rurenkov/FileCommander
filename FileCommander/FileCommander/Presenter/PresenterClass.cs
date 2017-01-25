using FileCommander.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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


        }
        //vr
        private void FileCommanderView_listViewEvent(object sender, EventArgs e)
        {
            try
            {
                this.fileCommanderView.listView1.Items.Clear();
                //foreach (string folderName in GetFoldersNames(this.fileCommanderView.comboBox1.Text))
                //{               
                //     this.fileCommanderView.listView1.Items.Add(folderName, 1);       
                //}
                foreach (DirectoryInfo dirInfo in GetFolders(this.fileCommanderView.comboBox1.Text))
                {
                    string[] row1 = { "FOLDER", "", dirInfo.LastWriteTime.ToShortDateString() };
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
            catch (Exception ex)
            {
                //fileCommanderView.MessageBox.Show(ex.Message);
            }

        }
            
            


        //private void FileCommanderView_webBrowserEvent(object sender, EventArgs e)
        //{
        //    this.fileCommanderView.webBrowser1.Url = new Uri(this.fileCommanderView.comboBox1.Text);
        //}

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

    }
}
