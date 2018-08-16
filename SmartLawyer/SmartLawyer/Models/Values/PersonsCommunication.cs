using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class PersonsCommunicationTable
    {
        public static readonly String TableName = "persons_communication";
        public static ColumnInfo CoId { get; } = ("co_id", typeof(int));
        public static ColumnInfo CoNameCfk { get; } = ("co_name_cfk", typeof(int));
        public static ColumnInfo CoValue { get; } = ("co_value", typeof(String));
        public static ColumnInfo CoPeIdFk { get; } = ("co_pe_id_fk", typeof(long));
        public static ColumnInfo CoIsMain { get; } = ("co_is_main", typeof(int));
    }
}