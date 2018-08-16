using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class SessionFileModel
    {
        public int SessionFieId { get; set; }
        public String Name { get; set; }
        public DateTime CratedAt { get; set; }
        public int SessionId { get; set; }
        public String SeFiNotic { get; set; }
        public String SeFiDocType { get; set; }
    }
}