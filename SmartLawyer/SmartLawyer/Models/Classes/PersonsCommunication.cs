using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsCommunicationModel
    {
        public int CoId { get; set; }
        public String CoNameCfk { get; set; }
        public String CoValue { get; set; }
        public long CoPeIdFk { get; set; }
        public int CoIsMain { get; set; }
    }
}