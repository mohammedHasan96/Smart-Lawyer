using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class NotificationModel
    {
        public long NotId { get; set; }
        public int NotType { get; set; }
        public String NotNumberInCourt { get; set; }
        public int NotCourtPlace { get; set; }
        public String NotCounterNotification { get; set; }
        public long NotLawyerId { get; set; }
        public String NotSubject { get; set; }
        public DateTime NotDate { get; set; }
        public long NotIssueId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdatedBy { get; set; }
    }
}