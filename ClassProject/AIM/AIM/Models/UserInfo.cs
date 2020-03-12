using System;
using System.Collections.Generic;

namespace DAMMIT.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public int? Privilege { get; set; }
    }
}
