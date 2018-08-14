using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class NoticsModel
    {
        public long NoticsId { get; set; }
        public int NoticDeIdFk { get; set; }
        public String NoticDeContent { get; set; }
        public DateTime Notic { get; set; }
    }
}