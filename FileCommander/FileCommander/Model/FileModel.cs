using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Model
{
    public class FileModel
    {
        public Dictionary<string, string> DrivesInfo { get; set; }

        public DirectoryInfo DirInfo { get; set; }
        public List<FileInfo> filesList = new  List<FileInfo>();
        
        public List<string> filesNamesArray = new List<string>();

        public string[] GetFilesNames(string selectedDrive)
        {


            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);

            filesNamesArray.Clear();

            foreach (FileInfo fileInfo in directoryinfo.GetFiles())
            {
                filesNamesArray.Add(fileInfo.Name);
            }

            return filesNamesArray.ToArray();


        }

        public List<FileInfo> GetFiles(string selectedDrive)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(selectedDrive);
            filesList.Clear();
            foreach (FileInfo fileInfo in directoryinfo.GetFiles())
            {
                filesList.Add(fileInfo);
            }

            return filesList;
        }
    }
}
