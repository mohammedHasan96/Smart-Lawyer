using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class NoticsTable
    {
        public static readonly String TableName = "notics";
        public static ColumnInfo NoticsId { get; } = ("notics_id", typeof(long));
        public static ColumnInfo NoticDeIdFk { get; } = ("notic_de_id_fk", typeof(int));
        public static ColumnInfo NoticDeContent { get; } = ("notic_de_content", typeof(String));
        public static ColumnInfo Notic { get; } = ("notic", typeof(DateTime));
    }
}