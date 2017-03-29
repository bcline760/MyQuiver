using System;
using System.Collections.Generic;
using System.Text;

namespace MyQuiver.DataAccess.Driver
{
    public interface IDataDriver<TModel>
    {
        /// <summary>
        /// Create a new record of a model in the data store
        /// </summary>
        /// <typeparam name="TReturn">The return type expected from operation</typeparam>
        /// <param name="newRecord">The new model record to insert</param>
        /// <returns>A value from the insert operation, usually the record's primary key</returns>
        int CreateRecord(TModel newRecord);

        /// <summary>
        /// Retrieve records from the data store
        /// </summary>
        /// <typeparam name="TFilter">The type of filter applied for searching</typeparam>
        /// <param name="filter">The filter parameters</param>
        /// <returns>A collection of records matching the filter parameters</returns>
        IEnumerable<TModel> RetrieveRecords<TFilter>(TFilter filter);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TFilter"></typeparam>
        /// <param name="record"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        int UpdateRecord<TFilter>(TModel record, TFilter filter);

        /// <summary>
        /// Delete records from the data store that match the filter
        /// </summary>
        /// <typeparam name="TFilter">The type of filter applied for searching</typeparam>
        /// <param name="filter">The filter parameters</param>
        /// <returns>Success or failure of the operation</returns>
        bool DeleteRecord<TFilter>(TFilter filter);
    }
}
