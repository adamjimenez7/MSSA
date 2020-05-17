using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIM.Models
{
    public partial class DodicLibrary
    {
        [Key]
        public string Dodic { get; set; }
        public string Nomenclature { get; set; }
    }
}
