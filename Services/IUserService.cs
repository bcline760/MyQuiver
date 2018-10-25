using MyQuiver.Contracts;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyQuiver.Services
{
    /// <summary>
    /// Service for 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user if not found or updates an existing one
        /// </summary>
        /// <param name="user">The user to save to the data store</param>
        /// <returns>Response detailing the result of the operation</returns>
        Task<ValueResponse<int>> SaveUser(User user);

        /// <summary>
        /// Load a user by the identifier
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user object found or null if not found</returns>
        Task<ValueResponse<User>> LoadUser(Guid userId);

        /// <summary>
        /// Load a user by their e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address of user</param>
        /// <returns>The user object found or null if not found</returns>
        Task<ValueResponse<User>> LoadUser(string email);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Response detailing the result of the operation</returns>
        Task<Response> DeleteUser(Guid userId);
    }
}