using DevExpress.Mvvm.POCO;
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
        public static VMPersonEdit Create()
            => ViewModelSource.Create(() => new VMPersonEdit());
        public virtual String FullName { get; set; }
        public virtual String PersonalId { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual object SelectedPersonType { get; set; }
        public ObservableCollection<int> PersonTypeSource { get; set; }

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
