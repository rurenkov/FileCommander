using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCommander.Model
{
    public class DirectoryModel
    {
        public Dictionary<string, string> DrivesInfo { get; set; }

        public DirectoryInfo DirInfo { get; set; }
         
        
        public DirectoryModel()
        {
            DrivesInfo = new Dictionary<string, string>();
            DirInfo = new DirectoryInfo(@".");
        }
    }
}
