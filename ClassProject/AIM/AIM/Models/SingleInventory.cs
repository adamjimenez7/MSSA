using System;
using System.Collections.Generic;

namespace DAMMIT.Models
{
    public partial class SingleInventory
    {
        public int Da3020id { get; set; }
        public int? UserId { get; set; }
        public int? Da5515id { get; set; }
        public string DocNumber { get; set; }
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
        public string LotNumber { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public string ActionTaken { get; set; }
        public int? Qtylost { get; set; }
        public int? Qtygained { get; set; }
        public int? Balance { get; set; }
    }
}
