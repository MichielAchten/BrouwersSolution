using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KazenService.Models
{
    [DataContract(Name = "kaas", Namespace = "")]
    public class Kaas
    {
        [DataMember(Name = "id", Order = 1)]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataMember(Name = "naam", Order = 2)]
        public string Naam { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataMember(Name = "type", Order = 3)]
        public string Type { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataMember(Name = "smaak", Order = 4)]
        public string Smaak { get; set; }

    }
}