using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Presenter
{
    public class PresenterClass
    {
        private FileCommanderView fileCommanderView;
        public PresenterClass (FileCommanderView fileCommanderView)
        {
            this.fileCommanderView = fileCommanderView;
            fileCommanderView.Presenter = this;     
        }


    }
}
