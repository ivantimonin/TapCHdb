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
    /// Логика взаимодействия для Add_Import_Impulse.xaml
    /// </summary>
    public partial class Add_Import_Impulse : Window
    {
        
        public Add_Import_Impulse(MainVM data)
        {           
            this.DataContext = new Add_Import_Impuls_VM(data);
            InitializeComponent();           
            this.ShowDialog();
        }
    }
   

}
