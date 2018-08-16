using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class IssueSessionModel
    {
        public int SeId { get; set; }
        public long SeIssueIdFk { get; set; }
        public long SeFileId { get; set; }
        public String SeNotic { get; set; }
        public String SeNextAction { get; set; }
        public int IssueSeNumberSe { get; set; }
        public String IssueDateNextSe { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsTransaction { get; set; }
    }
}