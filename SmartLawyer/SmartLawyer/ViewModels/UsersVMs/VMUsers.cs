using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using SmartLawyer.ViewModels.Main;
using SmartLawyer.Views;
using SmartLawyer.Views.Controls.Users;
using SmartLawyer.Views.Person;
using SmartLawyer.Views.Users;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Classes = SmartLawyer.Models.Classes;
using Values = SmartLawyer.Models.Values;

namespace SmartLawyer.ViewModels.UsersVMs
{
    public class VMUsers : MarkupExtension, VMManagmentSystem<UsersModel>
    {
        //public static VMUsers Create()
        //    => ViewModelSource.Create(() => new VMUsers());

        public virtual string Title { get; set; } = "UsersTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "userstitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; } = new UCUserAdvancedSearch();
        public ObservableCollection<UsersModel> DataGridSource { get; set; }
            = new ObservableCollection<UsersModel>();//= DataAccess.UsersData();
        public virtual UsersModel SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(SystemValues.MyColors.Default));
        public virtual object MainContentValue { get; set; } = new UCUsersMain();

        public List<GroupsModel> Groups { get; private set; } = new List<GroupsModel>();
        public List<GroupRolesModel> GroupRoles { get; private set; } = new List<GroupRolesModel>();
        public List<UserGroupModel> UserGroups { get; private set; } = new List<UserGroupModel>();
        public List<RolesModel> Roles { get; private set; } = new List<RolesModel>();
        public bool IsInProgress { get; set; }

        public List<PersonsModel> Persons { get; private set; } = new List<PersonsModel>();
        public List<PersonsAddressModel> PersonsAddress { get; private set; } = new List<PersonsAddressModel>();
        public List<PersonsCommunicationModel> PersonCommunications { get; private set; } = new List<PersonsCommunicationModel>();
        public List<CodesModel> PersonsTypes { get; private set; } = new List<CodesModel>();
        public List<CodesModel> SystemConstants { get; private set; } = new List<CodesModel>();

        public void Add()
        {
            VUserAdd add = new VUserAdd(Groups, Roles, GroupRoles, SystemConstants);
            if (add.ShowDialog() == true)
            {

            }
        }
        public void Archive()
        {

        }
        public void Delete()
        {
            if (SelectedDataItem != null)
            {
                if (MessageBox.Show("Are you sure you want to delete all selected Users??",
                "Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    IsInProgress = true;
                    new Thread(() =>
                    {
                        foreach (var item in DataGridSource)
                        {
                            if (item.IsChecked)
                            {
                                try
                                {
                                    
                                    DataAccess.DeleteUserGroups((int)item.UPIdFk);
                                    DataAccess.DeletePersonAddress((int)item.UPIdFk);
                                    DataAccess.DeletePersonCommunication((int)item.UPIdFk);
                                    DataAccess.DeletePerson((int)item.UPIdFk);
                                    DataAccess.DeleteUser((int)item.UPIdFk);
                                }
                                catch { MessageBox.Show($"could not open connection with server while deleting {item.UUserName}!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                            }
                        }
                        DataGridSource.ReFill(DataGridSource.Where(x => !x.IsChecked).ToList());
                        IsInProgress = false;
                    })
                    { IsBackground = true }.Start();
                }
            }
        }
        public void Edit()
        {
            if (SelectedDataItem != null)
            {
                var user = SelectedDataItem;
                var person = Persons.Where(x => x.PeId == user.UPIdFk).FirstOrDefault();
                var adress = PersonsAddress.Where(x => x.PeAdPerIdFk == person.PeId).FirstOrDefault();
                if (adress != null)
                    person.PeAddress = $"{adress.PeAdCity.Trim()} - {adress.PeAdStreetName.Trim()}";
                VUserEdit edit = new VUserEdit(user, person, PersonCommunications, Groups, Roles, GroupRoles, UserGroups, SystemConstants);
                if (edit.ShowDialog() == true)
                    Refresh();
            }
        }
        public void Export()
        {

        }
        Thread refrechThread;
        public void Refresh()
        {
            refrechThread = new Thread(() =>
            {
                List<UsersModel> Users = new List<UsersModel>();
                Thread inProgress = new Thread(() =>
                {
                    try
                    {
                        Groups = DataAccess.GroupsData();
                        Users = DataAccess.UsersData();
                        GroupRoles = DataAccess.GroupRolesData();
                        UserGroups = DataAccess.UserGroupsData();
                        Roles = DataAccess.RolesData();
                        SystemConstants = DataAccess.CodesData();
                        Persons = DataAccess.PersonsData();
                        PersonsAddress = DataAccess.PersonsAddressData();
                        PersonCommunications = DataAccess.PersonsCommunicationData();
                    }
                    catch { MessageBox.Show("could not open connection whith server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
                })
                { IsBackground = true };

                inProgress.Start();
                while (inProgress.IsAlive)
                {
                    if (RotateAngle > 360)
                        RotateAngle = 0;
                    RotateAngle += 18.25;
                    Thread.Sleep(50);
                }
                while (RotateAngle > 0 && RotateAngle < 365)
                {
                    RotateAngle += 18.25;
                    Thread.Sleep(50);
                }
                RotateAngle = 0;
                DataGridSource.ReFill(Users);
            })
            { IsBackground = true };
            refrechThread.Start();
        }
        public void View()
        {
            VUserView view = new VUserView();
            view.ShowDialog();
        }
        public void AdvancedSearchTogel()
        {
            ShowAdvancedSearch = !ShowAdvancedSearch;
        }
        public void Dispos()
        {
            if (refrechThread != null && refrechThread.IsAlive)
                refrechThread.Abort();
        }

        public void DoAdvancedSearch()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public void CheckAll()
        {
            foreach (var item in DataGridSource)
            {
                item.IsChecked = true;
            }
        }

        public void UncheckAll()
        {
            foreach (var item in DataGridSource)
            {
                item.IsChecked = false;
            }
        }
    }
}
