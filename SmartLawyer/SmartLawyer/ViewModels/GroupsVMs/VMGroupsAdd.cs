using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public virtual bool IsInProgress { get; set; } = false;


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
            IsInProgress = true;
            new Thread(() =>
            {
                if (GroupName == null)
                {
                    MessageBox.Show("Group Name Cant be Empty !!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (GroupDescription == null)
                    GroupDescription = "";
                AddedGroup = new GroupsModel()
                {
                    GName = GroupName,
                    GDescription = GroupDescription
                };
                var groupChangeValue = 0;
                var groupInsertId = default(long);
                try
                {
                    groupChangeValue = DataAccess.InsertGroup(out groupInsertId, AddedGroup);
                    AddedGroup.GId = (int)groupInsertId;
                }
                catch { MessageBox.Show("could not open connection with server!\nCheck your internet connection or server is connected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                if (groupChangeValue == 1)
                {
                    foreach (var item in DataGridSource)
                    {
                        if (item.RoleSelected())
                        {
                            var groupRole = new GroupRolesModel()
                            {
                                GrolrRoleIdFk = item.RoleId,
                                GrolrGIdFk = (int)groupInsertId,
                                GroleAdd = item.GroleAdd,
                                GroleEdit = item.GroleEdit,
                                GroleDelete = item.GroleDelete,
                                GroleView = item.GroleView,
                                GrolePrint = item.GrolePrint,
                                GroleExport = item.GroleExport
                            };
                            try { DataAccess.InsertGroupeRole(out var id, groupRole); }
                            catch { MessageBox.Show($"some thing went wrong!\nFild to add {{{item.RoleName}}} to {{{AddedGroup.GName}}}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
                            AddedGroupRoles.Add(groupRole);
                        }
                    }
                    IsInProgress = true;
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        window.DialogResult = true;
                        window.Close();
                    });
                }
                else
                    MessageBox.Show("Field to add Group !!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            })
            { IsBackground = true }.Start();

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
