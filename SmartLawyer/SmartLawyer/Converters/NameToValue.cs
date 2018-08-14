using SmartLawyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartLawyer.Converters
{
    class NameToValue : MarkupExtension, IValueConverter
    {
        public object Name { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value != "")
                return VMMainWindow.rm.GetString((String)value);
            return "";
        }
            
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Name != null && Name != "")
                return VMMainWindow.rm.GetString((String)Name);
            return "";
        }
    }
}
