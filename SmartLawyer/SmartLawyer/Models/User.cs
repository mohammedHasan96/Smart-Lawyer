using System;
using System.Collections.Generic;

namespace SmartLawyer.Models
{
    public class User
    {
        public int UserID { get; set; }
        public Person PersonData { set; get; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int UserType { get; set; }
        public bool UserState { get; set; }
        public List<int> UserGroups { get; set; }
    }
}
