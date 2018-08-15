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
        public static List<PersonsCommunicationModel> PersonsCommunicationData()
        {
            var query = $@"SELECT * FROM {PersonsCommunicationTable.TableName}";
            return SQLSelectAs<PersonsCommunicationModel>(query, typeof(PersonsCommunicationTable)).ToList();
        }

        public static List<PersonsCommunicationModel> GetPersonCommunicationById(long personId)
        {
            var query = $@"SELECT * FROM {PersonsCommunicationTable.TableName} WHERE {PersonsCommunicationTable.CoPeIdFk} = {personId}";
            return SQLSelectAs<PersonsCommunicationModel>(query, typeof(PersonsCommunicationTable)).ToList();
        }

        public static int InsertPersonCommunication(out long insertId, PersonsCommunicationModel personAddress)
        {
            var changedCount = Insert(out insertId, PersonsCommunicationTable.TableName, new ParamtersMap
            {
                [PersonsCommunicationTable.CoName] = personAddress.CoName,
                [PersonsCommunicationTable.CoPeIdFk] = personAddress.CoPeIdFk,
                [PersonsCommunicationTable.CoValue] = personAddress.CoValue
            });
            return changedCount;
        }

        public static int UpdatePersonCommunication(int CommunicationId, PersonsCommunicationModel personAddress)
            => Update(PersonsCommunicationTable.TableName, new ParamtersMap
            {
                [PersonsCommunicationTable.CoName] = personAddress.CoName,
                [PersonsCommunicationTable.CoPeIdFk] = personAddress.CoPeIdFk,
                [PersonsCommunicationTable.CoValue] = personAddress.CoValue
            }, $"{PersonsCommunicationTable.CoId}={CommunicationId}");

        public static int DeletePersonCommunication(int CommunicationId)
            => Delete(PersonsCommunicationTable.TableName, $"{PersonsCommunicationTable.CoId}={CommunicationId}");

        public static List<PersonsCommunicationModel> SearchPersonsCommunication(String searchKey)
        {
            var query = $@"SELECT * FROM {PersonsCommunicationTable.TableName} WHERE {PersonsCommunicationTable.CoName} LIKE '%{searchKey}%' OR {PersonsCommunicationTable.CoValue} LIKE '%{searchKey}%'";
            return SQLSelectAs<PersonsCommunicationModel>(query, typeof(PersonsCommunicationTable)).ToList();
        }
    }
}
