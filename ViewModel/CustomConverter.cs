using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TAP_DB.ViewModel
{
    class CustomConverter : IMultiValueConverter
    {
        public object Convert(object[] Values, Type Target_Type, object Parameter, CultureInfo culture)
        {
            var findCommandParameters = new MainVM();
            findCommandParameters.MyDtataGridBase = (SfDataGrid)Values[0];
            findCommandParameters.MyDtataGridShema = (SfDataGrid)Values[1];
            return findCommandParameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
