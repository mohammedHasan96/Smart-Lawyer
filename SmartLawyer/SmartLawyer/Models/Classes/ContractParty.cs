using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class ContractPartyModel
    {
        public long ConPaId { get; set; }
        public long ConPaContractIdFk { get; set; }
        public long ConPaPerFk { get; set; }
        public long ConPaType { get; set; }
    }
}