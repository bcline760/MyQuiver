using MyQuiver.Common;
using MyQuiver.DataAccess.Model;
using System;
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
        ValueResponse<int> SaveUser(User user);

        /// <summary>
        /// Load a user by the identifier
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user object found or null if not found</returns>
        ValueResponse<User> LoadUser(int userId);

        /// <summary>
        /// Authenticate a user with their provider and its token
        /// </summary>
        /// <param name="token">The token given by the authentication provider</param>
        /// <param name="provider">The provider used for authentication</param>
        /// <returns>The user object found or null if not found</returns>
        ValueResponse<User> AuthenticateUser(string token, AuthenicationProvider provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Response detailing the result of the operation</returns>
        Response DeleteUser(int userId);
    }
}