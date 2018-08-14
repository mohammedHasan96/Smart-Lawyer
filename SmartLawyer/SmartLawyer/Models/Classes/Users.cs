using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class UsersModel
    {
        public long UPIdFk { get; set; }
        public String UEmail { get; set; }
        public String UPassword { get; set; }
        public String UUserName { get; set; }
        public int UIsActive { get; set; }
        public int UHasLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; }
    }
}