using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class NotificationModel
    {
        public long NotId { get; set; }
        public int NotType { get; set; }
        public int NotCourtPlace { get; set; }
        public String InterviewNotification { get; set; }
        public long NotLawyerId { get; set; }
        public String NotSubject { get; set; }
        public DateTime NotDate { get; set; }
        public int NotNotiferId { get; set; }
        public long NotIssueId { get; set; }
        public int NotPerIdFk { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime UpdatedBy { get; set; }
    }
}