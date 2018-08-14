using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class AppealsSlanderTable
    {
        public static readonly String TableName = "appeals_slander";
        public static ColumnInfo ApSlId { get; } = ("ap_sl_id", typeof(int));
        public static ColumnInfo ApSlType { get; } = ("ap_sl_type", typeof(int));
        public static ColumnInfo ApSlNumber { get; } = ("ap_sl_number", typeof(String));
        public static ColumnInfo ApSlDate { get; } = ("ap_sl_date", typeof(DateTime));
        public static ColumnInfo ApSlNotic { get; } = ("ap_sl_notic", typeof(String));
        public static ColumnInfo ApSlIssueIdFk { get; } = ("ap_sl_issue_id_fk", typeof(int));
    }
}