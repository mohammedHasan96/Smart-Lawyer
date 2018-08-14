using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class AppealsSlanderModel
    {
        public int ApSlId { get; set; }
        public int ApSlType { get; set; }
        public String ApSlNumber { get; set; }
        public DateTime ApSlDate { get; set; }
        public String ApSlNotic { get; set; }
        public int ApSlIssueIdFk { get; set; }
    }
}