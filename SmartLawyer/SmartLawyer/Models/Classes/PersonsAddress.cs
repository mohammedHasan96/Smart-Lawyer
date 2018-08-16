using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsAddressModel
    {
        public int PeAdId { get; set; }
        public String PeAdCity { get; set; }
        public String PeAdStreetName { get; set; }
        public int PeAdPerIdFk { get; set; }
    }
}