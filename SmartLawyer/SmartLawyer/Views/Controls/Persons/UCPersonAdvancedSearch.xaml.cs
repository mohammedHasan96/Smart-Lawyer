using SmartLawyer.ViewModels.PersonVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartLawyer.Views.Controls.Persons
{
    /// <summary>
    /// Interaction logic for UCPersonAdvancedSearch.xaml
    /// </summary>
    public partial class UCPersonAdvancedSearch : UserControl
    {
        public UCPersonAdvancedSearch()
        {
            InitializeComponent();
            new Thread(() =>
            {
                while (Parent == null)
                {
                    Thread.Sleep(100);
                }
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    DataContext = (Parent as ContentControl).DataContext;
                });
            })
            { IsBackground = true }.Start();

        }
        //public UCPersonAdvancedSearch(object dataContext)
        //{
        //    DataContext = dataContext;
        //    InitializeComponent();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (DataContext == null)
        }
    }
}
