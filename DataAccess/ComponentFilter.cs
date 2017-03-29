﻿using MyQuiver.DataAccess.Model;
using System.Collections.Generic;

namespace MyQuiver.DataAccess
{
    public class ComponentFilter : Filter
    {
        /// <summary>
        /// Get or set list of manufacturers for filtering
        /// </summary>
        public List<Manufacturer> Manufacturers { get; set; }
    }
}
