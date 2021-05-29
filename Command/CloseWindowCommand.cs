using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TAP_DB.Command
{
    public class CloseWindowCommand:Command
    {
        public override bool CanExecute(object parametr) => parametr is Window;
             
        public override void Execute(object parametr)
        {            
            if (!CanExecute(parametr)) return;
            var Window = (Window)parametr;
            Window.Close();
        }
    }
}
