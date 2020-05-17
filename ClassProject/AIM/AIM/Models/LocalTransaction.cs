using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class LocalTransaction
    {
        [Key]
        public int Da5515Id { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public string DocNumber { get; set; }
        public string RecUnit { get; set; }
        [DataType(DataType.Date)]
        public DateTime RecDate { get; set; }
        public DateTime Tidate { get; set; }
        public string Notes { get; set; }
        public string Da5515copy { get; set; }
    }
}
