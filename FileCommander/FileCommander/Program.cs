using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileCommander.Model;
using FileCommander.Presenter;
using FileCommander;

namespace FileCommander
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FileCommanderView fileCommander = new FileCommanderView();
            PresenterClass presenter = new PresenterClass(fileCommander);



            Application.Run(fileCommander);

           
            
        }
    }
}
