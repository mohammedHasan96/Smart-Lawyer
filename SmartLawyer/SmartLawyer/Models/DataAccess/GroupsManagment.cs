using MySql.Data.MySqlClient;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParamtersMap = System.Collections.Generic.Dictionary<string, object>;

namespace SmartLawyer.Models
{
    partial class DataAccess
    {
        public static List<GroupsModel> GroupsData()
        {
            var query = $@"SELECT * FROM {GroupsTable.TableName}";
            return SQLSelectAs<GroupsModel>(query, typeof(GroupsTable)).ToList();
        }

        public static int InsertGroup(out long insertId, GroupsModel group)
        {
            var changedCount = Insert(out insertId, GroupsTable.TableName, new ParamtersMap
            {
               [GroupsTable.GName] = group.GName,
               [GroupsTable.GDescription] = group.GDescription
            });
            return changedCount;
        }

        public static int UpdateGroup(int GroupId, GroupsModel group)
            => Update(GroupsTable.TableName, new ParamtersMap
            {
                [GroupsTable.GName] = group.GName,
                [GroupsTable.GDescription] = group.GDescription
            }, $"{GroupsTable.GId}={GroupId}");

        public static int DeleteGroup(int GroupId)
            => Delete(GroupsTable.TableName, $"{GroupsTable.GId}={GroupId}");

        public static List<GroupsModel> SearchGroups(String searchKey)
        {
            var query = $@"SELECT * FROM {GroupsTable.TableName} WHERE {GroupsTable.GName} LIKE '%{searchKey}%' OR {GroupsTable.GDescription} LIKE '%{searchKey}%'";
            return SQLSelectAs<GroupsModel>(query, typeof(GroupsTable)).ToList();
        }
    }
}
