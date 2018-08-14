using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class DebtModel
    {
        public int DeDebtFk { get; set; }
        public int DebtValue { get; set; }
        public int CepCourtPlaceCfk { get; set; }
        public String GuarantorIdCfk { get; set; }
        public int WitnesseFirstId { get; set; }
        public int WitnesseSecondeId { get; set; }
        public int DebtNoticFk { get; set; }
        public DateTime DebtDate { get; set; }
        public int DeDebtorFk { get; set; }
        public long RelatedIssueIdFk { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime UpdatedBy { get; set; }
    }
}