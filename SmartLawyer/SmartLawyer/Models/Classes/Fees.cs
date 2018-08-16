using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class FeesModel
    {
        public int FeId { get; set; }
        public String FeValue { get; set; }
        public String FeDeIdFk { get; set; }
        public int FeFileIdFk { get; set; }
        public String FeCurrencyTypeCfk { get; set; }
        public String FeNoticIdFk { get; set; }
    }
}