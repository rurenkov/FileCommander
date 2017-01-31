using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileCommander.Presenter;


namespace FileCommander.Model
{
    public class DirectoryModel
    {
        public Dictionary<string, string> DrivesInfo { get; set; }
        
        public DirectoryInfo DirInfo { get; set; }
        public List<string> dirrectoriesNamesArray = new List<string>();
        //public List<string> filesNamesArray = new List<string>();
        public List<DirectoryInfo> foldersList = new List<DirectoryInfo>();



        //copy file method.
        public void CopyFile(string src, string dest)
        {
            
                File.Copy(src, dest, true);
                   
        }

        //copy directory method.
        public  void CopyDirectory(String src, String dest)
        {
           
                //Create Directories
                String[] dirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories);
            foreach (String difVolume in dirs)
            {
              
                    string path1 = difVolume.Replace(src, dest);  //replace path, path = dest
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                else
                {
                    
                    // what to do if directoryexists??????
                    //*****************
                    //***************
                    //***************

                }
             }
            // copy files inside
            String[] szFiles = Directory.GetFiles(src, "*", SearchOption.AllDirectories);
            foreach (String srcFile in szFiles)
            {
                String destFile = srcFile.Replace(src, dest);
                File.Copy(srcFile, destFile, true);
            }
        }

    
        public void Move_Rename_Directory(String srcDir, String destDir)
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

                //this.fileCommanderView.listView1.Items.Add(dirInfo.Name, 1).SubItems.AddRange(row1);
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

        //public string[] GetFilesNames(string selectedDrive)
        //{


        //    DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);

        //    filesNamesArray.Clear();

        //    foreach (FileInfo fileInfo in directoryinfo.GetFiles())
        //    {
        //        filesNamesArray.Add(fileInfo.Name);
        //    }

        //    return filesNamesArray.ToArray();


        //}



    }
}
