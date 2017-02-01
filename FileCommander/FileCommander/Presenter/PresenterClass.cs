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
           


            this.fileCommanderView.listViewEvent += FileCommanderView_listViewEvent1;
            this.fileCommanderView.listViewEventRight += FileCommanderView_listViewEvent2;
            this.fileCommanderView.selectedItemsEvent += FileCommanderView_SelectedItemsEvent;
            this.fileCommanderView.listView_KeySpaceEvent += FileCommanderView_listView1_KeySpaceEvent;
            this.fileCommanderView.listView_KeySpaceEvent += FileCommanderView_listView2_KeySpaceEvent;
            this.fileCommanderView.listView_KeyBackSpaceEvent += FileCommanderView_listView1_KeyBackSpaceEvent;
            this.fileCommanderView.listView_KeyBackSpaceEvent += FileCommanderView_listView2_KeyBackSpaceEvent;
            this.fileCommanderView.listView_KeyEnterEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.listView_KeyEnterEvent += FileCommanderView_listView2_OpenFolder;
            this.fileCommanderView.listView_KeyDeleteEvent += FileCommanderView_listView1_DeleteEvent;
            this.fileCommanderView.listView_KeyDeleteEvent += FileCommanderView_listView2_DeleteEvent;
            this.fileCommanderView.listView_CreateNewFolderEvent += FileCommanderView_listView1_CreateNewDirectoryEvent;
            this.fileCommanderView.listView_CreateNewFolderEvent += FileCommanderView_listView2_CreateNewDirectoryEvent;
            this.fileCommanderView.listView_MouseDoubleClickEvent += FileCommanderView_listView1_OpenFolder;
            this.fileCommanderView.listView_MouseDoubleClickEvent += FileCommanderView_listView2_OpenFolder;
            this.fileCommanderView.renameDirEvent += FileCommanderView_listView1_renameDirEvent;
            this.fileCommanderView.renameDirEvent += FileCommanderView_listView2_renameDirEvent;
            this.fileCommanderView.copyDirEvent += FileCommanderView_listView1_copyDirEvent;
            this.fileCommanderView.copyDirEvent += FileCommanderView_listView2_copyDirEvent;


        }


        //path for selected item in Active tab
        //internal void PathForActiveView(string srcAct, string destAct)
        //{
          
        // if (this.fileCommanderView.IsItemSelectedView2() == true)
        //    {
        //        string tmp;
        //        tmp = CurrentPath1;
        //        CurrentPath1 =CurrentPath2;
        //        CurrentPath2 = tmp;

        //    }
        //}




        //copy directory
        private void FileCommanderView_listView1_copyDirEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
                                        
                // CHECK IF FOLDER Or fILE.
                if (IsFolder1())
                {
                    CopyDirectory1();
                }
                else
                {
                    CopyFile1();
                }
                
                ListView2Clear();
                PopulateListView2();
             
            
        }

        private void FileCommanderView_listView2_copyDirEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView2Active)
            {
                return;
            }

            if (!fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            // CHECK IF FOLDER Or fILE.
            if (IsFolder2())
            {
                CopyDirectory2();
            }
            else
            {
                CopyFile2();
            }

            ListView1Clear();
            PopulateListView1();

        }

        
        // rename directory or file
        private void FileCommanderView_listView1_renameDirEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!this.fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
            
            string srcDir = CurrentPath1 + this.fileCommanderView.SelectedItemText1();
            string destDir = CurrentPath1 + fileCommanderView.NewDirectoryNameInput;

            directoryModel.Move_Rename_Directory(srcDir, destDir);

         
            ListView1Clear();
            PopulateListView1();
            

        }

        private void FileCommanderView_listView2_renameDirEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsListView2Active)
            {
                return;
            }

            if (!this.fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            string srcDir = CurrentPath2 + this.fileCommanderView.SelectedItemText2();
            string destDir = CurrentPath2 + fileCommanderView.NewDirectoryNameInput;

            directoryModel.Move_Rename_Directory(srcDir, destDir);


            ListView2Clear();
            PopulateListView2();


        }



        private void FileCommanderView_listView1_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView1Active)
            {
                return;
            }
            CreateNewDirectory1();
            ListView1Clear();
            PopulateListView1();
        }

        private void FileCommanderView_listView2_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView2Active)
            {
                return;
            }
            CreateNewDirectory2();
            ListView2Clear();
            PopulateListView2();
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
            if (!fileCommanderView.IsListView1Active)
            {
                return;
            }
            if (!fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
            //int intselectedindex = this.fileCommanderView.listView1.SelectedIndices[0];

            // if (fileCommanderView.listView1.SelectedItems[0].Text == ".." & fileCommanderView.listView1.SelectedItems[0].SubItems[1].Text == " ")
            if (fileCommanderView.SelectedItemText1() == "..")
            {
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this.fileCommanderView.TextBox1 = CurrentPath1;


                PopulateListView1();
            }




            // CHECK IF FOLDER Or fILE.
            else
            {
                if (IsFolder1())
                {
                    //if folder open it

                    if (fileCommanderView.IsItemSelectedView1())
                    {
                        pathHistory1.Push(CurrentPath1);
                        this.fileCommanderView.TextBox1 = CurrentPath1 + this.fileCommanderView.SelectedItemText1() + "\\";
                        CurrentPath1 = this.fileCommanderView.TextBox1;

                    }

                    ListView1Clear();
                    PopulateListView1();
                }
                else
                {// if file - run it
                    RunFile1();
                }
            }
            

        }

        private void FileCommanderView_listView2_OpenFolder(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!this.fileCommanderView.IsItemSelectedView2())
            {
                return;
            }
            if (fileCommanderView.SelectedItemText2() == "..")
            {
                ListView2Clear();
                CurrentPath2 = pathHistory2.Pop();
                this.fileCommanderView.TextBox2 = CurrentPath2;


                PopulateListView2();
            }

            else
            {
                // CHECK IF FOLDER Or fILE.
                if (IsFolder2())
                {
                    //if folder open it

                    if (fileCommanderView.IsItemSelectedView2())
                    {
                        pathHistory2.Push(CurrentPath2);
                        this.fileCommanderView.TextBox2 = CurrentPath2 + this.fileCommanderView.SelectedItemText2() + "\\";
                        CurrentPath2 = this.fileCommanderView.TextBox2;

                    }

                    ListView2Clear();

                    PopulateListView2();
                }
                else
                {// if file - run it
                    RunFile2();
                }
            }

        }

        private void FileCommanderView_listView1_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView1Active)
            {
                return;
            }
            if (pathHistory1.Count > 1)
            {
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this.fileCommanderView.TextBox1 = CurrentPath1;


                PopulateListView1();
            }

        }

        private void FileCommanderView_listView2_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (!fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (pathHistory2.Count > 1)
            {
                ListView2Clear();
                CurrentPath2 = pathHistory2.Pop();
                this.fileCommanderView.TextBox2 = CurrentPath2;


                PopulateListView2();
            }

        }

        private void FileCommanderView_listView1_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
            
            string selectedFolder = CurrentPath1 + this.fileCommanderView.SelectedItemText1();

            //DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);
            
               GetFolderSize1(selectedFolder);
            
        }
        private void FileCommanderView_listView2_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!this.fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            string selectedFolder = CurrentPath2 + this.fileCommanderView.SelectedItemText2();

            //DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);

            GetFolderSize2(selectedFolder);

        }



        // selected item for list view 1

        private void FileCommanderView_SelectedItemsEvent(object sender, EventArgs e)
        {
            
        }
        //Right panel
        private void FileCommanderView_listViewEvent2(object sender, EventArgs e)
        {

            CurrentPath2 = this.fileCommanderView.SelectedDrive2;
            this.fileCommanderView.TextBox2 = CurrentPath2;
            pathHistory2.Clear();

            ListView2Clear();
            


            PopulateListView2();

            pathHistory2.Push(CurrentPath2);

        }

        

        private void FileCommanderView_listViewEvent1(object sender, EventArgs e)
        {

            CurrentPath1 = this.fileCommanderView.SelectedDrive1;
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



        public void GetFolderSize1(string currentPath)
        {
            this.fileCommanderView.UpdateSelectedItem1Size(directoryModel.SelectedFolderSize(currentPath).ToString());
        }

        public void GetFolderSize2(string currentPath)
        {
            this.fileCommanderView.UpdateSelectedItem2Size(directoryModel.SelectedFolderSize(currentPath).ToString());
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

        public bool IsFolder1()
        {
            if (directoryModel.IsFolder(CurrentPath1 + this.fileCommanderView.SelectedItemText1()))
                return true;
            else return false;
        }

        public bool IsFolder2()
        {
            if (directoryModel.IsFolder(CurrentPath2 + this.fileCommanderView.SelectedItemText2()))
                return true;
            else return false;
        }

        public void RunFile1()
        {
            fileModel.RunFile(CurrentPath1 + this.fileCommanderView.SelectedItemText1());
        }

        public void RunFile2()
        {
            fileModel.RunFile(CurrentPath2 + this.fileCommanderView.SelectedItemText2());
        }

        public void CopyDirectory1()
        {
            //int intselectedindex = this.fileCommanderView.SelectedIndexForActiveView();
            string srcAct = CurrentPath1 + this.fileCommanderView.SelectedItemText1();
            string destAct = CurrentPath2 + this.fileCommanderView.SelectedItemText1();

            directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyDirectory2()
        {
            //int intselectedindex = this.fileCommanderView.SelectedIndexForActiveView();
            string srcAct = CurrentPath2 + this.fileCommanderView.SelectedItemText2();
            string destAct = CurrentPath1 + this.fileCommanderView.SelectedItemText2();

            directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyFile1()
        {
            string srcAct = CurrentPath1 + this.fileCommanderView.SelectedItemText1();
            string destAct = CurrentPath2 + this.fileCommanderView.SelectedItemText1();
            fileModel.CopyFile(srcAct, destAct);
        }

        public void CopyFile2()
        {
            string srcAct = CurrentPath2 + this.fileCommanderView.SelectedItemText2();
            string destAct = CurrentPath1 + this.fileCommanderView.SelectedItemText2();
            fileModel.CopyFile(srcAct, destAct);
        }

        //Directory.Delete(currentPath + listViewSelectedItem, true)

    }
}
