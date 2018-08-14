using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class FilesModel
    {
        public int FiId { get; set; }
        public int FiName { get; set; }
        public int FiPath { get; set; }
        public int FiDeIdFk { get; set; }
        public int FiTypeCfk { get; set; }
    }
}