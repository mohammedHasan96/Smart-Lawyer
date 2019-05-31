using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using SmartLawyer.ViewModels.Main;
using SmartLawyer.Views.Controls.Groups;
using SmartLawyer.Views.Controls.Users;
using SmartLawyer.Views.Groups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartLawyer.ViewModels.GroupsVMs
{
    public class VMGroups : MarkupExtension, VMManagmentSystem<GroupsModel>
    {
        public ObservableCollection<GroupsModel> DataGridSource { get; }
            = new ObservableCollection<GroupsModel>();
        public string Title { get; set; } = "GroupsTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "groupstitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; } //
        public virtual GroupsModel SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(SystemValues.MyColors.Default));
        public virtual object MainContentValue { get; set; } = new UCGroupsMain();
        public ObservableCollection<RolesModel> GroupRolesSource { get; }
            = new ObservableCollection<RolesModel>();
        public virtual bool IsInProgress { get; set; } = false;

        public List<GroupRolesModel> GroupRoles { get; private set; } = new List<GroupRolesModel>();
        public List<RolesModel> Roles { get; private set; } = new List<RolesModel>();

        public void Add()
        {
            foreach (var item in Roles)
            {
                item.IsChecked = false;
                item.GroleAdd = false.ToIntState();
                item.GroleEdit = false.ToIntState();
                item.GroleDelete = false.ToIntState();
                item.GroleExport = false.ToIntState();
                item.GrolePrint = false.ToIntState();
                item.GroleView = false.ToIntState();
            }
            VGroupsAdd add = new VGroupsAdd(Roles);
            if (add.ShowDialog() == true)
            {
                DataGridSource.Add((add.DataContext as VMGroupsAdd).AddedGroup);
                foreach (var item in (add.DataContext as VMGroupsAdd).AddedGroupRoles)
                {
                    GroupRoles.Add(item);
                }
            }
            GroupRolesSource.Clear();
        }

        public void AdvancedSearchTogel()
        {

        }

        public void Archive()
        {

        }

        public void Delete()
        {
            if (SelectedDataItem != null)
            {
                if (MessageBox.Show("Are you sure you want to delete all selected Groups??",
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
                                    DataAccess.DeleteGroup(item.GId);
                                    DataAccess.DeleteGroupRoles(item.GId);
                                }
                                catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected","Warning",MessageBoxButton.OK,MessageBoxImage.Warning); }

                            }
                        }
                        DataGridSource.ReFill(DataGridSource.Where(x => !x.IsChecked).ToList());
                        IsInProgress = false;
                    })
                    { IsBackground = true }.Start();
                    GroupRolesSource.Clear();
                }
            }
        }

        public void DoAdvancedSearch()
        {

        }

        public void Edit()
        {
            if (SelectedDataItem != null)
            {
                var item = SelectedDataItem;
                for (int i = 0; i < Roles.Count; i++)
                {
                    var role = GroupRolesSource.Where(x => x.RoleId == Roles[i].RoleId).FirstOrDefault();
                    if (role != null)
                    {
                        var groupRoles = GroupRoles.Where(x => x.GrolrRoleIdFk == Roles[i].RoleId && x.GrolrGIdFk == item.GId).FirstOrDefault();
                        Roles[i].IsChecked = true;
                        Roles[i].GroleAdd = groupRoles.GroleAdd;
                        Roles[i].GroleEdit = groupRoles.GroleEdit;
                        Roles[i].GroleDelete = groupRoles.GroleDelete;
                        Roles[i].GroleExport = groupRoles.GroleExport;
                        Roles[i].GrolePrint = groupRoles.GrolePrint;
                        Roles[i].GroleView = groupRoles.GroleView;
                    }
                    else
                    {
                        Roles[i].IsChecked = false;
                        Roles[i].GroleAdd = false.ToIntState();
                        Roles[i].GroleEdit = false.ToIntState();
                        Roles[i].GroleDelete = false.ToIntState();
                        Roles[i].GroleExport = false.ToIntState();
                        Roles[i].GrolePrint = false.ToIntState();
                        Roles[i].GroleView = false.ToIntState();
                    }
                }
                VGroupsEdit edit = new VGroupsEdit(Roles, item);
                if (edit.ShowDialog() == true)
                {
                    var dataContext = edit.DataContext as VMGroupsEdit;
                    DataGridSource.Remove(SelectedDataItem);
                    DataGridSource.Add(dataContext.EditGroup);
                    GroupRoles.RemoveAll(x => x.GrolrGIdFk == item.GId);
                    GroupRoles.AddRange(dataContext.DataGridSource.Where(x => x.RoleSelected()).Select(x => x.ToGroupRoles(item.GId)));
                }
                GroupRolesSource.Clear();
            }
        }

        public void Export()
        {

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public void Refresh()
        {
            GroupRoles.Clear();
            new Thread(() =>
            {
                List<GroupsModel> dataSource = null;
                Thread inProgress = new Thread(() =>
                {
                    IsInProgress = true;
                    try
                    {
                        dataSource = DataAccess.GroupsData();
                        GroupRoles = DataAccess.GroupRolesData();
                        Roles = DataAccess.RolesData();
                    }
                    catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
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
                DataGridSource.ReFill(dataSource);
                IsInProgress = false;
            })
            { IsBackground = true }.Start();
            GroupRolesSource.Clear();
        }

        public void View()
        {

        }

        public void SelectIndexChanged(GroupsModel group)
        {
            if (group != null)
            {
                GroupRolesSource.Clear();
                var roles = GroupRoles.Where(x => x.GrolrGIdFk == group.GId);
                foreach (var item in roles)
                {
                    var role = Roles.Where(x => x.RoleId == item.GrolrRoleIdFk).FirstOrDefault();
                    if (role != null)
                        GroupRolesSource.Add(role.FillRoles(item));
                }
            }

        }

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
