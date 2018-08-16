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

        public List<GroupRolesModel> GroupRoles { get; private set; } = new List<GroupRolesModel>();
        public List<RolesModel> Roles { get; private set; } = new List<RolesModel>();

        public void Add()
        {
            foreach (var item in Roles)
            {
                item.IsChecked = false;
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
                    foreach (var item in DataGridSource)
                    {
                        if (item.IsChecked)
                        {
                            DataAccess.DeleteGroup(SelectedDataItem.GId);
                            DataAccess.DeleteGroupRoles(SelectedDataItem.GId);
                        }
                    }
                    DataGridSource.ReFill(DataGridSource.Where(x => !x.IsChecked).ToList());
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
                var item = (GroupsModel)SelectedDataItem;
                for (int i = 0; i < Roles.Count; i++)
                {
                    if (GroupRolesSource.Contains(Roles[i]))
                        Roles[i].IsChecked = true;
                    else
                        Roles[i].IsChecked = false;

                }
                //foreach (var role in GroupRolesSource)
                //{
                //    Roles[Roles.IndexOf(role)].Checked = true;
                //}
                VGroupsEdit edit = new VGroupsEdit(Roles, item);
                if (edit.ShowDialog() == true)
                {
                    var dataContext = edit.DataContext as VMGroupsEdit;
                    DataGridSource.Remove(SelectedDataItem);
                    DataGridSource.Add(dataContext.EditGroup);
                }
            }
        }

        public void Export()
        {

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public void Refresh()
        {
            new Thread(() =>
            {
                List<GroupsModel> dataSource = null;
                Thread inProgress = new Thread(() =>
                {
                    dataSource = DataAccess.GroupsData();
                        GroupRoles = DataAccess.GroupRolesData();
                        Roles = DataAccess.RolesData();
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
            })
            { IsBackground = true }.Start();
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
                    GroupRolesSource.Add(Roles.Where(x => x.RoleId == item.GrolrRoleIdFk).First());
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
