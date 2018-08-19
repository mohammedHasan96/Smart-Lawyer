using SmartLawyer.Models.Classes;
using SmartLawyer.ViewModels.UsersVMs;
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

namespace SmartLawyer.Views
{
    /// <summary>
    /// Interaction logic for VUserAdd.xaml
    /// </summary>
    public partial class VUserAdd : Window
    {
        public VUserAdd(List<RolesModel> Roles, List<GroupRolesModel> GroupRoles, List<CodesModel> SystemConstants)
        {
            InitializeComponent();
        }
        public VUserAdd(List<CodesModel> PersonTypes)
        {
            DataContext = VMUserAdd.Create();
            InitializeComponent();
        }
    }
}
