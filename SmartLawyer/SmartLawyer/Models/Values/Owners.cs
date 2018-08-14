using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class OwnersTable
    {
        public static readonly String TableName = "owners";
        public static ColumnInfo OwId { get; } = ("ow_id", typeof(int));
        public static ColumnInfo OwPerFk { get; } = ("ow_per_fk", typeof(long));
        public static ColumnInfo OwStartDate { get; } = ("ow_start_date", typeof(DateTime));
        public static ColumnInfo OwEndDate { get; } = ("ow_end_date", typeof(int));
        public static ColumnInfo OwPropertyIdFk { get; } = ("ow_property_id_fk", typeof(int));
    }
}