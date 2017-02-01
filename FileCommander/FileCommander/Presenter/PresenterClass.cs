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
        IDriveModel driveModel;
        IDirectoryModel directoryModel;
        readonly IFileModel _fileModel;
        //    DirectoryInfo dirInfo;

        public List<string> GetDrives { get { return driveModel.DrivesName; } }
        private string CurrentPath1;
        private string CurrentPath2;
        private readonly IFileCommanderView _fileCommanderView;
        public Stack<string> pathHistory1 = new Stack<string>();
        public Stack<string> pathHistory2 = new Stack<string>();



        public PresenterClass(FileCommanderView fileCommanderView)
        {
            driveModel = new Model.DriveModel();
            directoryModel = new DirectoryModel();
            _fileModel = new FileModel();
            this._fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;



            this._fileCommanderView.ListViewEvent += FileCommanderView_listViewEvent1;
            this._fileCommanderView.ListViewEventRight += FileCommanderView_listViewEvent2;
            this._fileCommanderView.SelectedItemsEvent += FileCommanderView_SelectedItemsEvent;
            this._fileCommanderView.ListViewKeySpaceEvent += FileCommanderView_listView1_KeySpaceEvent;
            this._fileCommanderView.ListViewKeySpaceEvent += FileCommanderView_listView2_KeySpaceEvent;
            this._fileCommanderView.ListViewKeyBackSpaceEvent += FileCommanderView_listView1_KeyBackSpaceEvent;
            this._fileCommanderView.ListViewKeyBackSpaceEvent += FileCommanderView_listView2_KeyBackSpaceEvent;
            this._fileCommanderView.ListViewKeyEnterEvent += FileCommanderView_listView1_OpenFolder;
            this._fileCommanderView.ListViewKeyEnterEvent += FileCommanderView_listView2_OpenFolder;
            this._fileCommanderView.ListViewKeyDeleteEvent += FileCommanderView_listView1_DeleteEvent;
            this._fileCommanderView.ListViewKeyDeleteEvent += FileCommanderView_listView2_DeleteEvent;
            this._fileCommanderView.ListViewCreateNewFolderEvent += FileCommanderView_listView1_CreateNewDirectoryEvent;
            this._fileCommanderView.ListViewCreateNewFolderEvent += FileCommanderView_listView2_CreateNewDirectoryEvent;
            this._fileCommanderView.ListViewMouseDoubleClickEvent += FileCommanderView_listView1_OpenFolder;
            this._fileCommanderView.ListViewMouseDoubleClickEvent += FileCommanderView_listView2_OpenFolder;
            this._fileCommanderView.RenameDirEvent += FileCommanderView_listView1_renameDirEvent;
            this._fileCommanderView.RenameDirEvent += FileCommanderView_listView2_renameDirEvent;
            this._fileCommanderView.CopyDirEvent += FileCommanderView_listView1_copyDirEvent;
            this._fileCommanderView.CopyDirEvent += FileCommanderView_listView2_copyDirEvent;


        }


           //copy directory
        private void FileCommanderView_listView1_copyDirEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!_fileCommanderView.IsItemSelectedView1())
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
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }

            if (!_fileCommanderView.IsItemSelectedView2())
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


        // rename directory or file left
        private void FileCommanderView_listView1_renameDirEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!this._fileCommanderView.IsItemSelectedView1())
            {
                return;
            }

            string srcDir = CurrentPath1 + this._fileCommanderView.SelectedItemText1();
            string destDir = CurrentPath1 + _fileCommanderView.NewDirectoryNameInput;

            directoryModel.MoveRenameDirectory(srcDir, destDir);


            ListView1Clear();
            PopulateListView1();


        }
        // rename directory or file right
        private void FileCommanderView_listView2_renameDirEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsListView2Active)
            {
                return;
            }

            if (!this._fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            string srcDir = CurrentPath2 + this._fileCommanderView.SelectedItemText2();
            string destDir = CurrentPath2 + _fileCommanderView.NewDirectoryNameInput;

            directoryModel.MoveRenameDirectory(srcDir, destDir);


            ListView2Clear();
            PopulateListView2();


        }


        // create new dir rithtEvent
        private void FileCommanderView_listView1_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }
            CreateNewDirectory1();
            ListView1Clear();
            PopulateListView1();
        }
        // create new dir rithtEvent
        private void FileCommanderView_listView2_CreateNewDirectoryEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }
            CreateNewDirectory2();
            ListView2Clear();
            PopulateListView2();
        }
        //delete event left
        private void FileCommanderView_listView1_DeleteEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!this._fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
            

            if (_fileCommanderView.SelectedItem1Type() == "FOLDER")
            {
                DeleteDirectoyr1();
            }
            else if (_fileCommanderView.SelectedItem1Type() == "FILE")
            {
                DeleteFile1();
            }


            ListView1Clear();
            PopulateListView1();

        }
        //delete event right
        private void FileCommanderView_listView2_DeleteEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!this._fileCommanderView.IsItemSelectedView2())
            {
                return;
            }
  

            if (_fileCommanderView.SelectedItem2Type() == "FOLDER")
            {
                DeleteDirectoyr2();
            }
            else if (_fileCommanderView.SelectedItem2Type() == "FILE")
            {
                DeleteFile2();
            }


            ListView2Clear();
            PopulateListView2();

        }
        // open folder left
        private void FileCommanderView_listView1_OpenFolder(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }
            if (!_fileCommanderView.IsItemSelectedView1())
            {
                return;
            }
          if (_fileCommanderView.SelectedItemText1() == "..")
            {
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this._fileCommanderView.TextBox1 = CurrentPath1;


                PopulateListView1();
            }

            // CHECK IF FOLDER Or fILE.
            else
            {
                if (IsFolder1())
                {
                    //if folder open it

                    if (_fileCommanderView.IsItemSelectedView1())
                    {
                        pathHistory1.Push(CurrentPath1);
                        this._fileCommanderView.TextBox1 = CurrentPath1 + this._fileCommanderView.SelectedItemText1() + "\\";
                        CurrentPath1 = this._fileCommanderView.TextBox1;

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
        // open folder right
        private void FileCommanderView_listView2_OpenFolder(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!this._fileCommanderView.IsItemSelectedView2())
            {
                return;
            }
            if (_fileCommanderView.SelectedItemText2() == "..")
            {
                ListView2Clear();
                CurrentPath2 = pathHistory2.Pop();
                this._fileCommanderView.TextBox2 = CurrentPath2;


                PopulateListView2();
            }

            else
            {
                // CHECK IF FOLDER Or fILE.
                if (IsFolder2())
                {
                    //if folder open it

                    if (_fileCommanderView.IsItemSelectedView2())
                    {
                        pathHistory2.Push(CurrentPath2);
                        this._fileCommanderView.TextBox2 = CurrentPath2 + this._fileCommanderView.SelectedItemText2() + "\\";
                        CurrentPath2 = this._fileCommanderView.TextBox2;

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
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }
            if (pathHistory1.Count > 1)
            {
                ListView1Clear();
                CurrentPath1 = pathHistory1.Pop();
                this._fileCommanderView.TextBox1 = CurrentPath1;


                PopulateListView1();
            }

        }

        private void FileCommanderView_listView2_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (pathHistory2.Count > 1)
            {
                ListView2Clear();
                CurrentPath2 = pathHistory2.Pop();
                this._fileCommanderView.TextBox2 = CurrentPath2;


                PopulateListView2();
            }

        }

        private void FileCommanderView_listView1_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsItemSelectedView1())
            {
                return;
            }

            string selectedFolder = CurrentPath1 + this._fileCommanderView.SelectedItemText1();


            GetFolderSize1(selectedFolder);

        }
        private void FileCommanderView_listView2_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!this._fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            string selectedFolder = CurrentPath2 + this._fileCommanderView.SelectedItemText2();



            GetFolderSize2(selectedFolder);

        }



        // selected item for list view 1

        private void FileCommanderView_SelectedItemsEvent(object sender, EventArgs e)
        {

        }
        //Right panel
        private void FileCommanderView_listViewEvent2(object sender, EventArgs e)
        {

            CurrentPath2 = this._fileCommanderView.SelectedDrive2;
            this._fileCommanderView.TextBox2 = CurrentPath2;
            pathHistory2.Clear();

            ListView2Clear();



            PopulateListView2();

            pathHistory2.Push(CurrentPath2);

        }



        private void FileCommanderView_listViewEvent1(object sender, EventArgs e)
        {

            CurrentPath1 = this._fileCommanderView.SelectedDrive1;
            this._fileCommanderView.TextBox1 = CurrentPath1;
            pathHistory1.Clear();
            ListView1Clear();
            PopulateListView1();
            pathHistory1.Push(CurrentPath1);

        }

        private void PopulateListView1()
        {
            this._fileCommanderView.PopulateListView1(directoryModel.GetDirectoriesInfo(CurrentPath1), _fileModel.GetFilesInfo(CurrentPath1), pathHistory1.Count);
        }


        private void PopulateListView2()
        {
            _fileCommanderView.PopulateListView2(directoryModel.GetDirectoriesInfo(CurrentPath2), _fileModel.GetFilesInfo(CurrentPath2), pathHistory2.Count);
        }



        public void GetFolderSize1(string currentPath)
        {
            this._fileCommanderView.UpdateSelectedItem1Size(directoryModel.SelectedFolderSize(currentPath).ToString());
        }

        public void GetFolderSize2(string currentPath)
        {
            this._fileCommanderView.UpdateSelectedItem2Size(directoryModel.SelectedFolderSize(currentPath).ToString());
        }

        public void ListView1Clear()
        {
            this._fileCommanderView.ListView1Clear();
        }

        public void ListView2Clear()
        {
            this._fileCommanderView.ListView2Clear();
        }

        public void CreateNewDirectory1()
        {
            directoryModel.CreateNewDirectory(CurrentPath1, _fileCommanderView.NewDirectoryNameInput);
        }

        public void CreateNewDirectory2()
        {
            directoryModel.CreateNewDirectory(CurrentPath2, _fileCommanderView.NewDirectoryNameInput);
        }

        public void DeleteDirectoyr1()
        {
            directoryModel.DeleteDirectory(CurrentPath1, _fileCommanderView.SelectedItemText1());
        }

        public void DeleteDirectoyr2()
        {
            directoryModel.DeleteDirectory(CurrentPath2, _fileCommanderView.SelectedItemText2());
        }

        public void DeleteFile1()
        {
            _fileModel.DeleteFile(CurrentPath1, _fileCommanderView.SelectedItemText1());
        }

        public void DeleteFile2()
        {
            _fileModel.DeleteFile(CurrentPath2, _fileCommanderView.SelectedItemText2());
        }

        public bool IsFolder1()
        {
            if (directoryModel.IsFolder(CurrentPath1 + this._fileCommanderView.SelectedItemText1()))
                return true;
            else return false;
        }

        public bool IsFolder2()
        {
            if (directoryModel.IsFolder(CurrentPath2 + this._fileCommanderView.SelectedItemText2()))
                return true;
            else return false;
        }

        public void RunFile1()
        {
            _fileModel.RunFile(CurrentPath1 + this._fileCommanderView.SelectedItemText1());
        }

        public void RunFile2()
        {
            _fileModel.RunFile(CurrentPath2 + this._fileCommanderView.SelectedItemText2());
        }

        public void CopyDirectory1()
        {
            string srcAct = CurrentPath1 + this._fileCommanderView.SelectedItemText1();
            string destAct = CurrentPath2 + this._fileCommanderView.SelectedItemText1();

            directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyDirectory2()
        {
            string srcAct = CurrentPath2 + this._fileCommanderView.SelectedItemText2();
            string destAct = CurrentPath1 + this._fileCommanderView.SelectedItemText2();

            directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyFile1()
        {
            string srcAct = CurrentPath1 + this._fileCommanderView.SelectedItemText1();
            string destAct = CurrentPath2 + this._fileCommanderView.SelectedItemText1();
            _fileModel.CopyFile(srcAct, destAct);
        }

        public void CopyFile2()
        {
            string srcAct = CurrentPath2 + this._fileCommanderView.SelectedItemText2();
            string destAct = CurrentPath1 + this._fileCommanderView.SelectedItemText2();
            _fileModel.CopyFile(srcAct, destAct);
        }

    }
}
