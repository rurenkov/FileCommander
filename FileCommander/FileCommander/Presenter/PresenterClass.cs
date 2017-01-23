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
        }

        public string[] GetFoldersNames(string selectedDrive)
        {
            return directoryModel.GetFoldersNames(selectedDrive);
        }

        public string[] GetFilesNames(string selectedDrive)
        {
            return directoryModel.GetFilesNames(selectedDrive);
        }

    }
}
