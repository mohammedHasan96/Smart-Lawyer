using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class IssueSessionTable
    {
        public static readonly String TableName = "issue_session";
        public static ColumnInfo SeId { get; } = ("se_id", typeof(int));
        public static ColumnInfo SeIssueIdFk { get; } = ("se_issue_id_fk", typeof(long));
        public static ColumnInfo SeFileId { get; } = ("se_file_id", typeof(long));
        public static ColumnInfo SeNotic { get; } = ("se_notic", typeof(String));
        public static ColumnInfo SeNextAction { get; } = ("se_next_action", typeof(String));
        public static ColumnInfo IssueSeNumberSe { get; } = ("issue_se_number_se", typeof(int));
        public static ColumnInfo IssueDateNextSe { get; } = ("issue_date_next_se", typeof(String));
        public static ColumnInfo CreatedAt { get; } = ("created_at", typeof(DateTime));
        public static ColumnInfo CreatedBy { get; } = ("created_by", typeof(int));
        public static ColumnInfo UpdatedAt { get; } = ("updated_at", typeof(DateTime));
        public static ColumnInfo UpdatedBy { get; } = ("updated_by", typeof(int));
        public static ColumnInfo IsTransaction { get; } = ("is_transaction", typeof(int));
    }
}