using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIM.Models
{
    public partial class LocalInventory
    {
        [Key]
        public int AmmoId { get; set; }
        [Display(Name = "Document Number")] 
        public string DocNumber { get; set; }
        [Display(Name = "DODIC")]
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }
        [Display(Name = "Initial Quantity")]
        public int? InitialQty { get; set; }
        [Display(Name = "Current Quantity")]
        public int? CurrentQty { get; set; }
        public string Location { get; set; }
    }
}
