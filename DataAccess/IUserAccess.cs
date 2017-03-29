using System;
using System.Collections.Generic;
using System.Text;
using MyQuiver.DataAccess.Model;
using MyQuiver.DataAccess.Filters;

namespace MyQuiver.DataAccess
{
    public interface IUserAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int CreateUser(User user);


        List<User> GetUsers(UserFilter filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int DeleteUser(int userId);
    }
}
