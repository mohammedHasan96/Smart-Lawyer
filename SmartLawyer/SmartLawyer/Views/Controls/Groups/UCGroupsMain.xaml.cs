using SmartLawyer.ViewModels.GroupsVMs;
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

namespace SmartLawyer.Views.Controls.Groups
{
    /// <summary>
    /// Interaction logic for UCGroupsMain.xaml
    /// </summary>
    public partial class UCGroupsMain : UserControl
    {
        public UCGroupsMain()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((VMGroups)DataContext).CheckAll();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((VMGroups)DataContext).UncheckAll();
        }
    }
}
