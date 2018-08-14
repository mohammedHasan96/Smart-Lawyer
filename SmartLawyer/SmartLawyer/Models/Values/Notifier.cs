using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class NotifierTable
    {
        public static readonly String TableName = "notifier";
        public static ColumnInfo NotifierId { get; } = ("notifier_id", typeof(int));
        public static ColumnInfo NotiferIdFk { get; } = ("notifer_id_fk", typeof(int));
    }
}