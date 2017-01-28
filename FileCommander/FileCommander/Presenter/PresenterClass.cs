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
    //    DirectoryInfo dirInfo;

        public List<string> GetDrives { get { return driveModel.DrivesName; } }
        private string CurrentPath { get; set; }
        private FileCommanderView fileCommanderView;
        public Stack<string> pathHistory = new Stack<string>();


        public PresenterClass (FileCommanderView fileCommanderView)
        {
            driveModel = new Model.DriveModel();
            directoryModel = new DirectoryModel();
            fileModel = new FileModel();
            this.fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;
            //this.fileCommanderView.webBrowserEvent += FileCommanderView_webBrowserEvent;
            
            
            // subscribers

            this.fileCommanderView.listViewEvent += FileCommanderView_listViewEvent;
            this.fileCommanderView.listViewEventRight += FileCommanderView_listViewEventRight;
            this.fileCommanderView.selectedItemsEvent += FileCommanderView_SelectedItemsEvent;
            this.fileCommanderView.listView1_KeySpaceEvent += FileCommanderView_listView1_KeySpaceEvent;
            this.fileCommanderView.listView1_KeyBackSpaceEvent += FileCommanderView_listView1_KeyBackSpaceEvent;
            this.fileCommanderView.listView1_KeyEnterEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.listView1_KeyDeleteEvent += FileCommanderView_listView1_DeleteEvent;
            this.fileCommanderView.listView1_KeyF7Event += FileCommanderView_listView1_CreateNewDirectoryEvent;
            this.fileCommanderView.listView1_MouseDoubleClickEvent += FileCommanderView_listView1_OpenFolder;




         }

        private void FileCommanderView_listView1_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            FolderNameDialogForm folderNameDialog = new FolderNameDialogForm();
            DirectoryInfo dirInfo = Directory.CreateDirectory(CurrentPath + "\\" + fileCommanderView.NewDirectoryNameInput);
            this.fileCommanderView.listView1.Items.Clear();
            PopulateListView(CurrentPath);
        }

        private void FileCommanderView_listView1_DeleteEvent(object sender, EventArgs e)
        {
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            if (fileCommanderView.listView1.SelectedItems[0].SubItems[1].Text == "FOLDER")
            {
                Directory.Delete(CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text, true);
            }
            else if (fileCommanderView.listView1.SelectedItems[0].SubItems[1].Text == "FILE")
            {
                File.Delete(CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text);
            }


            this.fileCommanderView.listView1.Items.Clear();
            PopulateListView(CurrentPath);

        }

        private void FileCommanderView_listView1_OpenFolder(object sender, EventArgs e)
        {
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            if (fileCommanderView.listView1.SelectedItems[0].Text == ".." & fileCommanderView.listView1.SelectedItems[0].SubItems[1].Text == " ")
            {
                this.fileCommanderView.listView1.Items.Clear();
                CurrentPath = pathHistory.Pop();
                this.fileCommanderView.textBox1.Text = CurrentPath;


                PopulateListView(CurrentPath);
            }

            else
            {

                FileAttributes attr = File.GetAttributes(CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text);

                // CHECK IF FOLDER Or fILE.
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //if folder open it

                    if (intselectedindex >= 0)
                    {
                        pathHistory.Push(CurrentPath);
                        this.fileCommanderView.textBox1.Text = CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text + "\\";
                        DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.textBox1.Text);
                        CurrentPath = this.fileCommanderView.textBox1.Text;


                    }

                    this.fileCommanderView.listView1.Items.Clear();



                    PopulateListView(CurrentPath);
                }
                else
                {// if file - run it
                    System.Diagnostics.Process.Start(CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text);
                }
            }

        }

        private void FileCommanderView_listView1_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (pathHistory.Count > 1)
            {
                this.fileCommanderView.listView1.Items.Clear();
                CurrentPath = pathHistory.Pop();
                this.fileCommanderView.textBox1.Text = CurrentPath;


                PopulateListView(CurrentPath);
            }

        }

        private void FileCommanderView_listView1_KeySpaceEvent(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.textBox1.Text);
            if (fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text == "<DIR>")
            {
                fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text = GetFolderSize(dirInfo);
            }
        }


        // selected item for list view 1

        private void FileCommanderView_SelectedItemsEvent(object sender, EventArgs e)
        {
            //***if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            //***{
            // ***   return;
            //***}
            //***int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            //***if (intselectedindex >= 0)
            //***{
                //this.fileCommanderView.textBox1.Text = fileCommanderView.comboBox1.Text +  this.fileCommanderView.listView1.Items[intselectedindex].Text;
                
                //***this.fileCommanderView.textBox1.Text = CurrentPath + this.fileCommanderView.listView1.Items[intselectedindex].Text + "\\";
                //***DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.textBox1.Text);
                //string[] row1 = { "SELECTED FOLDER", GetFolderSize(dirInfo), dirInfo.LastWriteTime.ToShortDateString() };
                //this.fileCommanderView.listView1.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
                //ListViewItem item = this.fileCommanderView.listView1.SelectedItems[0];
                /////Calculate Folder Size by Select START
                //if (fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text == "<DIR>")
                //{
                //    fileCommanderView.listView1.SelectedItems[0].SubItems[2].Text = GetFolderSize(dirInfo);
                //}
                /////Calculate Folder Size by Select START
                //     string pathy = null;

                //   this.fileCommanderView.textBox2.Text = this.fileCommanderView.d.ToString(); 
                // fileCommanderView.listView1.Items[intselectedindex].SubItems[0].Text;

                //***CurrentPath = this.fileCommanderView.textBox1.Text;

            //***}
        }
        //Right panel
        private void FileCommanderView_listViewEventRight(object sender, EventArgs e)
        {

            this.fileCommanderView.listView2.Items.Clear();
          
            List<DirectoryInfo> names = GetFolders(this.fileCommanderView.comboBox2.Text);

            foreach (DirectoryInfo dirInfo in GetFolders(this.fileCommanderView.comboBox2.Text))
            {
                string[] row1 = { "FOLDER", "<DIR>", dirInfo.LastWriteTime.ToShortDateString() };
                this.fileCommanderView.listView2.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
            }

            
            foreach (FileInfo fileInfo in GetFiles(this.fileCommanderView.comboBox1.Text))
            {
                string[] row1 = { "FILE", (((fileInfo.Length / 1024)).ToString("0.00")), fileInfo.LastWriteTime.ToShortDateString() };
                this.fileCommanderView.listView2.Items.Add(fileInfo.Name, 0).SubItems.AddRange(row1);
            }





        }

        

        private void FileCommanderView_listViewEvent(object sender, EventArgs e)
        {

            CurrentPath = this.fileCommanderView.comboBox1.Text;
            this.fileCommanderView.textBox1.Text = CurrentPath;
            pathHistory.Clear();

            this.fileCommanderView.listView1.Items.Clear();




                PopulateListView(CurrentPath);

                pathHistory.Push(CurrentPath);

        }

        private void PopulateListView(string currentPath)
        {

            if (pathHistory.Count > 1)
            {
                this.fileCommanderView.listView1.Items.Add("..").SubItems.Add(" ");
            }
                foreach (DirectoryInfo dirInfo in GetFolders(currentPath))
                {
                
                    string[] row1 = { "FOLDER", "<DIR>", dirInfo.LastWriteTime.ToShortDateString() };
                    this.fileCommanderView.listView1.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
                }


                foreach (FileInfo fileInfo in GetFiles(currentPath))
                {
                    string[] row1 = { "FILE", (((fileInfo.Length / 1024)).ToString("0.00")), fileInfo.LastWriteTime.ToShortDateString() };
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
