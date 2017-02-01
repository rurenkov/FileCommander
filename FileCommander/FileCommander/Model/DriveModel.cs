using System.Collections.Generic;
using System.IO;

namespace FileCommander.Model
{
    public class DriveModel
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
