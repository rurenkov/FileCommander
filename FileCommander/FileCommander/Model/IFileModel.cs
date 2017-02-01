using System.Collections.Generic;

namespace FileCommander.Model
{
    public interface IFileModel
    {
        Dictionary<string, string[]> GetFilesInfo(string currentPath);
        void DeleteFile(string currentPath, string listViewSelectedItem);
        void RunFile(string path);
        void CopyFile(string src, string dest);
    }
}