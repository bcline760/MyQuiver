﻿namespace MyQuiver.DataAccess
{
    public sealed class ArrowShaftFilter : ComponentFilter
    {
        public string ArrowMaterialType { get; set; }

        public double? ManufacturedShaftLength { get; set; }
    }
}
