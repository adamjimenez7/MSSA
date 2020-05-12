using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public int? Privilege { get; set; }
    }
}
