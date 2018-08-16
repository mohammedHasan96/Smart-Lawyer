using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class IssueModel
    {
        public long IssueDeIdFk { get; set; }
        public long IssueTypeCourtCfk { get; set; }
        public long IssueAddressCourtCfk { get; set; }
        public long IssueTypeCfk { get; set; }
        public String IssueNumberOfCourt { get; set; }
        public String IssueNumberCourtOpposite { get; set; }
        public int IssueStatus { get; set; }
        public DateTime IssueStartDate { get; set; }
        public DateTime IssueEndDate { get; set; }
        public String IssueSubjectLawsuit { get; set; }
        public long IssueNumberRelationIssue { get; set; }
        public int IssueTypeRelationIssueCfk { get; set; }
        public DateTime CreatedAt { get; set; }
        public String IssueOrederNumber { get; set; }
        public String IssueNoticLoseWin { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IssueAddress { get; set; }
    }
}