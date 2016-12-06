using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KazenService.Models
{
    [CollectionDataContract(Name = "kazen", Namespace = "")]
    public class Kazen: List<KaasBeknopt>
    {
    }
}