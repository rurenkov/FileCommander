using FileCommander.Model;
using System;
using System.Collections.Generic;

//using System.Windows.Forms;

namespace FileCommander.Presenter
{
    public class PresenterClass
    {
        readonly IDriveModel _driveModel;
        readonly IDirectoryModel _directoryModel;
        readonly IFileModel _fileModel;
        //    DirectoryInfo dirInfo;

        public List<string> GetDrives
        {
            get { return _driveModel.DrivesName; }
        }

        private string _currentPath1;
        private string _currentPath2;
        private readonly IFileCommanderView _fileCommanderView;
        public Stack<string> PathHistory1 = new Stack<string>();
        public Stack<string> PathHistory2 = new Stack<string>();



        public PresenterClass(FileCommanderView fileCommanderView)
        {
            _driveModel = new Model.DriveModel();
            _directoryModel = new DirectoryModel();
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
            this._fileCommanderView.UpdateDrivesCombobox1 += _fileCommanderView_UpdateDrivesForCombobox;
            this._fileCommanderView.UpdateDrivesCombobox2 += _fileCommanderView_UpdateDrivesForCombobox;

        }

        private void _fileCommanderView_UpdateDrivesForCombobox(object sender, EventArgs e)
        {
            ActiveDrivesUpdate();
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
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!_fileCommanderView.IsItemSelectedView1())
            {
                return;
            }

            string srcDir = _currentPath1 + _fileCommanderView.SelectedItemText1();
            string destDir = _currentPath1 + _fileCommanderView.NewDirectoryNameInput;

            _directoryModel.MoveRenameDirectory(srcDir, destDir);


            ListView1Clear();
            PopulateListView1();


        }

        // rename directory or file right
        private void FileCommanderView_listView2_renameDirEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }

            if (!_fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            string srcDir = _currentPath2 + _fileCommanderView.SelectedItemText2();
            string destDir = _currentPath2 + _fileCommanderView.NewDirectoryNameInput;

            _directoryModel.MoveRenameDirectory(srcDir, destDir);


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
            if (!_fileCommanderView.IsListView1Active)
            {
                return;
            }

            if (!_fileCommanderView.IsItemSelectedView1())
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
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!_fileCommanderView.IsItemSelectedView2())
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
                _currentPath1 = PathHistory1.Pop();
                _fileCommanderView.TextBox1 = _currentPath1;


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
                        PathHistory1.Push(_currentPath1);
                        _fileCommanderView.TextBox1 = _currentPath1 + _fileCommanderView.SelectedItemText1() + "\\";
                        _currentPath1 = _fileCommanderView.TextBox1;

                    }

                    ListView1Clear();
                    PopulateListView1();
                }
                else
                {
// if file - run it
                    RunFile1();
                }
            }


        }

        // open folder right
        private void FileCommanderView_listView2_OpenFolder(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (!_fileCommanderView.IsItemSelectedView2())
            {
                return;
            }
            if (_fileCommanderView.SelectedItemText2() == "..")
            {
                ListView2Clear();
                _currentPath2 = PathHistory2.Pop();
                _fileCommanderView.TextBox2 = _currentPath2;


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
                        PathHistory2.Push(_currentPath2);
                        _fileCommanderView.TextBox2 = _currentPath2 + _fileCommanderView.SelectedItemText2() + "\\";
                        _currentPath2 = _fileCommanderView.TextBox2;

                    }

                    ListView2Clear();

                    PopulateListView2();
                }
                else
                {
// if file - run it
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
            if (PathHistory1.Count > 1)
            {
                ListView1Clear();
                _currentPath1 = PathHistory1.Pop();
                _fileCommanderView.TextBox1 = _currentPath1;


                PopulateListView1();
            }

        }

        private void FileCommanderView_listView2_KeyBackSpaceEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsListView2Active)
            {
                return;
            }
            if (PathHistory2.Count > 1)
            {
                ListView2Clear();
                _currentPath2 = PathHistory2.Pop();
                _fileCommanderView.TextBox2 = _currentPath2;


                PopulateListView2();
            }

        }

        private void FileCommanderView_listView1_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsItemSelectedView1())
            {
                return;
            }

            string selectedFolder = _currentPath1 + _fileCommanderView.SelectedItemText1();


            GetFolderSize1(selectedFolder);

        }

        private void FileCommanderView_listView2_KeySpaceEvent(object sender, EventArgs e)
        {
            if (!_fileCommanderView.IsItemSelectedView2())
            {
                return;
            }

            var selectedFolder = _currentPath2 + _fileCommanderView.SelectedItemText2();



            GetFolderSize2(selectedFolder);

        }



        // selected item for list view 1

        private void FileCommanderView_SelectedItemsEvent(object sender, EventArgs e)
        {

        }

        //Right panel
        private void FileCommanderView_listViewEvent2(object sender, EventArgs e)
        {

            _currentPath2 = _fileCommanderView.SelectedDrive2;
            _fileCommanderView.TextBox2 = _currentPath2;
            PathHistory2.Clear();

            ListView2Clear();



            PopulateListView2();

            PathHistory2.Push(_currentPath2);

        }



        private void FileCommanderView_listViewEvent1(object sender, EventArgs e)
        {

            _currentPath1 = _fileCommanderView.SelectedDrive1;
            _fileCommanderView.TextBox1 = _currentPath1;
            PathHistory1.Clear();
            ListView1Clear();
            PopulateListView1();
            PathHistory1.Push(_currentPath1);

        }

        private void PopulateListView1()
        {
            _fileCommanderView.PopulateListView1(_directoryModel.GetDirectoriesInfo(_currentPath1),
                _fileModel.GetFilesInfo(_currentPath1), PathHistory1.Count);
        }


        private void PopulateListView2()
        {
            _fileCommanderView.PopulateListView2(_directoryModel.GetDirectoriesInfo(_currentPath2),
                _fileModel.GetFilesInfo(_currentPath2), PathHistory2.Count);
        }



        public void GetFolderSize1(string currentPath)
        {
            _fileCommanderView.UpdateSelectedItem1Size(_directoryModel.SelectedFolderSize(currentPath).ToString());
        }

        public void GetFolderSize2(string currentPath)
        {
            _fileCommanderView.UpdateSelectedItem2Size(_directoryModel.SelectedFolderSize(currentPath).ToString());
        }

        public void ListView1Clear()
        {
            _fileCommanderView.ListView1Clear();
        }

        public void ListView2Clear()
        {
            _fileCommanderView.ListView2Clear();
        }

        public void CreateNewDirectory1()
        {
            _directoryModel.CreateNewDirectory(_currentPath1, _fileCommanderView.NewDirectoryNameInput);
        }

        public void CreateNewDirectory2()
        {
            _directoryModel.CreateNewDirectory(_currentPath2, _fileCommanderView.NewDirectoryNameInput);
        }

        public void DeleteDirectoyr1()
        {
            _directoryModel.DeleteDirectory(_currentPath1, _fileCommanderView.SelectedItemText1());
        }

        public void DeleteDirectoyr2()
        {
            _directoryModel.DeleteDirectory(_currentPath2, _fileCommanderView.SelectedItemText2());
        }

        public void DeleteFile1()
        {
            _fileModel.DeleteFile(_currentPath1, _fileCommanderView.SelectedItemText1());
        }

        public void DeleteFile2()
        {
            _fileModel.DeleteFile(_currentPath2, _fileCommanderView.SelectedItemText2());
        }

        public bool IsFolder1()
        {
            if (_directoryModel.IsFolder(_currentPath1 + _fileCommanderView.SelectedItemText1()))
                return true;
            else return false;
        }

        public bool IsFolder2()
        {
            if (_directoryModel.IsFolder(_currentPath2 + _fileCommanderView.SelectedItemText2()))
                return true;
            else return false;
        }

        public void RunFile1()
        {
            _fileModel.RunFile(_currentPath1 + _fileCommanderView.SelectedItemText1());
        }

        public void RunFile2()
        {
            _fileModel.RunFile(_currentPath2 + _fileCommanderView.SelectedItemText2());
        }

        public void CopyDirectory1()
        {
            var srcAct = _currentPath1 + _fileCommanderView.SelectedItemText1();
            var destAct = _currentPath2 + _fileCommanderView.SelectedItemText1();

            _directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyDirectory2()
        {
            var srcAct = _currentPath2 + _fileCommanderView.SelectedItemText2();
            var destAct = _currentPath1 + _fileCommanderView.SelectedItemText2();

            _directoryModel.CopyDirectory(srcAct, destAct);
        }

        public void CopyFile1()
        {
            var srcAct = _currentPath1 + _fileCommanderView.SelectedItemText1();
            var destAct = _currentPath2 + _fileCommanderView.SelectedItemText1();
            _fileModel.CopyFile(srcAct, destAct);
        }

        public void CopyFile2()
        {
            var srcAct = _currentPath2 + _fileCommanderView.SelectedItemText2();
            var destAct = _currentPath1 + _fileCommanderView.SelectedItemText2();
            _fileModel.CopyFile(srcAct, destAct);
        }

        public void ActiveDrivesUpdate()
        {
            _fileCommanderView.GetDrives(GetDrives);
        }


    }
}
