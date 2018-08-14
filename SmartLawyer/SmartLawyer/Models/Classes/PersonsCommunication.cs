using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsCommunicationModel
    {
        public int CoId { get; set; }
        public int CoName { get; set; }
        public String CoValue { get; set; }
        public int CoType { get; set; }
        public long CoPeIdFk { get; set; }
    }
}