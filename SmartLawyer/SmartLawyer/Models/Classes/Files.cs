using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class FilesModel
    {
        public int FiId { get; set; }
        public String FiName { get; set; }
        public String FiPath { get; set; }
        public int FiDeIdFk { get; set; }
        public int FiTypeCfk { get; set; }
        public String FlNote { get; set; }
    }
}