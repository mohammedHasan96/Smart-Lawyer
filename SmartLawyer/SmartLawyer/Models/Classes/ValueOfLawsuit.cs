using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class ValueOfLawsuitModel
    {
        public int VowId { get; set; }
        public double VowValueLawsuit { get; set; }
        public long VowCurrency { get; set; }
        public long VowIssueIdFk { get; set; }
    }
}