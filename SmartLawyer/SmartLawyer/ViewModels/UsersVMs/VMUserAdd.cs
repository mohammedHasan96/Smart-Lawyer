using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Classes = SmartLawyer.Models.Classes;
using Values = SmartLawyer.Models.Values;

namespace SmartLawyer.ViewModels.UsersVMs
{
    public class VMUserAdd
    {
        public static VMUserAdd Create(List<GroupsModel> Groups, List<RolesModel> Roles, List<GroupRolesModel> GroupRoles, List<CodesModel> SystemConstants)
            => ViewModelSource.Create(() => new VMUserAdd(Groups, Roles, GroupRoles, SystemConstants));


        #region Properties
        public virtual String Username { get; set; } = "MohammedAhmed";
        public virtual String Password { get; set; } = "Password";
        public virtual String ConfPass { get; set; } = "Password";
        public virtual bool UserState { get; set; } = true;
        public virtual String FullName { get; set; } = "Mohammed Ahmed";
        public virtual int PersonalId { get; set; } = 12654654;
        public virtual String EmailAdress { get; set; } = "Emial@example.com";
        public virtual String City { get; set; }
        public virtual String Adress { get; set; }
        public virtual bool IsInProgress { get; set; } = false;


        public ObservableCollection<GroupsModel> AddedGroupsSource { get; } = new ObservableCollection<GroupsModel>();
        public ObservableCollection<GroupsModel> SuggestedGroupsSource { get; } = new ObservableCollection<GroupsModel>();
        public ObservableCollection<RolesModel> GroupRolesSource { get; } = new ObservableCollection<RolesModel>();
        public ObservableCollection<CodesModel> UserTypeSource { get; } = new ObservableCollection<CodesModel>();
        public ObservableCollection<PersonsCommunicationModel> CommunicationSource { get; } = new ObservableCollection<PersonsCommunicationModel>();
        public ObservableCollection<CodesModel> CommunicationCodeSource { get; } = new ObservableCollection<CodesModel>();


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

        public VMUserAdd(List<GroupsModel> Groups, List<RolesModel> Roles, List<GroupRolesModel> GroupRoles, List<CodesModel> SystemConstants)
        {
            SuggestedGroupsSource.ReFill(Groups);
            UserTypeSource.ReFill(SystemConstants.Where(x => x.CMasterId == SystemValues.MasterSystemConstants.UserType));
            CommunicationCodeSource.ReFill(SystemConstants.Where(x => x.CMasterId == SystemValues.MasterSystemConstants.CommunicationType));
            this.GroupRoles = GroupRoles;
            this.Roles = Roles;
        }
        public void Add(object valuse)
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
                        PeIdentity = PersonalId,
                        PeName = FullName,
                        PeType = (int)SelectedUserType.CId,
                        PeAddress = ""
                    };
                    var personChangeValue = 0;
                    long personInsertId = 0;
                    try { personChangeValue = DataAccess.InsertPerson(out personInsertId, person); }
                    catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
                    person.PeId = personInsertId;
                    if (personChangeValue == 1)
                    {
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
                        long userChangeValue = 0;
                        try { userChangeValue = DataAccess.InsertUser(out var userInsertId, user); }
                        catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                        if (userChangeValue == 1)
                        {
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
                            try { DataAccess.InsertPersonAddress(out var adressId, address); AddedAddress.Add(address); }
                            catch { MessageBox.Show($"Could not Add Addess to this user", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }

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
            window.DialogResult = false;
            window.Close();
        }

        public void AddGroup()
        {
            AddedGroupsSource.Add(SelectedSuggestedItem);
            SuggestedGroupsSource.Remove(SelectedSuggestedItem);
        }
        public void RemoveGroupCommand()
        {
            SuggestedGroupsSource.Add(SelectedAddedItem);
            AddedGroupsSource.Remove(SelectedAddedItem);
        }
        public void AddComm()
        {
            CommunicationSource.Add(PersonsCommunicationModel.Create());
        }
        public void DeleteComm()
        {
            if (SelectedCommItem != null)
                CommunicationSource.Remove(SelectedCommItem);
        }
    }
}
