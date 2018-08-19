using SmartLawyer.Models.Classes;
using SmartLawyer.ViewModels.PersonsVMs;
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

namespace SmartLawyer.Views.Person
{
    /// <summary>
    /// Interaction logic for VPerson.xaml
    /// </summary>
    public partial class VPersonAdd : Window
    {
        private VPersonAdd()
        { 
            InitializeComponent();
        }
        public VPersonAdd(List<CodesModel> PersonTypes)
        {
            DataContext = VMPersonAdd.Create(PersonTypes);
            InitializeComponent();
        }
    }
}
