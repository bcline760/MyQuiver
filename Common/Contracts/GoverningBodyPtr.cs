using System;
namespace MyQuiver.Contracts
{
    public sealed class GoverningBodyPtr : QuiverEntity<GoverningBodyPtr>
    {
        public GoverningBodyPtr()
        {
        }

        /// <summary>
        /// Get or set the name of the governing body
        /// </summary>
        public string BodyName { get; set; }
    }
}
