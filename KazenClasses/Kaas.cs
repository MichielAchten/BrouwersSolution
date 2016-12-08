using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KazenClasses
{
    [DataContract(Name = "kaas", Namespace = "")]
    public class Kaas
    {
        [DataMember(Name = "id", Order = 1)]
        public int ID { get; set; }
        [DataMember(Name = "naam", Order = 2)]
        public string Naam { get; set; }
        [DataMember(Name = "Type", Order = 3)]
        public string Type { get; set; }
        [DataMember(Name = "smaak", Order = 4)]
        public string Smaak { get; set; }
    }
}
