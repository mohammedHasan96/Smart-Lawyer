using System;
using System.Collections.Generic;

namespace SmartLawyer.Models.Classes
{
    public class PersonsModel : CheckableViewModelBase
    {
        public long PeId { get; set; }
        public String PeName { get; set; }
        public int PeType { get; set; }
        public long PeAddress { get; set; }
        public int PeIdentity { get; set; }
        public String MobileNo { get; set; }
        public String PhoneNo { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
    }
}