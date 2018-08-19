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
    /// Interaction logic for VGroupsEdit.xaml
    /// </summary>
    public partial class VGroupsEdit : Window
    {
        private VGroupsEdit()
        {
            InitializeComponent();
        }

        public VGroupsEdit(List<RolesModel> roles, GroupsModel group)
        {
            DataContext = VMGroupsEdit.Create(roles, group);
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((VMGroupsEdit)DataContext).CheckAll();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((VMGroupsEdit)DataContext).UncheckAll();

        }
    }
}
