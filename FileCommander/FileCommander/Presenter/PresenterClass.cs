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
        private string CurrentPathLeft;
        private string CurrentPathRight;
        private FileCommanderView fileCommanderView;
        public Stack<string> pathHistoryLeft = new Stack<string>();
        public Stack<string> pathHistoryRight = new Stack<string>();

        public PresenterClass(FileCommanderView fileCommanderView)
        {
            driveModel = new Model.DriveModel();
            directoryModel = new DirectoryModel();
            fileModel = new FileModel();
            this.fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;
            //this.fileCommanderView.webBrowserEvent += FileCommanderView_webBrowserEvent;


            this.fileCommanderView.listViewEvent += FileCommanderView_listViewEvent;
            this.fileCommanderView.listViewEventRight += FileCommanderView_listViewEventRight;
            this.fileCommanderView.selectedItemsEvent += FileCommanderView_SelectedItemsEvent;
            this.fileCommanderView.listView1_KeySpaceEvent += FileCommanderView_listView1_KeySpaceEvent;
            this.fileCommanderView.listView1_KeyBackSpaceEvent += FileCommanderView_listView1_KeyBackSpaceEvent;
            this.fileCommanderView.listView1_KeyEnterEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.listView1_KeyDeleteEvent += FileCommanderView_listView1_DeleteEvent;
            this.fileCommanderView.listView1_KeyF7Event += FileCommanderView_listView1_CreateNewDirectoryEvent;
            this.fileCommanderView.listView1_MouseDoubleClickEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.renameDirEvent += FileCommanderView_listView1_renameDirEvent;
            //    this.fileCommanderView.copyDirEvent += FileCommanderView_listView1_copyDirEvent;
        }
            /*
        }
        //copy directory
        private void FileCommanderView_listView1_copyDirEvent(object sender, EventArgs e)
        {


            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            else
            {
                int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];
                string srcDir = CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text;
                string destDir = CurrentPathRight;

                directoryModel.CopyDirectory(srcDir, destDir);


                this.fileCommanderView.listView1.Items.Clear();
                PopulateListViewLeft(CurrentPathRight);
            }

        }
        */



        // rename directory or file
        private void FileCommanderView_listView1_renameDirEvent(object sender, EventArgs e)
        {

            
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];
            string srcDir = CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text;
            string destDir = CurrentPathLeft + fileCommanderView.NewDirectoryNameInput;

            directoryModel.Move_Rename_Directory(srcDir, destDir);

         
            this.fileCommanderView.listView1.Items.Clear();
            PopulateListViewLeft(CurrentPathLeft);
            

        }



        private void FileCommanderView_listView1_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            FolderNameDialogForm folderNameDialog = new FolderNameDialogForm();
            DirectoryInfo dirInfo = Directory.CreateDirectory(CurrentPathLeft + "\\" + fileCommanderView.NewDirectoryNameInput);
            this.fileCommanderView.listView1.Items.Clear();
            PopulateListViewLeft(CurrentPathLeft);
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
                Directory.Delete(CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text, true);
            }
            else if (fileCommanderView.listView1.SelectedItems[0].SubItems[1].Text == "FILE")
            {
                File.Delete(CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text);
            }


            this.fileCommanderView.listView1.Items.Clear();
            PopulateListViewLeft(CurrentPathLeft);

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
                CurrentPathLeft = pathHistoryLeft.Pop();
                this.fileCommanderView.textBox1.Text = CurrentPathLeft;


                PopulateListViewLeft(CurrentPathLeft);
            }

            else
            {

                FileAttributes attr = File.GetAttributes(CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text);

                // CHECK IF FOLDER Or fILE.
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //if folder open it

                    if (intselectedindex >= 0)
                    {
                        pathHistoryLeft.Push(CurrentPathLeft);
                        this.fileCommanderView.textBox1.Text = CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text + "\\";
                        DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.textBox1.Text);
                        CurrentPathLeft = this.fileCommanderView.textBox1.Text;


                    }

                    this.fileCommanderView.listView1.Items.Clear();



                    PopulateListViewLeft(CurrentPathLeft);
                }
                else
                {// if file - run it
                    System.Diagnostics.Process.Start(CurrentPathLeft + this.fileCommanderView.listView1.Items[intselectedindex].Text);
                }
            }

        }

        private void FileCommanderView_listView1_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (pathHistoryLeft.Count > 1)
            {
                this.fileCommanderView.listView1.Items.Clear();
                CurrentPathLeft = pathHistoryLeft.Pop();
                this.fileCommanderView.textBox1.Text = CurrentPathLeft;


                PopulateListViewLeft(CurrentPathLeft);
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
            
        }
        //Right panel
        private void FileCommanderView_listViewEventRight(object sender, EventArgs e)
        {

            CurrentPathRight = this.fileCommanderView.comboBox2.Text;
            this.fileCommanderView.textBox2.Text = CurrentPathRight;
            pathHistoryRight.Clear();

            this.fileCommanderView.listView2.Items.Clear();




            PopulateListViewRight(CurrentPathRight);

            pathHistoryRight.Push(CurrentPathRight);
            
        }

        

        private void FileCommanderView_listViewEvent(object sender, EventArgs e)
        {

            CurrentPathLeft = this.fileCommanderView.comboBox1.Text;
            this.fileCommanderView.textBox1.Text = CurrentPathLeft;
            pathHistoryLeft.Clear();

            this.fileCommanderView.listView1.Items.Clear();




                PopulateListViewLeft(CurrentPathLeft);

                pathHistoryLeft.Push(CurrentPathLeft);

        }

        private void PopulateListViewLeft(string currentPath)
        {

            if (pathHistoryLeft.Count > 1)
            {
                this.fileCommanderView.listView1.Items.Add("..", 2).SubItems.Add(" ");
            }
                
                foreach (var dirInfo in directoryModel.GetDirectoriesInfo(currentPath))
                {
                     this.fileCommanderView.listView1.Items.Add(dirInfo.Key, 1).SubItems.AddRange(dirInfo.Value);
                }

                foreach (var  fileInfo in fileModel.GetFilesInfo(currentPath))
                {                   
                    this.fileCommanderView.listView1.Items.Add(fileInfo.Key, 0).SubItems.AddRange(fileInfo.Value);
                }
            
        }

        private void PopulateListViewRight(string currentPath)
        {

            if (pathHistoryRight.Count > 1)
            {
                this.fileCommanderView.listView2.Items.Add("..").SubItems.Add(" ");
            }

            foreach (var dirInfo in directoryModel.GetDirectoriesInfo(currentPath))
            {
                this.fileCommanderView.listView2.Items.Add(dirInfo.Key, 1).SubItems.AddRange(dirInfo.Value);
            }

            foreach (var fileInfo in fileModel.GetFilesInfo(currentPath))
            {
                this.fileCommanderView.listView2.Items.Add(fileInfo.Key, 0).SubItems.AddRange(fileInfo.Value);
            }

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
