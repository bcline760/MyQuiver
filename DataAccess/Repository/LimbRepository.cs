using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using AutoMapper;
using MongoDB.Driver;
using MyQuiver.Contracts;
using MyQuiver.Model.Filters;
using MyQuiver.Repository;

namespace MyQuiver.Model.Repository
{
    internal class LimbRepository : MongoRepository, ILimbRepository
    {
        private IMongoCollection<LimbModel> m_collection = null;

        public LimbRepository(IMongoDatabase database) : base(database)
        {
            m_collection = Database.GetCollection<LimbModel>(GetCollectionName<LimbModel>());
        }

        public async Task Create(Limb newLimb)
        {
            if (newLimb == null)
                throw new ArgumentNullException(nameof(newLimb));

            var model = Mapper.Map<LimbModel>(newLimb);

            await m_collection.InsertOneAsync(model);
        }

        public async Task Delete(Guid id)
        {
            var filter = new LimbFilter
            {
                Id = id
            };

            var query = GetFilterQuery<LimbModel, LimbFilter>(filter);
            var results = await m_collection.Find(query).FirstOrDefaultAsync<LimbModel>();
            if (results != null)
                await m_collection.DeleteManyAsync(query);
        }

        public async Task<Limb> Get(Guid id)
        {
            var filter = new LimbFilter
            {
                Id = id
            };

            var query = GetFilterQuery<LimbModel, LimbFilter>(filter);
            var results = await m_collection.Find(query).FirstOrDefaultAsync<LimbModel>();

            return Mapper.Map<Limb>(results);
        }

        public async Task Update(Limb limb)
        {
            var model = Mapper.Map<LimbModel>(limb);
            var results = await m_collection.ReplaceOneAsync<LimbModel>(q => q.Id == limb.Id, model, new UpdateOptions { IsUpsert = false });

            if (!results.IsAcknowledged)
                throw new InvalidOperationException("The update was not acknowledged");
        }
    }
}
