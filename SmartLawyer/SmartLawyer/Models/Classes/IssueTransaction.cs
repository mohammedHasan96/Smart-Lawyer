using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class IssueTransactionModel
    {
        public long TrId { get; set; }
        public long TrIssueIdFk { get; set; }
        public int TrAddressCourtCfk { get; set; }
        public int TrCourtTypeCfk { get; set; }
        public DateTime TrDateConversion { get; set; }
        public long TrSeIssueIdFk { get; set; }
    }
}