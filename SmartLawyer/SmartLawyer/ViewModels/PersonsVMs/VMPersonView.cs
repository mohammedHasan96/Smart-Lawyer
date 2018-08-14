using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartLawyer.ViewModels.PersonsVMs
{
    public class VMPersonView
    {
        public static VMPersonView Create()
            => ViewModelSource.Create(() => new VMPersonView());
        #region
        public virtual String FullName { get; set; }
        public virtual String PersonalId { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual object SelectedPersonType { get; set; }

        #endregion

        public void Close(Window window)
        {
            window.Close();
        }
    }
}
