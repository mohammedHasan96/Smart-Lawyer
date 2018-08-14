using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class IssueTransactionTable
    {
        public static readonly String TableName = "issue_transaction";
        public static ColumnInfo TrId { get; } = ("tr_id", typeof(long));
        public static ColumnInfo TrIssueIdFk { get; } = ("tr_issue_id_fk", typeof(long));
        public static ColumnInfo TrAddressCourtCfk { get; } = ("tr_address_court_cfk", typeof(int));
        public static ColumnInfo TrCourtTypeCfk { get; } = ("tr_court_type_cfk", typeof(int));
        public static ColumnInfo TrDateConversion { get; } = ("tr_date_conversion", typeof(DateTime));
        public static ColumnInfo TrSeIssueIdFk { get; } = ("tr_se_issue_id_fk", typeof(long));
    }
}