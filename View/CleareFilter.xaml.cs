using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TAP_DB.ViewModel;

namespace TAP_DB.View
{
    /// <summary>
    /// Логика взаимодействия для CleareFilter.xaml
    /// </summary>
    public partial class CleareFilter : Window
    {
        public CleareFilter(MainVM ParentVM)
        {
            this.DataContext = ParentVM;
            InitializeComponent();
        }
    }
}
