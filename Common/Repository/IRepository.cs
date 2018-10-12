using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiver.Repository
{
    /// <summary>
    /// Defines a particular repository
    /// </summary>
    /// <typeparam name="TModel">The model for this particular repository</typeparam>
    /// <typeparam name="TKey">The data type of the model's ID</typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task Create(TModel model);

        /// <summary>
        /// Get a single instance of a model from the repository
        /// </summary>
        /// <param name="id">The primary identifier of the model</param>
        /// <returns>The model matching ID or null if not found</returns>
        Task<TModel> Get(Guid id);

        /// <summary>
        /// Update an existing repository record
        /// </summary>
        /// <param name="model">The model to update</param>
        Task Update(TModel model);

        /// <summary>
        /// Delete a record from the repository
        /// </summary>
        /// <param name="id">The ID of the repository record</param>
        Task Delete(Guid id);
    }
}
