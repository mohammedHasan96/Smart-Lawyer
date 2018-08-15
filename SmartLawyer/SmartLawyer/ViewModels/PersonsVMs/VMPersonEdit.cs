using DevExpress.Mvvm.POCO;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartLawyer.ViewModels.PersonsVMs
{
    public class VMPersonEdit
    {
        public static VMPersonEdit Create(List<CodesModel> PersonTypes)
            => ViewModelSource.Create(() => new VMPersonEdit(PersonTypes));
        public virtual String FullName { get; set; }
        public virtual String PersonalId { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual object SelectedPersonType { get; set; }
        public ObservableCollection<CodesModel> PersonTypeSource { get; set; }

        public VMPersonEdit(List<CodesModel> PersonTypes)
        {
            PersonTypeSource.ReFill(PersonTypes);
        }
        public void Edit(Window window)
        {
            window.DialogResult = true;
            window.Close();
        }
        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }
    }
}
