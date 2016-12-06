using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KazenService.Models
{
    [DataContract(Name = "kaas", Namespace = "")]
    public class KaasBeknopt
    {
        [DataMember(Name = "id", Order = 1)]
        public int ID { get; set; }
        [DataMember(Name = "naam", Order = 2)]
        public string Naam { get; set; }
        [DataMember(Name = "detail", Order = 3)]
        public string Detail { get; set; }
    }
}