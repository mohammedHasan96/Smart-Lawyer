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
    /// Interaction logic for VPersonEdit.xaml
    /// </summary>
    public partial class VPersonEdit : Window
    {
        private VPersonEdit()
        {
            InitializeComponent();
        }
        public VPersonEdit(PersonsModel person, List<CodesModel> PersonTypes)
        {
            DataContext = VMPersonEdit.Create(person,PersonTypes);
            InitializeComponent();
        }
    }
}
