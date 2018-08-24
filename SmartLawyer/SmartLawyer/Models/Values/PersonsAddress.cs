using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class PersonsAddressTable
    {
        public static readonly String TableName = "persons_address";
        public static ColumnInfo PeAdId { get; } = ("pe_ad_id", typeof(int));
        public static ColumnInfo PeAdCity { get; } = ("pe_ad_city", typeof(String));
        public static ColumnInfo PeAdStreetName { get; } = ("pe_ad_street_name", typeof(String));
        public static ColumnInfo PeAdPerIdFk { get; } = ("pe_ad_per_id_fk", typeof(long));
        public static ColumnInfo AdType { get; } = ("ad_type", typeof(int));
    }
}