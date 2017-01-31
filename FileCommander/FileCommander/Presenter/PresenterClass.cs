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
        private string CurrentPath1;
        private string CurrentPath2;
        private FileCommanderView fileCommanderView;
        public Stack<string> pathHistory1 = new Stack<string>();
        public Stack<string> pathHistory2 = new Stack<string>();

        public PresenterClass(FileCommanderView fileCommanderView)
        {
            driveModel = new Model.DriveModel();
            directoryModel = new DirectoryModel();
            fileModel = new FileModel();
            this.fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;
            //this.fileCommanderView.webBrowserEvent += FileCommanderView_webBrowserEvent;


            this.fileCommanderView.listViewEvent += FileCommanderView_listViewEvent1;
            this.fileCommanderView.listViewEventRight += FileCommanderView_listViewEvent2;
            this.fileCommanderView.selectedItemsEvent += FileCommanderView_SelectedItemsEvent;
            this.fileCommanderView.listView1_KeySpaceEvent += FileCommanderView_listView1_KeySpaceEvent;
            this.fileCommanderView.listView1_KeyBackSpaceEvent += FileCommanderView_listView1_KeyBackSpaceEvent;
            this.fileCommanderView.listView1_KeyEnterEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.listView_KeyDeleteEvent += FileCommanderView_listView1_DeleteEvent;
            this.fileCommanderView.listView_KeyDeleteEvent += FileCommanderView_listView2_DeleteEvent;
            this.fileCommanderView.listView1_KeyF7Event += FileCommanderView_listView1_CreateNewDirectoryEvent;
            this.fileCommanderView.listView1_MouseDoubleClickEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.renameDirEvent += FileCommanderView_listView1_renameDirEvent;
                this.fileCommanderView.copyDirEvent += FileCommanderView_listView1_copyDirEvent;
        
            
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
                string srcDir = CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text;
                string destDir = CurrentPath2 + this.fileCommanderView.listView1.Items[intselectedindex].Text;

                
                // CHECK IF FOLDER Or fILE.
                FileAttributes attr = File.GetAttributes(CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    directoryModel.CopyDirectory(srcDir, destDir);
                }
                else
                {
                    directoryModel.CopyFile(srcDir, destDir);
                }
                
                ListView1Clear();
                PopulateListView1();
             
            }

        }
        



        // rename directory or file
        private void FileCommanderView_listView1_renameDirEvent(object sender, EventArgs e)
        {

            
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];
            string srcDir = CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text;
            string destDir = CurrentPath1 + fileCommanderView.NewDirectoryNameInput;

            directoryModel.Move_Rename_Directory(srcDir, destDir);

         
            ListView1Clear();
            PopulateListView1();
            

        }



        private void FileCommanderView_listView1_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            CreateNewDirectory1();
            ListView1Clear();
            PopulateListView1();
        }

        private void FileCommanderView_listView1_DeleteEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!this.fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
            //int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            if (fileCommanderView.SelectedItem1Type() == "FOLDER")
            {
                DeleteDirectoyr1();
            }
            else if (fileCommanderView.SelectedItem1Type() == "FILE")
            {
                DeleteFile1();
            }


            ListView1Clear();
            PopulateListView1();

        }

        private void FileCommanderView_listView2_DeleteEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!this.fileCommanderView.IsItemSelectedView2())
            {
                return;
            }
            //int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            if (fileCommanderView.SelectedItem2Type() == "FOLDER")
            {
                DeleteDirectoyr2();
            }
            else if (fileCommanderView.SelectedItem2Type() == "FILE")
            {
                DeleteFile2();
            }


            ListView2Clear();
            PopulateListView2();

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
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this.fileCommanderView.TextBox1= CurrentPath1;


                PopulateListView1();
            }

            else
            {

                FileAttributes attr = File.GetAttributes(CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text);

                // CHECK IF FOLDER Or fILE.
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //if folder open it

                    if (intselectedindex >= 0)
                    {
                        pathHistory1.Push(CurrentPath1);
                        this.fileCommanderView.TextBox1 = CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text + "\\";
                        DirectoryInfo dirInfo = new DirectoryInfo(this.fileCommanderView.TextBox1);
                        CurrentPath1 = this.fileCommanderView.TextBox1;


                    }

                   ListView1Clear();



                    PopulateListView1();
                }
                else
                {// if file - run it
                    System.Diagnostics.Process.Start(CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text);
                }
            }

        }

        private void FileCommanderView_listView1_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (pathHistory1.Count > 1)
            {
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this.fileCommanderView.TextBox1 = CurrentPath1;


                PopulateListView1();
            }

        }

        private void FileCommanderView_listView1_KeySpaceEvent(object sender, EventArgs e)
        {
            if (this.fileCommanderView.listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];
            string selectedFolder = CurrentPath1 + this.fileCommanderView.listView1.Items[intselectedindex].Text;

            DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);
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
        private void FileCommanderView_listViewEvent2(object sender, EventArgs e)
        {

            CurrentPath2 = this.fileCommanderView.comboBox2.Text;
            this.fileCommanderView.TextBox2 = CurrentPath2;
            pathHistory2.Clear();

            ListView2Clear();
            


            PopulateListView2();

            pathHistory2.Push(CurrentPath2);

        }

        

        private void FileCommanderView_listViewEvent1(object sender, EventArgs e)
        {

            CurrentPath1 = this.fileCommanderView.comboBox1.Text;
            this.fileCommanderView.TextBox1 = CurrentPath1;
            pathHistory1.Clear();
            ListView1Clear();




                PopulateListView1();

                pathHistory1.Push(CurrentPath1);

        }

        private void PopulateListView1()
        {
            this.fileCommanderView.PopulateListView1(directoryModel.GetDirectoriesInfo(CurrentPath1), fileModel.GetFilesInfo(CurrentPath1), pathHistory1.Count);
        }


        private void PopulateListView2()
        {
            fileCommanderView.PopulateListView2(directoryModel.GetDirectoriesInfo(CurrentPath2), fileModel.GetFilesInfo(CurrentPath2), pathHistory2.Count);
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

        public void ListView1Clear()
        {
            this.fileCommanderView.ListView1Clear();
        }

        public void ListView2Clear()
        {
            this.fileCommanderView.ListView2Clear();
        }

        public void CreateNewDirectory1()
        {
            directoryModel.CreateNewDirectory(CurrentPath1, fileCommanderView.NewDirectoryNameInput);
        }

        public void CreateNewDirectory2()
        {
            directoryModel.CreateNewDirectory(CurrentPath2, fileCommanderView.NewDirectoryNameInput);
        }

        public void DeleteDirectoyr1()
        {
            directoryModel.DeleteDirectory(CurrentPath1, fileCommanderView.SelectedItemText1());
        }

        public void DeleteDirectoyr2()
        {
            directoryModel.DeleteDirectory(CurrentPath2, fileCommanderView.SelectedItemText2());
        }

        public void DeleteFile1()
        {
            fileModel.DeleteFile(CurrentPath1, fileCommanderView.SelectedItemText1());
        }

        public void DeleteFile2()
        {
            fileModel.DeleteFile(CurrentPath2, fileCommanderView.SelectedItemText2());
        }


        //Directory.Delete(currentPath + listViewSelectedItem, true)

    }
}
