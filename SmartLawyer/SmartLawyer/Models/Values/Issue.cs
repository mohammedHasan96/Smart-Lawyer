using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class IssueTable
    {
        public static readonly String TableName = "issue";
        public static ColumnInfo IssueDeIdFk { get; } = ("issue_de_id_fk", typeof(long));
        public static ColumnInfo IssueTypeCourtCfk { get; } = ("issue_type_court_cfk", typeof(long));
        public static ColumnInfo IssueAddressCourtCfk { get; } = ("issue_address_court_cfk", typeof(long));
        public static ColumnInfo IssueTypeCfk { get; } = ("issue_type_cfk", typeof(long));
        public static ColumnInfo IssueNumberOfCourt { get; } = ("issue_number_of_court", typeof(String));
        public static ColumnInfo IssueNumberCourtOpposite { get; } = ("issue_number_court_opposite", typeof(String));
        public static ColumnInfo IssueStatus { get; } = ("issue_status", typeof(int));
        public static ColumnInfo IssueStartDate { get; } = ("issue_start_date", typeof(DateTime));
        public static ColumnInfo IssueEndDate { get; } = ("issue_end_date", typeof(DateTime));
        public static ColumnInfo IssueSubjectLawsuit { get; } = ("issue_subject_lawsuit", typeof(String));
        public static ColumnInfo IssueNumberRelationIssue { get; } = ("issue_number_relation_issue", typeof(long));
        public static ColumnInfo IssueTypeRelationIssueCfk { get; } = ("issue_type_relation_issue_cfk", typeof(int));
        public static ColumnInfo CreatedAt { get; } = ("created_at", typeof(DateTime));
        public static ColumnInfo IssueOrederNumber { get; } = ("issue_oreder_number", typeof(String));
        public static ColumnInfo IssueNoticLoseWin { get; } = ("issue_notic_lose_win", typeof(String));
        public static ColumnInfo CreatedBy { get; } = ("created_by", typeof(int));
        public static ColumnInfo UpdatedAt { get; } = ("updated_at", typeof(DateTime));
        public static ColumnInfo UpdatedBy { get; } = ("updated_by", typeof(int));
        public static ColumnInfo IssueAddress { get; } = ("issue_address", typeof(int));
    }
}