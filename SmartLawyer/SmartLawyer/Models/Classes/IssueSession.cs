using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class IssueSessionModel
    {
        public int SeId { get; set; }
        public long SeIssueIdFk { get; set; }
        public long SeFileId { get; set; }
        public DateTime SeDate { get; set; }
        public String SeNotic { get; set; }
        public String SeNextAction { get; set; }
        public int IssueSeNumberSe { get; set; }
        public DateTime IssueDateNextSe { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime UpdatedBy { get; set; }
    }
}