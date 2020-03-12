using System;
using System.Collections.Generic;

namespace DAMMIT.Models
{
    public partial class CustomerInfo
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public string Unit { get; set; }
    }
}
