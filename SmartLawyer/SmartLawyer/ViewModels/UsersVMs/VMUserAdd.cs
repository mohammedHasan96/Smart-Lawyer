using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Classes = SmartLawyer.Models.Classes;
using Values = SmartLawyer.Models.Values;

namespace SmartLawyer.ViewModels.UsersVMs
{
    public class VMUserAdd
    {
        public static VMUserAdd Create()
            => ViewModelSource.Create(() => new VMUserAdd());
        #region Properties
        public virtual String Username { get; set; } = "MohammedAhmed";
        public virtual String Password { get; set; } = "Password";
        public virtual String ConfPass { get; set; } = "Password";
        public virtual int SelectedUserType { get; set; } = 0;
        public virtual bool UserState { get; set; } = true;
        public virtual String FullName { get; set; } = "Mohammed Ahmed";
        public virtual int PersonalId { get; set; } = 12654654;
        public virtual String EmailAdress { get; set; } = "Emial@example.com";
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public ObservableCollection<int> AddedGroups { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> SuggestedGroups { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<object> UserTypeCombo { get; set; } = new ObservableCollection<object>();
        public object GroupRols { get; set; }
        #endregion


        public void Add(Window window)
        {
            PersonsModel person = new PersonsModel()
            {
                PeIdentity = PersonalId,
                PeName = FullName,
                PeType = SelectedUserType,
                PeAddress = 0 // Adress Needed
            };
            var personChangeValue = DataAccess.InsertPerson(out var personInsertId, person);
            UsersModel user = new UsersModel()
            {
                CreatedBy = Values.SystemValues.LoginUser,
                UPIdFk = personInsertId,
                UEmail = EmailAdress,
                UUserName = Username,
                UPassword = Password.GetPasswordHashSHA256(),
                UIsActive = UserState.ToIntState(),
                UpdatedBy = Values.SystemValues.LoginUser
            };
            var userChangeValue = DataAccess.InsertUser(out var userInsertId, user);
            if (userChangeValue == 1)
            {
                window.DialogResult = true;
                window.Close();
            }
            else
                MessageBox.Show("Field to add user !!");
        }

        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }
    }
}
