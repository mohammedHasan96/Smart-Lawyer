using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class DealTable
    {
        public static readonly String TableName = "deal_tb";
        public static ColumnInfo DeId { get; } = ("de_id", typeof(long));
        public static ColumnInfo DeSequentNumber { get; } = ("de_sequent_number", typeof(long));
        public static ColumnInfo DeMonth { get; } = ("de_month", typeof(long));
        public static ColumnInfo DeYear { get; } = ("de_year", typeof(long));
        public static ColumnInfo DeType { get; } = ("de_type", typeof(int));
        public static ColumnInfo DeInsertDate { get; } = ("de_insert_date", typeof(DateTime));
        public static ColumnInfo DeInsertUser { get; } = ("de_insert_user", typeof(int));
    }
}