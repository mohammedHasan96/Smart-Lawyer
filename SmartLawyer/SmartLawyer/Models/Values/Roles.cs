using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class RolesTable
    {
        public static readonly String TableName = "roles";
        public static ColumnInfo RoleId { get; } = ("role_id", typeof(int));
        public static ColumnInfo RoleName { get; } = ("role_name", typeof(String));
        public static ColumnInfo Description { get; } = ("description", typeof(String));
    }
}