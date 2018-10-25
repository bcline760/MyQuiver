using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyQuiver.Contracts;

namespace MyQuiver.Repository
{
    public interface IEventRepository : IRepository<ArcheryEvent>
    {
        /// <summary>
        /// Gets the events between start and end dates
        /// </summary>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task{System.Collections.Generic.List{MyQuiver.Model.Event}}"/>.</returns>
        /// <param name="start">Starting date of events</param>
        /// <param name="end">Ending dates of the events</param>
        Task<List<ArcheryEvent>> GetEventsBetween(DateTime? start, DateTime end);
    }
}
