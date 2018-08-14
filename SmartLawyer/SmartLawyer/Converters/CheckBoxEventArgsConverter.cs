using DevExpress.Mvvm.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartLawyer.Converters
{
    class CheckBoxEventArgsConverter : EventArgsConverterBase<RoutedEventArgs>
    {
        protected override object Convert(object sender, RoutedEventArgs args)
        {
            return ((CheckBox)sender).DataContext;
        }
    }
}
