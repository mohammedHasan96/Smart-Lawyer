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
        public static List<UserGroupModel> UserGroupsData()
        {
            var query = $@"SELECT * FROM {UserGroupTable.TableName}";
            return SQLSelectAs<UserGroupModel>(query, typeof(UserGroupTable)).ToList();
        }

        public static int InsertUserGroups(out long insertId, UserGroupModel userGroup)
        {
            var changedCount = Insert(out insertId, UserGroupTable.TableName, new ParamtersMap
            {
                [UserGroupTable.UserId] = userGroup.UserId,
                [UserGroupTable.GroupId] = userGroup.GroupId
            });
            return changedCount;
        }

        public static int DeleteUserGroups(int UserId)
            => Delete(UserGroupTable.TableName, $"{UserGroupTable.UserId}={UserId}");
    }
}
