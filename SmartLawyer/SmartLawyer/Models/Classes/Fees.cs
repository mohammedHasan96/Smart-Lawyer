using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class FeesModel
    {
        public int FeId { get; set; }
        public String FeValue { get; set; }
        public int FeDeIdFk { get; set; }
        public int FeFileIdFk { get; set; }
        public long FeCurrencyTypeCfk { get; set; }
        public long FeNoticIdFk { get; set; }
    }
}