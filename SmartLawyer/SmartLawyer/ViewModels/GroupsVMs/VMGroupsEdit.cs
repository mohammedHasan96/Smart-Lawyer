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

namespace SmartLawyer.ViewModels.GroupsVMs
{
    public class VMGroupsEdit
    {
        public static VMGroupsEdit Create(List<RolesModel> roles,GroupsModel group)
            => ViewModelSource.Create(() => new VMGroupsEdit(roles,group));
        public virtual GroupsModel Group { get; set; }
        public virtual String GroupName { get; set; }
        public virtual String GroupDescription { get; set; }
        public ObservableCollection<RolesModel> DataGridSource { get; }
            = new ObservableCollection<RolesModel>();
        public GroupsModel EditGroup ;

        public VMGroupsEdit(List<RolesModel> roles,GroupsModel group)
        {
            Group = group;
            PresentGroup(group);
            DataGridSource.ReFill(roles);
        }
        private void PresentGroup(GroupsModel group)
        {
            GroupName = group.GName;
            GroupDescription = group.GDescription;
        }
        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }

        public void Edit(Window window)
        {
            EditGroup = new GroupsModel()
            {
                GName = GroupName,
                GDescription = GroupDescription
            };
            var groupChangeValue = DataAccess.UpdateGroup(Group.GId, EditGroup);
            if (groupChangeValue == 1)
            {
                DataAccess.DeleteGroupRoles(Group.GId);
                foreach (var item in DataGridSource)
                {
                    if (item.IsChecked)
                    {
                        DataAccess.InsertGroupeRole(out var id, new GroupRolesModel() { GrolrGIdFk = item.RoleId, GrolrRoleIdFk = Group.GId });
                    }
                }
                window.DialogResult = true;
                window.Close();
            }
            else
                MessageBox.Show("Field to Edit Group !!");
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
