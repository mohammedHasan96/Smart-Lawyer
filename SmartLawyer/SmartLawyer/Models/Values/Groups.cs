using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class GroupsTable
    {
        public static readonly String TableName = "groups";
        public static ColumnInfo GId { get; } = ("g_id", typeof(int));
        public static ColumnInfo GName { get; } = ("g_name", typeof(int));
        public static ColumnInfo GDescription { get; } = ("g_description", typeof(int));
    }
}