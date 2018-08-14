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
        public static List<RolesModel> RolesData()
        {
            var query = $@"SELECT * FROM {RolesTable.TableName}";
            return SQLSelectAs<RolesModel>(query, typeof(RolesTable)).ToList();
        }

        public static List<RolesModel> GetRoleById(int roleId)
        {
            var query = $@"SELECT * FROM {RolesTable.TableName} WHERE {RolesTable.RoleId} = {roleId}";
            return SQLSelectAs<RolesModel>(query, typeof(RolesTable)).ToList();
        }

        public static int InsertRole(out long insertId, RolesModel role)
        {
            var changedCount = Insert(out var ID, RolesTable.TableName, new ParamtersMap
            {
                [RolesTable.RoleName] = role.RoleName,
                [RolesTable.Description] = role.Description
            });
            insertId = ID;
            return changedCount;
        }

        public static int UpdateRole(int RoleId, RolesModel role)
            => Update(RolesTable.TableName, new ParamtersMap
            {
                [RolesTable.RoleName] = role.RoleName,
                [RolesTable.Description] = role.Description
            }, $"{RolesTable.RoleId}={RoleId}");

        public static int DeleteRole(int RoleId)
            => Delete(RolesTable.TableName, $"{RolesTable.RoleId}={RoleId}");

        public static List<RolesModel> SearchRoles(String searchKey)
        {
            var query = $@"SELECT * FROM {RolesTable.TableName} WHERE {RolesTable.RoleName} LIKE '%{searchKey}%' OR {RolesTable.Description} LIKE '%{searchKey}%'";
            return SQLSelectAs<RolesModel>(query, typeof(RolesTable)).ToList();
        }
    }
}
