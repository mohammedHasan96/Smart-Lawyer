using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsModel : ChecableViewModelBase
    {
        public long PeId { get; set; }
        public String PeName { get; set; }
        public int PeType { get; set; }
        public long PeAddress { get; set; }
        public int PeIdentity { get; set; }
    }
}