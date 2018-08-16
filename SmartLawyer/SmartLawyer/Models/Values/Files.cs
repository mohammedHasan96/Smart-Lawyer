using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class FilesTable
    {
        public static readonly String TableName = "files";
        public static ColumnInfo FiId { get; } = ("fi_id", typeof(int));
        public static ColumnInfo FiName { get; } = ("fi_name", typeof(String));
        public static ColumnInfo FiPath { get; } = ("fi_path", typeof(String));
        public static ColumnInfo FiDeIdFk { get; } = ("fi_de_id_fk", typeof(int));
        public static ColumnInfo FiTypeCfk { get; } = ("fi_type_cfk", typeof(int));
    }
}