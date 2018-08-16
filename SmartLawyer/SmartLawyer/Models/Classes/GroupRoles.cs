using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class GroupRolesModel
    {
        public int GrolrRoleIdFk { get; set; }
        public int GrolrGIdFk { get; set; }
        public int GroleView { get; set; }
        public int GroleAdd { get; set; }
        public int GroleEdit { get; set; }
        public int GroleDelete { get; set; }
        public int GrolePrint { get; set; }
        public int GroleExport { get; set; }
        public String GroleOther { get; set; }
    }
}