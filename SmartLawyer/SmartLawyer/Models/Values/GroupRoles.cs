using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class GroupRolesTable
    {
        public static readonly String TableName = "group_roles";
        public static ColumnInfo GrolrRoleIdFk { get; } = ("grolr_role_id_fk", typeof(int));
        public static ColumnInfo GrolrGIdFk { get; } = ("grolr_g_id_fk", typeof(int));
        public static ColumnInfo GroleView { get; } = ("grole_view", typeof(int));
        public static ColumnInfo GroleAdd { get; } = ("grole_add", typeof(int));
        public static ColumnInfo GroleEdit { get; } = ("grole_edit", typeof(int));
        public static ColumnInfo GroleDelete { get; } = ("grole_delete", typeof(int));
        public static ColumnInfo GrolePrint { get; } = ("grole_print", typeof(int));
        public static ColumnInfo GroleExport { get; } = ("grole_export", typeof(int));
        public static ColumnInfo GroleOther { get; } = ("grole_other", typeof(String));
    }
}