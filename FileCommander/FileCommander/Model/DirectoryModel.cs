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


/*

    public  void CopyDirectory(String src, String dest)
        {
            try
            {

          //      String srcpathroot = Path.GetPathRoot(src);
        //       String destpathroot = Path.GetPathRoot(dest);

                //Create Directories
                String[] dirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories);
                foreach (String difVolume in dirs)
                {

                    String path = difVolume.Replace(src, dest);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
               
                String[] szFiles = Directory.GetFiles(src, "*", SearchOption.AllDirectories);
                foreach (String srcFile in szFiles)
                {
                    String destFile = srcFile.Replace(src, dest);
                    File.Copy(srcFile, destFile, true);
                }


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

    */


        public void Move_Rename_Directory(String srcDir, String destDir)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(srcDir);
                dInfo.MoveTo(destDir);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
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
    
        public long GetFolderSize(DirectoryInfo d)
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
                    size += GetFolderSize(di);
            }
            return size;


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
