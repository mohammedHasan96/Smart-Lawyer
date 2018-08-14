using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartLawyer.ViewModels.UsersVMs
{
    class VMUersView
    {
        public virtual String FullName { get; set; }
        public virtual String PersonalID { get; set; }
        public virtual String Username { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int CasesNo { get; set; }
        public virtual int ContractsNo { get; set; }
        public virtual int DeptsNo { get; set; }
        public virtual int NotificationsNo { get; set; }

        public virtual object CasesData { get; set; }
        public virtual object ContractsData { get; set; }
        public virtual object DeptsData { get; set; }
        public virtual object NotificationsData { get; set; }

        public void Close(Window window)
        {
            window.Close();
        }
    }
}
