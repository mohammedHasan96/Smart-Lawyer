using System;
using System.Collections.Generic;

namespace SmartLawyer.Models.Classes
{
    public class RolesModel : CheckableViewModelBase
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public String Description { get; set; }
    }
}