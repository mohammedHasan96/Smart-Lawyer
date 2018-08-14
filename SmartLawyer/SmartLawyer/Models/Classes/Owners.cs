using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class OwnersModel
    {
        public int OwId { get; set; }
        public long OwPerFk { get; set; }
        public DateTime OwStartDate { get; set; }
        public int OwEndDate { get; set; }
        public int OwPropertyIdFk { get; set; }
    }
}