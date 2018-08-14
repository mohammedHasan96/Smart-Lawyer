using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class NotificationTable
    {
        public static readonly String TableName = "notification";
        public static ColumnInfo NotId { get; } = ("not_id", typeof(long));
        public static ColumnInfo NotType { get; } = ("not_type", typeof(int));
        public static ColumnInfo NotCourtPlace { get; } = ("not_court_place", typeof(int));
        public static ColumnInfo InterviewNotification { get; } = ("Interview_notification", typeof(String));
        public static ColumnInfo NotLawyerId { get; } = ("not_Lawyer_id", typeof(long));
        public static ColumnInfo NotSubject { get; } = ("not_subject", typeof(String));
        public static ColumnInfo NotDate { get; } = ("not_date", typeof(DateTime));
        public static ColumnInfo NotNotiferId { get; } = ("not_notifer_id", typeof(int));
        public static ColumnInfo NotIssueId { get; } = ("not_issue_id", typeof(long));
        public static ColumnInfo NotPerIdFk { get; } = ("not_per_id_fk", typeof(int));
        public static ColumnInfo CreatedAt { get; } = ("created_at", typeof(DateTime));
        public static ColumnInfo CreatedBy { get; } = ("created_by", typeof(DateTime));
        public static ColumnInfo UpdatedAt { get; } = ("updated_at", typeof(DateTime));
        public static ColumnInfo UpdatedBy { get; } = ("updated_by", typeof(DateTime));
    }
}