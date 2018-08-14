using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class ContractModel
    {
        public long ConDeIdFk { get; set; }
        public String ConSubject { get; set; }
        public DateTime ConDate { get; set; }
        public double CoFinancialValue { get; set; }
        public int CoCurrencyTypeCfk { get; set; }
        public DateTime ConCreatedAt { get; set; }
        public DateTime ConCreatedBy { get; set; }
        public DateTime ConUpdatedAt { get; set; }
        public DateTime ConUpdatedBy { get; set; }
    }
}