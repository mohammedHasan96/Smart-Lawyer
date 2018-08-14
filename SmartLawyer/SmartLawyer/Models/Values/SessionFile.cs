using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class SessionFileTable
    {
        public static readonly String TableName = "session_file";
        public static ColumnInfo SessionFieId { get; } = ("session_fie_id", typeof(int));
        public static ColumnInfo Name { get; } = ("name", typeof(String));
        public static ColumnInfo CratedAt { get; } = ("crated_at", typeof(DateTime));
        public static ColumnInfo SessionId { get; } = ("session_id", typeof(int));
    }
}