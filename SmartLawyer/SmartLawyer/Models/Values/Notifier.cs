using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class NotifierTable
    {
        public static readonly String TableName = "notifier";
        public static ColumnInfo NotrPIdFk { get; } = ("notr_p_id_fk", typeof(int));
        public static ColumnInfo NotrNotIdFk { get; } = ("notr_not_id_fk", typeof(int));
    }
}