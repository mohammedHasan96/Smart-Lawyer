using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PropertyModel
    {
        public int PrId { get; set; }
        public int PrTypeCfk { get; set; }
        public String PrNotic { get; set; }
        public long PrCoIdFk { get; set; }
    }
}