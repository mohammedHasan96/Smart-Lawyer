using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using values = SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using SmartLawyer.ViewModels;
using SmartLawyer.Views;
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

namespace SmartLawyer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Random random = new Random();
            //for (int i = 0; i < 7; i++)
            //{
            //    var groupChangeValue = DataAccess.InsertGroup(out var groupInsertId, new GroupsModel()
            //    {
            //        GName = $"Group {random.Next(20, 100)}",
            //        GDescription = $"Group Description {random.Next(100000, 900000)}{random.Next(100000, 900000)}{random.Next(100000, 900000)}"
            //    });
            //    var r = random.Next(0, 12);
            //    for (int iw = 0; iw < r; iw++)
            //    {
            //        var roleChangeValue = DataAccess.InsertGroupeRole(out var w, new GroupRolesModel()
            //        {
            //            GroupId = (int)groupInsertId,
            //            RoleId = random.Next(1, 19)
            //        });
            //    }
            //}
            //DataAccess.DeleteGroupRoles(11);
            DataContext = VMMainWindow.Create();
            InitializeComponent();
            //var users = DataAccess.SQLSelectAs<UsersModel>(
            //    $"select * from {UsersTable.TableName}",
            //    null,
            //    typeof(UsersTable));
            //foreach (var user in users)
            //{
            //    break;
            //}
        }

    }
}
