using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class ContractTable
    {
        public static readonly String TableName = "contract";
        public static ColumnInfo ConDeIdFk { get; } = ("con_de_id_fk", typeof(long));
        public static ColumnInfo ConSubject { get; } = ("con_subject", typeof(String));
        public static ColumnInfo ConDate { get; } = ("con _date", typeof(DateTime));
        public static ColumnInfo CoFinancialValue { get; } = ("co_financial_value", typeof(double));
        public static ColumnInfo CoCurrencyTypeCfk { get; } = ("co_currency_type_cfk", typeof(int));
        public static ColumnInfo ConCreatedAt { get; } = ("con_created_at", typeof(DateTime));
        public static ColumnInfo ConCreatedBy { get; } = ("con_created_by", typeof(DateTime));
        public static ColumnInfo ConUpdatedAt { get; } = ("con_updated_at", typeof(DateTime));
        public static ColumnInfo ConUpdatedBy { get; } = ("con_updated_by", typeof(DateTime));
    }
}