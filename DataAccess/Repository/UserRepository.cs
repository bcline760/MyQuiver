using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

using AutoMapper;
using MyQuiver.Contracts;
using MyQuiver.Repository;
using MyQuiver.Model.Filters;

namespace MyQuiver.Model.Repository
{
    internal class UserRepository : MongoRepository, IUserRepository
    {
        private IMongoCollection<UserModel> m_collection = null;

        public UserRepository(IMongoDatabase database) : base(database)
        {
            m_collection = Database.GetCollection<UserModel>(GetCollectionName<UserModel>());
        }

        public async Task Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var model = Mapper.Map<UserModel>(user);
            await m_collection.InsertOneAsync(model);
        }

        public async Task Delete(Guid id)
        {
            UserFilter filter = new UserFilter
            {
                Id = id
            };

            var filterQuery = GetFilterQuery<UserModel, UserFilter>(filter);
            var result = await m_collection.DeleteManyAsync(filterQuery);
        }

        public async Task<User> Get(Guid id)
        {
            UserFilter filter = new UserFilter
            {
                Id = id
            };

            var filterQuery = GetFilterQuery<UserModel, UserFilter>(filter);

            var user = await m_collection.FindAsync<UserModel>(filterQuery, new FindOptions<UserModel, UserModel>
            {
                AllowPartialResults = false,
                CursorType = CursorType.NonTailable
            });

            return Mapper.Map<User>(user);
        }

        public async Task<User> GetByEmail(string emailAddress)
        {
            UserFilter filter = new UserFilter
            {
                PrimaryEmail = emailAddress
            };

            var filterQuery = GetFilterQuery<UserModel, UserFilter>(filter);
            var user = await m_collection.FindAsync<UserModel>(filterQuery, new FindOptions<UserModel, UserModel>
            {
                AllowPartialResults = true,
                CursorType = CursorType.NonTailable
            });

            return Mapper.Map<User>(user);
        }

        public async Task Update(User model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var entity = Mapper.Map<UserModel>(model);
            var results = await m_collection.ReplaceOneAsync<UserModel>(q => q.Id == model.Id, entity);
        }

        private async Task<List<UserModel>> FindUsersAsync(UserFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var filterQuery = GetFilterQuery<UserModel, UserFilter>(filter);
            var users = await m_collection.FindAsync(filterQuery);

            return users.ToList();
        }
    }
}
