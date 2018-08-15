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

        public static List<PersonsModel> GetPersonById(long personId)
        {
            var query = $@"SELECT * FROM {PersonsTable.TableName} WHERE {PersonsTable.PeId} = {personId}";
            return SQLSelectAs<PersonsModel>(query, typeof(PersonsTable)).ToList();
        }

        public static int InsertPerson(out long insertId, PersonsModel person)
        {
            var changedCount = Insert(out insertId, PersonsTable.TableName, new ParamtersMap
            {
                [PersonsTable.PeName] = person.PeName,
                [PersonsTable.PeAddress] = person.PeAddress,
                [PersonsTable.PeIdentity] = person.PeIdentity,
                [PersonsTable.PeType] = person.PeType
            });
            return changedCount;
        }

        public static int UpdatePerson(int PersonId, PersonsModel person)
            => Update(PersonsTable.TableName, new ParamtersMap
            {
                [PersonsTable.PeName] = person.PeName,
                [PersonsTable.PeAddress] = person.PeAddress,
                [PersonsTable.PeIdentity] = person.PeIdentity,
                [PersonsTable.PeType] = person.PeType
            }, $"{PersonsTable.PeId}={PersonId}");

        public static int DeletePerson(int PersonId)
            => Delete(PersonsTable.TableName, $"{PersonsTable.PeId}={PersonId}");

        public static List<PersonsModel> SearchPersons(String searchKey)
        {
            var query = $@"SELECT * FROM {PersonsTable.TableName} WHERE {PersonsTable.PeName} LIKE '%{searchKey}%' OR {PersonsTable.PeIdentity} LIKE '%{searchKey}%'";
            return SQLSelectAs<PersonsModel>(query, typeof(PersonsTable)).ToList();
        }
    }
}
