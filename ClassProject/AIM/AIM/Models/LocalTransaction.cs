using System;
using System.Collections.Generic;

namespace DAMMIT.Models
{
    public partial class LocalTransaction
    {
        public int Da5515id { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public string DocNumber { get; set; }
        public string RecUnit { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? Tidate { get; set; }
        public string Notes { get; set; }
        public string Da5515copy { get; set; }
    }
}
