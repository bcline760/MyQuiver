using System;
namespace MyQuiver.Model.Filters
{
    internal class LimbFilter : BaseFilter
    {
        public string Length { get; set; }

        public string Material { get; set; }

        /// <summary>
        /// Get or set the draw weight as set by the manufacturer
        /// </summary>
        public int? DrawWeight { get; set; }
    }
}
