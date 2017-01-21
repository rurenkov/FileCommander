using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCommander.Model
{
    public class FileExplorerWindowModel
    {
        public FileExplorerWindowModel()
        {

        }

        private void LoadContent()
        {
            treeView1.Nodes.Clear();

            DirectoryInfo directoryinfo = new DirectoryInfo(comboBox1.Text);
            if (directoryinfo != null)

            {


                try
                {
                    foreach (DirectoryInfo dirInfo in directoryinfo.GetDirectories())
                    {
                        TreeNode node = new TreeNode();
                        node.Text = dirInfo.FullName;
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        treeView1.Nodes.Add(node);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        DriveInfo driveInfo = new DriveInfo();
    }
}
