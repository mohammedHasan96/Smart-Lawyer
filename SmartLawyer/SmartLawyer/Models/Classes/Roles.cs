using System;
using System.Collections.Generic;

namespace SmartLawyer.Models.Classes
{
    public class RolesModel : CheckableViewModelBase
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public String Description { get; set; }

        public int GroleView { get; set; }
        public int GroleAdd { get; set; }
        public int GroleEdit { get; set; }
        public int GroleDelete { get; set; }
        public int GrolePrint { get; set; }
        public int GroleExport { get; set; }
        public String GroleOther { get; set; }


        public bool RoleSelected()
            => (GroleAdd + GroleEdit + GroleDelete + GroleView + GroleExport + GrolePrint) > 0 ? true : false;
    }
}