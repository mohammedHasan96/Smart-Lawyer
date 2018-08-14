using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class PropertyTable
    {
        public static readonly String TableName = "property";
        public static ColumnInfo PrId { get; } = ("pr_id", typeof(int));
        public static ColumnInfo PrTypeCfk { get; } = ("pr_type_cfk", typeof(int));
        public static ColumnInfo PrNotic { get; } = ("pr_notic", typeof(String));
        public static ColumnInfo PrCoIdFk { get; } = ("pr_co_id_fk", typeof(long));
    }
}