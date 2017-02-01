using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCommander.Model
{
   public class DriveModel : IDriveModel
    {
        public DriveInfo[] AllDrives = DriveInfo.GetDrives();
        private List<string> drivesName = new List<string>();
        public List<string> DrivesName
        {
            get
            {               

                return drivesName;
            }
            set
            {
                drivesName = value;
            }
        }
        public DriveModel()
        {
            foreach (DriveInfo drive in AllDrives)
            {
                drivesName.Add(drive.Name);
            }

        }

    }
}
