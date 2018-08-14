using SmartLawyer.ViewModels.PersonVMs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartLawyer.Views.Controls.Persons
{
    /// <summary>
    /// Interaction logic for UCPersonsMain.xaml
    /// </summary>
    public partial class UCPersonsMain : UserControl
    {
        public UCPersonsMain()
        {
            InitializeComponent();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            (DataContext as VMPersons).UncheckAll();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            (DataContext as VMPersons).CheckAll();
        }
    }
}
