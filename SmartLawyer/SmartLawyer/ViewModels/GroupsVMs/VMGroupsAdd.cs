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
    public class VMGroupsAdd
    {
        public static VMGroupsAdd Create(List<RolesModel> roles)
            => ViewModelSource.Create(() => new VMGroupsAdd(roles));
        public virtual String GroupName { get; set; }
        public virtual String GroupDescription { get; set; }
        public ObservableCollection<RolesModel> DataGridSource { get; }
            = new ObservableCollection<RolesModel>();
        public GroupsModel AddedGroup = null;
        public List<GroupRolesModel> AddedGroupRoles = new List<GroupRolesModel>();

        public VMGroupsAdd(List<RolesModel> roles)
        {
            DataGridSource.ReFill(roles);
        }
        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }

        public void Add(Window window)
        {
            if (GroupName == null)
            {
                MessageBox.Show("Group Name Cant be Empty !!");
                return;
            }
            if (GroupDescription == null)
                GroupDescription = "";
            AddedGroup = new GroupsModel()
            {
                GName = GroupName,
                GDescription = GroupDescription
            };
            var groupChangeValue = DataAccess.InsertGroup(out var groupInsertId, AddedGroup);
            AddedGroup.GId = (int)groupInsertId;
            if (groupChangeValue == 1)
            {
                foreach (var item in DataGridSource)
                {
                    if (item.IsChecked)
                    {
                        var groupRole = new GroupRolesModel()
                        {
                            GrolrGIdFk = item.RoleId,
                            GrolrRoleIdFk = (int)groupInsertId,
                            GroleAdd = item.GroleAdd,
                            GroleEdit = item.GroleEdit,
                            GroleDelete = item.GroleDelete,
                            GroleView = item.GroleView,
                            GrolePrint = item.GrolePrint,
                            GroleExport = item.GroleExport
                        };
                        DataAccess.InsertGroupeRole(out var id, groupRole);
                        AddedGroupRoles.Add(groupRole);
                    }
                }
                window.DialogResult = true;
                window.Close();
            }
            else
                MessageBox.Show("Field to add Group !!");
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
