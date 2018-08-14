using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class WitnesseesModel
    {
        public long WitId { get; set; }
        public int WiType { get; set; }
        public int DeIdFk { get; set; }
        public int WiPerFk { get; set; }
    }
}