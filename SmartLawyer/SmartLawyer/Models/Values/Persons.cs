using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class PersonsTable
    {
        public static readonly String TableName = "persons";
        public static ColumnInfo PeId { get; } = ("pe_id", typeof(long));
        public static ColumnInfo PeName { get; } = ("pe_name", typeof(String));
        public static ColumnInfo PeType { get; } = ("pe_type", typeof(int));
        public static ColumnInfo PeAddress { get; } = ("pe_address", typeof(long));
        public static ColumnInfo PeIdentity { get; } = ("pe_identity", typeof(int));
    }
}