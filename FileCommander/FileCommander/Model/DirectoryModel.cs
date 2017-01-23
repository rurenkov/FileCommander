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
        public List<string> filesNamesArray = new List<string>();





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



    }
}
