using System;
using System.Collections.Generic;

namespace MyQuiver.Contracts
{
    public class ArcheryEvent
    {
        public ArcheryEvent()
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the event start date.
        /// </summary>
        /// <value>The event start date.</value>
        public DateTime EventStartDate { get; set; }
        /// <summary>
        /// Gets or sets the event end date.
        /// </summary>
        /// <value>The event end date.</value>
        public DateTime EventEndDate { get; set; }

        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        /// <value>The address line.</value>
        public string AddressLine { get; set; }
        /// <summary>
        /// Gets or sets the second address line.
        /// </summary>
        /// <value>The second address line.</value>
        public string SecondAddressLine { get; set; }
        /// <summary>
        /// Gets or sets the third address line.
        /// </summary>
        /// <value>The third address line.</value>
        public string ThirdAddressLine { get; set; }

        /// <summary>
        /// Get or set the city of its 
        /// </summary>
        
        public string City { get; set; }

        /// <summary>
        /// Get or set the state or province of the governing body
        /// </summary>
        
        public string StateProvince { get; set; }
        
        public string PrimaryContact { get; set; }
        
        public string EventWebsite { get; set; }
        
        public bool MajorEvent { get; set; }
        
        public bool NationalTeamQualifier { get; set; }
        
        public bool OlympicQualifier { get; set; }
        
        public double? TotalPurse { get; set; }

        /// <summary>
        /// Get or set the governing body associated with this format
        /// </summary>
        
        public GoverningBodyPtr GoverningBody { get; set; }

        public IEnumerable<Distance> Distances { get; set; }
    }
}
