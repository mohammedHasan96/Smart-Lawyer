using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
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

namespace SmartLawyer.Views.Users
{
    /// <summary>
    /// Interaction logic for VUserEdit.xaml
    /// </summary>
    public partial class VUserEdit : Window
    {
        private VUserEdit()
        {
            InitializeComponent();
        }
        public VUserEdit(UsersModel user)
        {
            DataContext = VMUserEdit.Create(user);
            InitializeComponent();
        }
    }
}
