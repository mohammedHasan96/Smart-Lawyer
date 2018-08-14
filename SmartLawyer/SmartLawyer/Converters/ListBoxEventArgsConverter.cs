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
    public class ListBoxEventArgsConverter : EventArgsConverterBase<MouseEventArgs>
    {
        protected override object Convert(object sender, MouseEventArgs args)
        {
            DataGrid parentElement = (DataGrid)sender;
            DependencyObject clickedElement = (DependencyObject)args.OriginalSource;
            DataGridRow clickedDataGridItem =
                LayoutTreeHelper.GetVisualParents(child: clickedElement, stopNode: parentElement)
                .OfType<DataGridRow>()
                .FirstOrDefault();
            return clickedDataGridItem != null ? clickedDataGridItem.DataContext : null;
        }
    }
}
