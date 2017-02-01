using System;
using System.Windows.Forms;
using FileCommander.Presenter;

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
