using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class FeesTable
    {
        public static readonly String TableName = "fees";
        public static ColumnInfo FeId { get; } = ("fe_id", typeof(int));
        public static ColumnInfo FeValue { get; } = ("fe_value", typeof(String));
        public static ColumnInfo FeDeIdFk { get; } = ("fe_de_id_fk", typeof(int));
        public static ColumnInfo FeFileIdFk { get; } = ("fe_file_id_fk", typeof(int));
        public static ColumnInfo FeCurrencyTypeCfk { get; } = ("fe_currency_type_cfk", typeof(long));
        public static ColumnInfo FeNoticIdFk { get; } = ("fe_notic_id_fk", typeof(long));
    }
}