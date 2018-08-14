using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class GroupRolesTable
    {
        public static readonly String TableName = "group_roles";
        public static ColumnInfo RoleId { get; } = ("role_id", typeof(int));
        public static ColumnInfo GroupId { get; } = ("group_id", typeof(int));
    }
}