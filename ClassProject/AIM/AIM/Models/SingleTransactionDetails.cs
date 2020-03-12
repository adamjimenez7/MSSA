using System;
using System.Collections.Generic;

namespace DAMMIT.Models
{
    public partial class SingleTransactionDetails
    {
        public int LineId { get; set; }
        public int? Da5515id { get; set; }
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
