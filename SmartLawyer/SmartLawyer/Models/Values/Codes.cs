using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class CodesTable
    {
        public static readonly String TableName = "codes_tb";
        public static ColumnInfo CId { get; } = ("c_id", typeof(long));
        public static ColumnInfo CMasterId { get; } = ("c_master_id", typeof(int));
        public static ColumnInfo CName { get; } = ("c_name", typeof(String));
        public static ColumnInfo CDesc { get; } = ("c_desc", typeof(String));
    }
}