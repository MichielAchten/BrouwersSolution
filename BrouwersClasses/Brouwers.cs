﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BrouwersClasses
{
    [CollectionDataContract(Name = "brouwers", Namespace = "")]
    public class Brouwers : List<BrouwerBeknopt>
    {

    }
}
