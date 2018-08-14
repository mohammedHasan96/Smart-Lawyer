using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class PersonsIssueTable
    {
        public static readonly String TableName = "persons_issue";
        public static ColumnInfo PeIssuePeId { get; } = ("pe_issue_pe_id", typeof(int));
        public static ColumnInfo CdIssueIssueId { get; } = ("cd_issue_issue_id", typeof(int));
        public static ColumnInfo PeIssueRelationCfk { get; } = ("pe_issue_relation_cfk", typeof(int));
    }
}