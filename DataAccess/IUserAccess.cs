using System;
using System.Collections.Generic;
using System.Text;
using MyQuiver.DataAccess.Model;

namespace MyQuiver.DataAccess
{
    interface IUserAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int CreateUser(User user);


        List<User> GetUsers();

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
