using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class UserGroupTable
    {
        public static readonly String TableName = "user_group";
        public static ColumnInfo UserId { get; } = ("user_id", typeof(int));
        public static ColumnInfo GroupId { get; } = ("group_id", typeof(int));
    }
}