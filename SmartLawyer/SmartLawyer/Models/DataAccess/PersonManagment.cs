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
        public static List<PersonsModel> PersonsData()
        {
            var query = $@"SELECT * FROM {PersonsTable.TableName}";
            return SQLSelectAs<PersonsModel>(query, typeof(PersonsTable)).ToList();
        }

        public static DataTable GetPerson(long personId)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT * FROM {PersonsTable.TableName} WHERE {PersonsTable.PeId} = {personId}";
            var adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            var dTable = new DataTable();
            adapter.Fill(dTable);
            return dTable;
        }
        public static int InsertPerson(out long InsertId, PersonsModel person)
        {
            var changedCount = Insert(out var ID, PersonsTable.TableName, new ParamtersMap
            {
                [PersonsTable.PeName] = person.PeName,
                [PersonsTable.PeAddress] = person.PeAddress,
                [PersonsTable.PeIdentity] = person.PeIdentity,
                [PersonsTable.PeType] = person.PeType
            });
            InsertId = ID;
            return changedCount;
        }
        public static void UpdatePerson(int PersonId, PersonsModel person)
        {
            var changedCount = Update(PersonsTable.TableName, new ParamtersMap
            {
                [PersonsTable.PeName] = person.PeName,
                [PersonsTable.PeAddress] = person.PeAddress,
                [PersonsTable.PeIdentity] = person.PeIdentity,
                [PersonsTable.PeType] = person.PeType

            }, $"customerID={PersonId}");
        }
        public static void DeletePerson(int PersonId)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            cmd.ExecuteNonQuery();
            //return PersonsData();
        }
        public static DataView SearchPersons(String searchKey)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            var adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            var dTable = new DataTable();
            adapter.Fill(dTable);
            return dTable.DefaultView;
        }
    }
}
