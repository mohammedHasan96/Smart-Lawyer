using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class CodesModel : CheckableViewModelBase
    {
        public long CId { get; set; }
        public int CMasterId { get; set; }
        public virtual String CName { get; set; }
        public String CDesc { get; set; }

        public static implicit operator string(CodesModel cm) => cm.CName;
        public override string ToString()
        {
            return CName;
        }
    }
}