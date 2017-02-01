using System;
using System.Collections.Generic;

namespace FileCommander
{
    public interface IFileCommanderView
    {
        event EventHandler RenameDirEvent;
        event EventHandler CopyDirEvent;
        event EventHandler ListViewEvent;
        event EventHandler ListViewEventRight;
        event EventHandler SelectedItemsEvent;
        event EventHandler ListViewKeySpaceEvent;
        event EventHandler ListViewKeyBackSpaceEvent;
        event EventHandler ListViewKeyEnterEvent;
        event EventHandler ListViewKeyDeleteEvent;
        event EventHandler ListViewCreateNewFolderEvent;
        event EventHandler ListViewMouseDoubleClickEvent;
        event EventHandler UpdateDrivesCombobox1;
        event EventHandler UpdateDrivesCombobox2;

        bool IsListView1Active { get; }
         bool IsListView2Active { get; }

        bool IsItemSelectedView1();
        bool IsItemSelectedView2();

        string SelectedItemText1();
        string SelectedItemText2();

        string NewDirectoryNameInput { get; }

        string SelectedItem1Type();
        string SelectedItem2Type();

        string TextBox1 { get; set; }
        string TextBox2 { get; set; }

        string SelectedDrive1 { get; }
        string SelectedDrive2 { get; }

        void PopulateListView1(Dictionary<string, string[]> foldersDic, Dictionary<string, string[]> filesDic,
            int pathHistory1Count);
        void PopulateListView2(Dictionary<string, string[]> foldersDic, Dictionary<string, string[]> filesDic,
            int pathHistory2Count);

        void UpdateSelectedItem1Size(string size);
        void UpdateSelectedItem2Size(string size);

        void ListView1Clear();
        void ListView2Clear();

        void GetDrives(List<string> drivesList);

    }
}