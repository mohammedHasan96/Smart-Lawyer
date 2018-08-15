using System;
using System.Collections.Generic;

namespace SmartLawyer.Models.Classes
{
    public class GroupsModel: CheckableViewModelBase
    {
        public int GId { get; set; }
        public String GName { get; set; }
        public String GDescription { get; set; }
    }
}