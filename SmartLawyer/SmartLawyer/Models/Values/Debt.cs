using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class DebtTable
    {
        public static readonly String TableName = "debt";
        public static ColumnInfo DeDebtFk { get; } = ("de_debt_fk", typeof(int));
        public static ColumnInfo DebtValue { get; } = ("debt_value", typeof(int));
        public static ColumnInfo CepCourtPlaceCfk { get; } = ("cep_court_place_cfk", typeof(int));
        public static ColumnInfo GuarantorIdCfk { get; } = ("guarantor_id_cfk", typeof(String));
        public static ColumnInfo WitnesseFirstId { get; } = ("witnesse_first_id", typeof(int));
        public static ColumnInfo WitnesseSecondeId { get; } = ("witnesse_seconde_id", typeof(int));
        public static ColumnInfo DebtNoticFk { get; } = ("debt_notic_fk", typeof(int));
        public static ColumnInfo DebtDate { get; } = ("debt_date", typeof(DateTime));
        public static ColumnInfo DeDebtorFk { get; } = ("de_debtor_fk", typeof(int));
        public static ColumnInfo RelatedIssueIdFk { get; } = ("related_issue_id_fk", typeof(long));
        public static ColumnInfo CreatedAt { get; } = ("created_at", typeof(DateTime));
        public static ColumnInfo DebDateTo { get; } = ("deb_date_to", typeof(DateTime));
        public static ColumnInfo DebDateFrom { get; } = ("deb_date_from", typeof(DateTime));
        public static ColumnInfo UpdatedBy { get; } = ("updated_by", typeof(long));
        public static ColumnInfo UpdatedAt { get; } = ("updated_at", typeof(DateTime));
        public static ColumnInfo CeatedBy { get; } = ("ceated_by", typeof(long));
    }
}