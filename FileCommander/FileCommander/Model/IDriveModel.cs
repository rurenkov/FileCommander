using System.Collections.Generic;

namespace FileCommander.Model
{
    public interface IDriveModel
    {
        List<string> DrivesName { get; set; }
    }
}