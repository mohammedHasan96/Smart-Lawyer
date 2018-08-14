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
        public static List<CodesModel> CodesData()
        {
            var query = $@"SELECT * FROM {CodesTable.TableName}";
            return SQLSelectAs<CodesModel>(query, typeof(CodesTable)).ToList();
        }
        public static List<CodesModel> CodesData(long masterId)
        {
            var query = $@"SELECT * FROM {CodesTable.TableName} WHERE {CodesTable.CMasterId} = {masterId}";
            return SQLSelectAs<CodesModel>(query, typeof(CodesTable)).ToList();
        }

        public static int InsertCode(out long insertId, CodesModel code)
        {
            var changedCount = Insert(out insertId, CodesTable.TableName, new ParamtersMap
            {
                [CodesTable.CName] = code.CName,
                [CodesTable.CMasterId] = code.CMasterId,
                [CodesTable.CDesc] = code.CDesc
            });
            return changedCount;
        }

        public static int UpdateCode(long CodeId, CodesModel code)
            => Update(CodesTable.TableName, new ParamtersMap
            {
                [CodesTable.CName] = code.CName,
                [CodesTable.CMasterId] = code.CMasterId,
                [CodesTable.CDesc] = code.CDesc
            }, $"{CodesTable.CId}={CodeId}");

        public static int DeleteCode(long CodeId)
            => Delete(CodesTable.TableName, $"{CodesTable.CId}={CodeId}");

        //public static List<CodesModel> SearchCodes(String searchKey)
        //{
        //    var query = $@"SELECT * FROM {CodesTable.TableName} WHERE {CodesTable.CName} LIKE '%{searchKey}%' OR {CodesTable.GDescription} LIKE '%{searchKey}%'";
        //    return SQLSelectAs<CodesModel>(query, typeof(CodesTable)).ToList();
        //}
    }
}
