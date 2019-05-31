using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SmartLawyer.ViewModels.UsersVMs
{
    public class VMUserEdit
    {
        public static VMUserEdit Create(UsersModel user, PersonsModel person, List<PersonsCommunicationModel> PersonCommunications, List<GroupsModel> Groups, List<RolesModel> Roles, List<GroupRolesModel> GroupRoles, List<UserGroupModel> UserGroups, List<CodesModel> SystemConstants)
            => ViewModelSource.Create(() => new VMUserEdit(user, person, PersonCommunications, Groups, Roles, GroupRoles, UserGroups, SystemConstants));

        public VMUserEdit(UsersModel user, PersonsModel person, List<PersonsCommunicationModel> PersonCommunications, List<GroupsModel> Groups, List<RolesModel> Roles, List<GroupRolesModel> GroupRoles, List<UserGroupModel> UserGroups, List<CodesModel> SystemConstants)
        {
            Person = person;
            SelectedUserType = SystemConstants.Where(x => x.CId == person.PeType && x.CId == SystemValues.MasterSystemConstants.UserType).FirstOrDefault();
            UserState = user.UIsActive.ToBool();
            UserTypeSource.ReFill(SystemConstants.Where(x => x.CMasterId == SystemValues.MasterSystemConstants.UserType));
            CommunicationCodeSource.ReFill(SystemConstants.Where(x => x.CMasterId == SystemValues.MasterSystemConstants.CommunicationType));
            this.GroupRoles = GroupRoles;
            this.Roles = Roles;

            AddedGroupsSource.ReFill(Groups.Where(x => UserGroups.Where(y => y.GroupId == x.GId && y.UserId == person.PeId).Count() > 0));
            SuggestedGroupsSource.ReFill(Groups.Where(x => !AddedGroupsSource.Contains(x)));
            foreach (var item in PersonCommunications.Where(x => x.CoPeIdFk == person.PeId))
            {
                CommunicationSource.Add((item, SystemConstants));
            }

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
            var adress = person.PeAddress.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            FullName = person.PeName;
            PersonalId = person.PeIdentity;
            if (adress != null && adress.Length == 2)
            {
                City = adress[0];
                Adress = adress[1];
            }
        }
        #region
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual String ConfPass { get; set; }
        public virtual bool UserState { get; set; }
        public virtual String FullName { get; set; }
        public virtual int PersonalId { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String City { get; set; }
        public virtual String Adress { get; set; }
        public virtual bool IsInProgress { get; set; } = false;
        PersonsModel Person = new PersonsModel();


        public ObservableCollection<GroupsModel> AddedGroupsSource { get; } = new ObservableCollection<GroupsModel>();
        public ObservableCollection<GroupsModel> SuggestedGroupsSource { get; } = new ObservableCollection<GroupsModel>();
        public ObservableCollection<RolesModel> GroupRolesSource { get; } = new ObservableCollection<RolesModel>();
        public ObservableCollection<CodesModel> UserTypeSource { get; } = new ObservableCollection<CodesModel>();
        public ObservableCollection<CommModel> CommunicationSource { get; } = new ObservableCollection<CommModel>(); public ObservableCollection<CodesModel> CommunicationCodeSource { get; } = new ObservableCollection<CodesModel>();


        public List<GroupRolesModel> GroupRoles { get; private set; } = new List<GroupRolesModel>();
        public List<RolesModel> Roles { get; private set; } = new List<RolesModel>();
        public List<PersonsCommunicationModel> AddedCommunication { get; set; } = new List<PersonsCommunicationModel>();
        public List<UserGroupModel> UserGroups { get; set; } = new List<UserGroupModel>();
        public List<PersonsAddressModel> AddedAddress { get; set; } = new List<PersonsAddressModel>();

        public virtual CodesModel SelectedUserType { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = nameof(GroupItemChanged), OnPropertyChangingMethodName = nameof(GroupItemChanging))]
        public virtual GroupsModel SelectedSuggestedItem { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = nameof(GroupItemChanged), OnPropertyChangingMethodName = nameof(GroupItemChanging))]
        public virtual GroupsModel SelectedAddedItem { get; set; }
        public virtual PersonsCommunicationModel SelectedCommItem { get; set; }
        #endregion


        protected void GroupItemChanged(GroupsModel oldValue)
        {

        }
        protected void GroupItemChanging(GroupsModel newValue)
        {
            IsInProgress = true;
            new Thread(() => 
            {

            }) { IsBackground = true }.Start();
            if (newValue != null)
            {
                GroupRolesSource.Clear();
                var roles = GroupRoles.Where(x => x.GrolrGIdFk == newValue.GId);
                foreach (var item in roles)
                {
                    var role = Roles.Where(x => x.RoleId == item.GrolrRoleIdFk).FirstOrDefault();
                    if (role != null)
                        GroupRolesSource.Add(role.FillRoles(item));
                }
            }
        }
        public void Done(object valuse)
        {
            var objs = valuse as object[];
            Password = (objs[0] as PasswordBox).Password;
            ConfPass = (objs[1] as PasswordBox).Password;
            var window = objs[2] as Window;
            if (Password.Equals(ConfPass))
            {
                IsInProgress = true;
                new Thread(() =>
                {
                    PersonsModel person = new PersonsModel()
                    {
                        PeId = Person.PeId,
                        PeIdentity = PersonalId,
                        PeName = FullName,
                        PeType = (int)SelectedUserType.CId,
                        PeAddress = ""
                    };
                    var personChangeValue = 0;
                    long personInsertId = 0;
                    try { personChangeValue = DataAccess.UpdatePerson(Person.PeId, person); }
                    catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
                    person.PeId = personInsertId;
                    if (personChangeValue == 1)
                    {
                        UsersModel user = new UsersModel()
                        {
                            CreatedBy = SystemValues.LoginUser,
                            UPIdFk = personInsertId,
                            UEmail = EmailAdress,
                            UUserName = Username,
                            UPassword = Password.GetPasswordHashSHA256(),
                            UIsActive = UserState.ToIntState(),
                            UpdatedBy = SystemValues.LoginUser
                        };
                        long userChangeValue = 0;
                        try { userChangeValue = DataAccess.UpdateUser((int)person.PeId, user); }
                        catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                        if (userChangeValue == 1)
                        {
                            try { DataAccess.DeletePersonCommunication(person.PeId); }
                            catch { MessageBox.Show("Filed to Edit user Communication, Address and Groups info"); return; }
                            foreach (var item in CommunicationSource)
                            {
                                item.CoPeIdFk = person.PeId;
                                try { var commValueChange = DataAccess.InsertPersonCommunication(out var id, item); AddedCommunication.Add(item); }
                                catch { MessageBox.Show($"Could not Add {item.CoNameCfk} to this user", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }

                            }
                            var address = new PersonsAddressModel()
                            {
                                PeAdCity = City,
                                PeAdStreetName = Adress,
                                PeAdPerIdFk = person.PeId
                            };
                            try { DataAccess.DeletePersonAddress(person.PeId); }
                            catch { MessageBox.Show("Filed to Edit user Address and Groups info"); return; }
                            try { DataAccess.InsertPersonAddress(out var adressId, address); AddedAddress.Add(address); }
                            catch { MessageBox.Show($"Could not Add Addess to this user", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                            try { DataAccess.DeleteUserGroups((int)person.PeId); }
                            catch { MessageBox.Show("Filed to Edit user Groups info"); return; }
                            foreach (var item in AddedGroupsSource)
                            {
                                var userGroup = new UserGroupModel()
                                {
                                    GroupId = item.GId,
                                    UserId = (int)person.PeId
                                };
                                try { DataAccess.InsertUserGroups(out var n, userGroup); UserGroups.Add(userGroup); }
                                catch { MessageBox.Show($"Could not Add {item.GName} to this user", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                            }
                            IsInProgress = false;
                            App.Current.Dispatcher.Invoke((Action)delegate
                            {
                                window.DialogResult = true;
                                window.Close();
                            });
                        }
                        else
                            MessageBox.Show("Field to add user !!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                        MessageBox.Show("Field to add person !!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                })
                { IsBackground = true }.Start();
            }
            else { MessageBox.Show("Password did not Match!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        public void Close(Window window)
        {
            window.Close();
        }
    }
}
