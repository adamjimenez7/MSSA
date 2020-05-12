using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AIM.Models
{
    public partial class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public string Unit { get; set; }
    }
}
