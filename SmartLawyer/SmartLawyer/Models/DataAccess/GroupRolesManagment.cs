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
            var query = $@"SELECT * FROM {GroupRolesTable.TableName} WHERE {GroupRolesTable.GroupId} = {groupId}";
            return SQLSelectAs<GroupRolesModel>(query, typeof(GroupRolesTable)).ToList();
        }

        public static int InsertGroupeRole(out long insertId, GroupRolesModel groupRole)
        {
            var changedCount = Insert(out var ID, GroupRolesTable.TableName, new ParamtersMap
            {
                [GroupRolesTable.GroupId] = groupRole.GroupId,
                [GroupRolesTable.RoleId] = groupRole.RoleId
            });
            insertId = ID;
            return changedCount;
        }

        public static int UpdateGroupRole(int RoleId, GroupRolesModel groupRole)
            => Update(GroupRolesTable.TableName, new ParamtersMap
            {
                [GroupRolesTable.GroupId] = groupRole.GroupId,
                [GroupRolesTable.RoleId] = groupRole.RoleId
            }, $"{GroupRolesTable.RoleId}={RoleId}");

        public static int DeleteGroupRoles(int GroupId)
            => Delete(GroupRolesTable.TableName, $"{GroupRolesTable.GroupId}={GroupId}");

        public static List<GroupRolesModel> SearchGroupRoles(String searchKey)
        {
            var query = $@"SELECT * FROM {GroupRolesTable.TableName} WHERE {GroupRolesTable.GroupId} LIKE '%{searchKey}%' OR {GroupRolesTable.RoleId} LIKE '%{searchKey}%'";
            return SQLSelectAs<GroupRolesModel>(query, typeof(GroupRolesTable)).ToList();
        }
    }
}
