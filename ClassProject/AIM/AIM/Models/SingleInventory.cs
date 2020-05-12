using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class SingleInventory
    {
        [Key]
        public int Da3020Id { get; set; }
        public int? UserId { get; set; }
        public int? Da5515id { get; set; }
        public string DocNumber { get; set; }
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
        public string LotNumber { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string ActionTaken { get; set; }
        public int? Qtylost { get; set; }
        public int? Qtygained { get; set; }
        public int? Balance { get; set; }
    }
}
