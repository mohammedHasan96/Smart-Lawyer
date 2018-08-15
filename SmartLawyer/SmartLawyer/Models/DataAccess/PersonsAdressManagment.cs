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
        public static List<PersonsAddressModel> PersonsAddressData()
        {
            var query = $@"SELECT * FROM {PersonsAddressTable.TableName}";
            return SQLSelectAs<PersonsAddressModel>(query, typeof(PersonsAddressTable)).ToList();
        }

        public static List<PersonsAddressModel> GetPersonAddressById(long personId)
        {
            var query = $@"SELECT * FROM {PersonsAddressTable.TableName} WHERE {PersonsAddressTable.PeAdPerIdFk} = {personId}";
            return SQLSelectAs<PersonsAddressModel>(query, typeof(PersonsAddressTable)).ToList();
        }

        public static int InsertPersonAddress(out long insertId, PersonsAddressModel personAddress)
        {
            var changedCount = Insert(out insertId, PersonsAddressTable.TableName, new ParamtersMap
            {
                [PersonsAddressTable.PeAdStreetName] = personAddress.PeAdStreetName,
                [PersonsAddressTable.PeAdCity] = personAddress.PeAdCity,
                [PersonsAddressTable.PeAdPerIdFk] = personAddress.PeAdPerIdFk
            });
            return changedCount;
        }

        public static int UpdatePersonAddress(int AddressId, PersonsAddressModel personAddress)
            => Update(PersonsAddressTable.TableName, new ParamtersMap
            {
                [PersonsAddressTable.PeAdStreetName] = personAddress.PeAdStreetName,
                [PersonsAddressTable.PeAdCity] = personAddress.PeAdCity,
                [PersonsAddressTable.PeAdPerIdFk] = personAddress.PeAdPerIdFk
            }, $"{PersonsAddressTable.PeAdId}={AddressId}");

        public static int DeletePersonAddress(int AddressId)
            => Delete(PersonsAddressTable.TableName, $"{PersonsAddressTable.PeAdId}={AddressId}");

        public static List<PersonsAddressModel> SearchPersonsAddress(String searchKey)
        {
            var query = $@"SELECT * FROM {PersonsAddressTable.TableName} WHERE {PersonsAddressTable.PeAdStreetName} LIKE '%{searchKey}%'";
            return SQLSelectAs<PersonsAddressModel>(query, typeof(PersonsAddressTable)).ToList();
        }
    }
}
