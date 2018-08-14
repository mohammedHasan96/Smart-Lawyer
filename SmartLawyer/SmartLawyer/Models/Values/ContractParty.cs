using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Values
{
    public static class ContractPartyTable
    {
        public static readonly String TableName = "contract_party";
        public static ColumnInfo ConPaId { get; } = ("con_pa_id", typeof(long));
        public static ColumnInfo ConPaContractIdFk { get; } = ("con_pa_contract _id_fk", typeof(long));
        public static ColumnInfo ConPaPerFk { get; } = ("con_pa_per_fk", typeof(long));
        public static ColumnInfo ConPaType { get; } = ("con_pa_type", typeof(long));
    }
}