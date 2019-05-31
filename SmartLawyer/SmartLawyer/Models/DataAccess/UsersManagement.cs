using MySql.Data.MySqlClient;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ParamtersMap = System.Collections.Generic.Dictionary<string, object>;

namespace SmartLawyer.Models
{
    partial class DataAccess
    {

        public static List<UsersModel> UsersData()
        {
            var query = $@"SELECT * FROM {UsersTable.TableName}";
            return SQLSelectAs<UsersModel>(query,typeof(UsersTable)).ToList();
        }

        public static int InsertUser(out long insertId, UsersModel user)
        {
            var changedCount = Insert(out insertId, UsersTable.TableName, new ParamtersMap
            {
                [UsersTable.UPIdFk] = user.UPIdFk,
                [UsersTable.UUserName] = user.UUserName,
                [UsersTable.UEmail] = user.UEmail,
                [UsersTable.UPassword] = user.UPassword,
                [UsersTable.UpdatedBy] = user.UpdatedBy,
                //[UsersTable.UpdatedAt] = user.UpdatedAt,
                [UsersTable.CreatedBy] = user.CreatedBy,
                //[UsersTable.CreatedAt] = user.CreatedAt,
                [UsersTable.UIsActive] = user.UIsActive
                //DateOfBirth Here
            });
            return changedCount;
        }

        public static int UpdateUser(int UserId, UsersModel user)
            => Update(PersonsTable.TableName, new ParamtersMap
            {
                //[UsersTable.UPIdFk] = user.UPIdFk,
                [UsersTable.UUserName] = user.UUserName,
                [UsersTable.UEmail] = user.UEmail,
                [UsersTable.UPassword] = user.UPassword,
                [UsersTable.UpdatedBy] = user.UpdatedBy,
                [UsersTable.UIsActive] = user.UIsActive,
                // UserType Here
                //DateOfBirth Here
            }, $"{UsersTable.UPIdFk}={UserId}");

        public static int DeleteUser(int UserId)
            => Delete(UsersTable.TableName, $"{UsersTable.UPIdFk}={UserId}");

        //public static DataView SearchUsers(String searchKey)
        //{
        //    var conn = OpenConnection();
        //    var cmd = conn.CreateCommand();
        //    cmd.CommandText = $@"SELECT * FROM {UsersTable.TableName} WHERE {UsersTable.UUserName} LIKE '%{searchKey}%'";
        //    var adapter = new MySqlDataAdapter((MySqlCommand)cmd);
        //    var dTable = new DataTable();
        //    adapter.Fill(dTable);
        //    return dTable.DefaultView;
        //}
    }
}

