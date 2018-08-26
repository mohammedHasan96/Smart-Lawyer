using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLawyer.Models.Values
{
    public static class SystemValues
    {
        public static long LoginUser { get; set; }
        public static class MyColors
        {
            public static String Selected { get; set; } = "#7ed6df";
            public static String Default { get; set; } = "#feca57";
            public static String MouseOver { get; set; } = "#cea344";
        }
        public static class MasterSystemConstants
        {
            public static int PersonType { get; set; } = 19;
            public static int CourtType { get; set; } = 1;
            public static int CourtLocation { get; set; } = 2;
            public static int CommunicationType { get; set; } = 22;
            public static int NotificationType { get; set; } = 25;

        }
        public static class Communications
        {
            public static String Phone { get; set; } = "Phone Number";
            public static String Mobile { get; set; } = "Mobile Number";
            public static String Emial { get; set; } = "Email Address";
        }
    }
}
