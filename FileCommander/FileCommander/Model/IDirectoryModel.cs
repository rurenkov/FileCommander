using System;
using System.Collections.Generic;

namespace FileCommander.Model
{
    public interface IDirectoryModel
    {
         void CopyDirectory(string SourcePath, string DestinationPath);
         void MoveRenameDirectory(string srcDir, string destDir);
         long SelectedFolderSize(string selectedFolder);
         Dictionary<string, string[]> GetDirectoriesInfo(string currentPath);

         void CreateNewDirectory(string currentPath, string newDirectoryNameInput);

        void DeleteDirectory(string currentPath, string listViewSelectedItem);

        bool IsFolder(string path);

    }
}