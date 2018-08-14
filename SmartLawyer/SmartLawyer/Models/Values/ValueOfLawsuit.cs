using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class ValueOfLawsuitTable
    {
        public static readonly String TableName = "value_of_lawsuit";
        public static ColumnInfo VowId { get; } = ("vow_id", typeof(int));
        public static ColumnInfo VowValueLawsuit { get; } = ("vow_value_lawsuit", typeof(double));
        public static ColumnInfo VowCurrency { get; } = ("vow_currency", typeof(long));
        public static ColumnInfo VowIssueIdFk { get; } = ("vow_issue_id_fk", typeof(long));
    }
}