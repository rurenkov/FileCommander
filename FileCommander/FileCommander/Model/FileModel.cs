using System.Collections.Generic;
using System.IO;

namespace FileCommander.Model
{
    public class FileModel : IFileModel
    {
        public Dictionary<string, string> DrivesInfo { get; set; }

        public DirectoryInfo DirInfo { get; set; }
        public List<FileInfo> FilesList = new  List<FileInfo>();
        
        public List<string> FilesNamesArray = new List<string>();

        public string[] GetFilesNames(string selectedDrive)
        {


            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);

            FilesNamesArray.Clear();

            foreach (FileInfo fileInfo in directoryinfo.GetFiles())
            {
                FilesNamesArray.Add(fileInfo.Name);
            }

            return FilesNamesArray.ToArray();


        }

        public List<FileInfo> GetFiles(string selectedDrive)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);
            FilesList.Clear();
            foreach (FileInfo fileInfo in directoryinfo.GetFiles())
            {
                FilesList.Add(fileInfo);
            }

            return FilesList;
        }

        public Dictionary<string, string[]> GetFilesInfo(string currentPath)
        {
            Dictionary<string, string[]> filesInfo = new Dictionary<string, string[]>();
            List<FileInfo> files = GetFiles(currentPath);
            foreach (FileInfo fileInfo in files)
            {
                string[] row1 = { "FILE", (((fileInfo.Length / 1024)).ToString("0.00")), fileInfo.LastWriteTime.ToShortDateString() };
                filesInfo.Add(fileInfo.Name, row1);
            }

            return filesInfo;
        }

        public void DeleteFile(string currentPath, string listViewSelectedItem)
        {
            File.Delete(currentPath + listViewSelectedItem);
        }

        public void CopyFile(string src, string dest)
        {

            File.Copy(src, dest, true);

        }

        public void RunFile(string path)
        {
            System.Diagnostics.Process.Start(path);
        }

    }
}
