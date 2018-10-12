using System.Collections.Generic;

namespace MyQuiver.Model
{
    public class EventFormatModel
    {
        /// <summary>
        /// Get or set the primary identifier of the event format.
        /// </summary>
        public int EventFormatId { get; set; }

        /// <summary>
        /// Get or set the name of the event format
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set the number of distances for this event format
        /// </summary>
        public IEnumerable<EventFormatDistanceModel> Distances { get; set; }
    }
}
