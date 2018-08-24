using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParamtersMap = System.Collections.Generic.Dictionary<string, object>;

namespace SmartLawyer.Models
{
    partial class DataAccess
    {
        public static List<GroupRolesModel> GroupRolesData()
        {
            var query = $@"SELECT * FROM {GroupRolesTable.TableName}";
            return SQLSelectAs<GroupRolesModel>(query, typeof(GroupRolesTable)).ToList();
        }

        public static List<GroupRolesModel> GetGroupRoleByGroupId(int groupId)
        {
            var query = $@"SELECT * FROM {GroupRolesTable.TableName} WHERE {GroupRolesTable.GrolrGIdFk} = {groupId}";
            return SQLSelectAs<GroupRolesModel>(query, typeof(GroupRolesTable)).ToList();
        }
        public static int InsertGroupeRole(out long insertId, GroupRolesModel groupRole)
        {
            var changedCount = Insert(out insertId, GroupRolesTable.TableName, new ParamtersMap
            {
                [GroupRolesTable.GrolrGIdFk] = groupRole.GrolrGIdFk,
                [GroupRolesTable.GrolrRoleIdFk] = groupRole.GrolrRoleIdFk,
                [GroupRolesTable.GroleAdd] = groupRole.GroleAdd,
                [GroupRolesTable.GroleEdit] = groupRole.GroleEdit,
                [GroupRolesTable.GroleDelete] = groupRole.GroleDelete,
                [GroupRolesTable.GrolePrint] = groupRole.GrolePrint,
                [GroupRolesTable.GroleView] = groupRole.GroleView,
                [GroupRolesTable.GroleExport] = groupRole.GroleExport
            });
            return changedCount;
        }

        public static int UpdateGroupRole(int RoleId, GroupRolesModel groupRole)
            => Update(GroupRolesTable.TableName, new ParamtersMap
            {
                [GroupRolesTable.GrolrGIdFk] = groupRole.GrolrGIdFk,
                [GroupRolesTable.GrolrRoleIdFk] = groupRole.GrolrRoleIdFk,
                [GroupRolesTable.GroleAdd] = groupRole.GroleAdd,
                [GroupRolesTable.GroleEdit] = groupRole.GroleEdit,
                [GroupRolesTable.GroleDelete] = groupRole.GroleDelete,
                [GroupRolesTable.GrolePrint] = groupRole.GrolePrint,
                [GroupRolesTable.GroleView] = groupRole.GroleView,
                [GroupRolesTable.GroleExport] = groupRole.GroleExport
            }, $"{GroupRolesTable.GrolrRoleIdFk}={RoleId}");

        public static int DeleteGroupRoles(int GroupId)
            => Delete(GroupRolesTable.TableName, $"{GroupRolesTable.GrolrGIdFk}={GroupId}");

        public static List<GroupRolesModel> SearchGroupRoles(String searchKey)
        {
            var query = $@"SELECT * FROM {GroupRolesTable.TableName} WHERE {GroupRolesTable.GrolrGIdFk} LIKE '%{searchKey}%' OR {GroupRolesTable.GrolrRoleIdFk} LIKE '%{searchKey}%'";
            return SQLSelectAs<GroupRolesModel>(query, typeof(GroupRolesTable)).ToList();
        }
    }
}
