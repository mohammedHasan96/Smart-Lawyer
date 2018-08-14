using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class WitnesseesTable
    {
        public static readonly String TableName = "witnessees";
        public static ColumnInfo WitId { get; } = ("Wit_id", typeof(long));
        public static ColumnInfo WiType { get; } = ("Wi_type", typeof(int));
        public static ColumnInfo DeIdFk { get; } = ("de_id_fk", typeof(int));
        public static ColumnInfo WiPerFk { get; } = ("wi_per_fk", typeof(int));
    }
}