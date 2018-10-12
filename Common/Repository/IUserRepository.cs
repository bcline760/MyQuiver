using System.Collections.Generic;
using System.Threading.Tasks;

using MyQuiver.Contracts;
using MyQuiver.Repository;

namespace MyQuiver.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Get a user by e-mail
        /// </summary>
        /// <param name="emailAddress">The e-mail address of the user</param>
        /// <returns>The user matching the e-mail address or null if not found</returns>
        Task<User> GetByEmail(string emailAddress);
    }
}
