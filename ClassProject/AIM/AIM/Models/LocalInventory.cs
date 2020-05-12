using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class LocalInventory
    {
        [Key]
        public int AmmoId { get; set; }
        public string DocNumber { get; set; }
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
        public string LotNumber { get; set; }
        public int? InitialQty { get; set; }
        public int? CurrentQty { get; set; }
        public string Location { get; set; }
    }
}
