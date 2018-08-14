using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsIssueModel
    {
        public int PeIssuePeId { get; set; }
        public int CdIssueIssueId { get; set; }
        public int PeIssueRelationCfk { get; set; }
    }
}