using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class SingleTransactionDetails
    {
        [Key]
        public int LineId { get; set; }
        public int? Da5515Id { get; set; }
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
        public string LotNumber { get; set; }
        public int? Qtyissued { get; set; }
        public string ResIssued { get; set; }
        public int? Qtyreturned { get; set; }
        public string ResReturned { get; set; }
        public string Notes { get; set; }
    }
}
