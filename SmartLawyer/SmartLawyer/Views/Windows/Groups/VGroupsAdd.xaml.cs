using SmartLawyer.Models.Classes;
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
using System.Windows.Shapes;

namespace SmartLawyer.Views.Groups
{
    /// <summary>
    /// Interaction logic for VGroupsAdd.xaml
    /// </summary>
    public partial class VGroupsAdd : Window
    {
        private VGroupsAdd()
        {
            InitializeComponent();
        }
        public VGroupsAdd(List<RolesModel> roles)
        {
            DataContext = VMGroupsAdd.Create(roles);
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((VMGroupsAdd)DataContext).CheckAll();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((VMGroupsAdd)DataContext).UncheckAll();

        }
    }
}
