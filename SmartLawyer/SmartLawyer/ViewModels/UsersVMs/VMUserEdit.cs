using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SmartLawyer.ViewModels.UsersVMs
{
    public class VMUserEdit
    {
        public static VMUserEdit Create(UsersModel user)
            => ViewModelSource.Create(() => new VMUserEdit(user));

        public VMUserEdit(UsersModel user)
        {
            PersonsModel person = DataAccess.GetPerson(user.UPIdFk).Rows[0].ToPersons();
            PresentUser(user);
            PresentPerson(person);
        }

        private void PresentUser(UsersModel user)
        {
            Username = user.UUserName;
            UserState = user.UIsActive.ToBool();
            ConfPass = user.UPassword;
            Password = user.UPassword;
            EmailAdress = user.UEmail;
        }
        private void PresentPerson(PersonsModel person)
        {
            SelectedUserType = person.PeType;
            FullName = person.PeName;
            PersonalId = person.PeIdentity;
            //Adress here
        }
        #region
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual String ConfPass { get; set; }
        public virtual int SelectedUserType { get; set; }
        public virtual bool UserState { get; set; } = true;
        public virtual String FullName { get; set; }
        public virtual int PersonalId { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public ObservableCollection<int> AddedGroups { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> SuggestedGroups { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<String> UserType { get; set; } = new ObservableCollection<string>();
        public object GroupRols { get; set; }
        #endregion

        public void Done(Window window)
        {
            Person person = new Person()
            {
                FullName = this.FullName,
                DateOfBirth = this.DateOfBirth,
                EmailAdress = this.EmailAdress,
                MobileNo = this.MobileNo,
                PhoneNo = this.PhoneNo
            };
            User user = new User()
            {
                PersonData = person,
                Username = this.Username,
                Password = this.Password,
                UserState = this.UserState,
                UserType = this.SelectedUserType,
                UserGroups = this.AddedGroups.ToList<int>()
            };
            //DataAccess.UpdateUser(user.UserID, user);
            window.Close();
        }

        public void Close(Window window)
        {
            window.Close();
        }
    }
}
