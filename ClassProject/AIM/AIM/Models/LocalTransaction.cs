using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIM.Models
{
    public partial class LocalTransaction
    {
        [Key]
        public int Da5515Id { get; set; }
        [Display(Name = "Issued By")]
        public int? UserId { get; set; }
        [Display(Name = "Issued To")]
        public int? CustomerId { get; set; }
        [Display(Name = "Document Number")]
        public string DocNumber { get; set; }
        [Display(Name = "Receiving Unit")]
        public string RecUnit { get; set; }
        [Display(Name = "Issued On")]
        [DataType(DataType.Date)]
        public DateTime RecDate { get; set; }
        [Display(Name = "Returned On")]
        public DateTime Tidate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "5515 Copy")]
        public string Da5515copy { get; set; }
    }
}
