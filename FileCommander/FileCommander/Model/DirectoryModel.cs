using System;
using System.Collections.Generic;
using System.IO;


namespace FileCommander.Model
{
    public class DirectoryModel : IDirectoryModel
    {
        public Dictionary<string, string> DrivesInfo { get; set; }
        
        public DirectoryInfo DirInfo { get; set; }
        public List<string> dirrectoriesNamesArray = new List<string>();
         public List<DirectoryInfo> foldersList = new List<DirectoryInfo>();

        

        //copy directory method.
        public void CopyDirectory(String SourcePath, String DestinationPath)
        {
            //Create  directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy files + Replace
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
      
        }


        public void MoveRenameDirectory(String srcDir, String destDir)
        {
            
                DirectoryInfo dInfo = new DirectoryInfo(srcDir);
                dInfo.MoveTo(destDir);
        }



        public string[] GetFoldersNames(string selectedDrive)
        {


            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);

            dirrectoriesNamesArray.Clear();

            foreach (DirectoryInfo dirInfo in directoryinfo.GetDirectories())
            {
                dirrectoriesNamesArray.Add(dirInfo.Name);
            }

            return dirrectoriesNamesArray.ToArray();

            
        }

        public List<DirectoryInfo> GetFolders(string selectedDrive)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);
            foldersList.Clear();
            foreach (DirectoryInfo dirInfo in directoryinfo.GetDirectories())

            {
                if ((dirInfo.Attributes & FileAttributes.Hidden) == 0)
                    foldersList.Add(dirInfo);
            }

            return foldersList;
        }
    
        private long CalculateFolderSize(DirectoryInfo d)
        {


            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
               
                    size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if ((d.Attributes & FileAttributes.Hidden) == 0)
                    size += CalculateFolderSize(di);
            }
            return size;


        }

        public long SelectedFolderSize(string selectedFolder)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);
            return CalculateFolderSize(dirInfo);
        }

        public Dictionary<string, string[]> GetDirectoriesInfo(string currentPath)
        {
            Dictionary<string, string[]> foldersInfo = new Dictionary<string, string[]>();
            
            foreach (DirectoryInfo dirInfo in GetFolders(currentPath))
           {

                string[] row1 = { "FOLDER", "<DIR>", dirInfo.LastWriteTime.ToShortDateString() };
                foldersInfo.Add(dirInfo.Name, row1);

                 }

            return foldersInfo;
        }

        public void CreateNewDirectory(string currentPath, string newDirectoryNameInput)
        {
            FolderNameDialogForm folderNameDialog = new FolderNameDialogForm();
            DirectoryInfo dirInfo = Directory.CreateDirectory(currentPath + "\\" + newDirectoryNameInput);
        }

        public void DeleteDirectory(string currentPath, string listViewSelectedItem)
        {          
                Directory.Delete(currentPath + listViewSelectedItem, true);
        }

        public bool IsFolder(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            // CHECK IF FOLDER Or fILE.
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;

            }
            else return false;
        }

   
    }
}
