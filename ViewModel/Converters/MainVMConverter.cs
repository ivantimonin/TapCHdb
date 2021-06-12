using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAP_DB.ViewModel.Base;

namespace TAP_DB.ViewModel
{
    class MainVMConverter:BaseVM
    {
        /// <summary>
        /// DatagidBase
        /// </summary>       
        private SfDataGrid myDtataGrid;
        public SfDataGrid MyDtataGridBase
        {
            get { return myDtataGrid; }
            set
            {
                myDtataGrid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// DatagidShema
        /// </summary>       
        private SfDataGrid myDtataGridShema;
        public SfDataGrid MyDtataGridShema
        {
            get { return myDtataGridShema; }
            set
            {
                myDtataGridShema = value;
                OnPropertyChanged();
            }
        }
    }
}
