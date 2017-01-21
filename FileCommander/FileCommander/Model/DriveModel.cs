using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCommander.Model
{
   public class DriveModel
    {
        public DriveInfo[] AllDrives = DriveInfo.GetDrives();
        public List<string> DrivesName { get; set; }
        public DriveModel()
        {
            DrivesName = new List<string>();

        }
    }
}
