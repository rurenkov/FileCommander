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
                foldersList.Add(dirInfo);
            }

            return foldersList;
        }
        object obj = new object();
        public long GetFolderSize( string path)
        {
            
            
                long b = 0;
                // 1.
                // Get array of all file names.
                string[] a = Directory.GetFiles(path, "*.*");

                // 2.
                // Calculate total bytes of all files in a loop.
                
                foreach (string name in a)
                {
                    // 3.
                    // Use FileInfo to get length of each file.
                    FileInfo info = new FileInfo(name);
                    b += info.Length;
                }
                return b;
            
                // 4.
                // Return total size
               
            
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
