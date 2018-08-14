using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class UsersTable
    {
        public static readonly String TableName = "users_tb";
        public static ColumnInfo UPIdFk { get; } = ("u_p_id_fk", typeof(long));
        public static ColumnInfo UEmail { get; } = ("u_email", typeof(String));
        public static ColumnInfo UPassword { get; } = ("u_password", typeof(String));
        public static ColumnInfo UUserName { get; } = ("u_user_name", typeof(String));
        public static ColumnInfo UIsActive { get; } = ("u_is_active", typeof(int));
        public static ColumnInfo UHasLogin { get; } = ("u_has_login", typeof(int));
        public static ColumnInfo CreatedAt { get; } = ("created_at", typeof(DateTime));
        public static ColumnInfo CreatedBy { get; } = ("created_by", typeof(long));
        public static ColumnInfo UpdatedAt { get; } = ("updated_at", typeof(DateTime));
        public static ColumnInfo UpdatedBy { get; } = ("updated_by", typeof(long));
    }
}