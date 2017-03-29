using System;
using System.Collections.Generic;

using MongoDB.Driver;

using MyQuiver.DataAccess.Model;
using MyQuiver.DataAccess.Filters;

namespace MyQuiver.DataAccess
{
    public class UserAccess : Access, IUserAccess
    {
        private IMongoCollection<User> m_userCollection = null;
        public UserAccess(string connectUrl, string database) : base(connectUrl, database)
        {
            string collectionName = GetCollectionName<User>();
            m_userCollection = Database.GetCollection<User>(collectionName);
        }

        public int CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            m_userCollection.InsertOne(user);

            return user.UserId; //This may not work
        }

        public int DeleteUser(int userId)
        {
            UserFilter filter = new UserFilter
            {
                UserId = userId
            };

            var filterQuery = GetFilterQuery<User, UserFilter>(filter);
            var result = m_userCollection.DeleteMany(filterQuery);

            return result.IsAcknowledged ? Convert.ToInt32(result.DeletedCount) : -1;
        }

        public List<User> GetUsers(UserFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var filterQuery = GetFilterQuery<User, UserFilter>(filter);
            var users = m_userCollection.Find(filterQuery);

            return users.ToList();
        }

        public int UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            UserFilter filter = new UserFilter
            {
                UserId = user.UserId
            };

            var filterQuery = GetFilterQuery<User, UserFilter>(filter);
            UpdateDefinition<User> updateQuery = GetUpdateDefinition<User>(user);

            var result = m_userCollection.UpdateMany(filterQuery, updateQuery);
            return result.IsAcknowledged && result.IsModifiedCountAvailable ? Convert.ToInt32(result.ModifiedCount) : -1;
        }
    }
}
