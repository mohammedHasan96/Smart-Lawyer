using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class DealModel
    {
        public long DeId { get; set; }
        public long DeSequentNumber { get; set; }
        public long DeMonth { get; set; }
        public long DeYear { get; set; }
        public int DeType { get; set; }
        public DateTime DeInsertDate { get; set; }
        public int DeInsertUser { get; set; }
    }
}