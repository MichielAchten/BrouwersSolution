using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KazenClasses
{
    [CollectionDataContract(Name = "kazen", Namespace = "")]
    public class Kazen: List<KaasBeknopt>
    {
    }
}
