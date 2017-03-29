using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace MyQuiver.DataAccess.Driver.Mongo
{
    public class MongoDriver<TModel> : IDataDriver<TModel>
    {
        private string m_connectUrl;
        private IMongoCollection<TModel> m_collection = null;

        public MongoDriver(string connectUrl, string database)
        {
            m_connectUrl = connectUrl;
            MongoClientSettings settings = new MongoClientSettings
            {
                ConnectionMode = ConnectionMode.Automatic,
                UseSsl = true,
                ApplicationName = database,
                Server = new MongoServerAddress(connectUrl)
            };

            MongoClient client = new MongoClient(settings);
            var db = client.GetDatabase(database);

            string collectionName = GetCollectionName();
            m_collection = db.GetCollection<TModel>(collectionName);
        }

        public int CreateRecord(TModel newRecord)
        {
            if (newRecord == null)
                throw new ArgumentNullException(nameof(newRecord));

            m_collection.InsertOne(newRecord);
            return Convert.ToInt32(m_collection.Count(new BsonDocument()));
        }

        public bool DeleteRecord<TFilter>(TFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            FilterDefinition<TModel> query = GetFilterQuery(filter);
            DeleteResult result = m_collection.DeleteMany(query);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public IEnumerable<TModel> RetrieveRecords<TFilter>(TFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));
            FilterDefinition<TModel> query = GetFilterQuery(filter);

            return m_collection.Find<TModel>(query).ToList();
        }

        public int UpdateRecord<TFilter>(TModel record, TFilter filter)
        {
            Type modelType = typeof(TModel);
            List<UpdateDefinition<TModel>> updateFields = new List<UpdateDefinition<TModel>>();
            var modelProperties = modelType.GetProperties();

            var updateBuilder = Builders<TModel>.Update;
            foreach (var property in modelProperties)
            {
                var propertyValue = property.GetValue(record);
                var update = updateBuilder.Set(property.Name, propertyValue);
                updateFields.Add(update);
            }

            FilterDefinition<TModel> query = GetFilterQuery(filter);
            var updateQuery = updateBuilder.Combine(updateFields);
            var result = m_collection.UpdateMany(query, updateQuery);

            return result.IsAcknowledged && result.IsModifiedCountAvailable ? Convert.ToInt32(result.ModifiedCount) : -1;
        }

        private static string GetCollectionName()
        {
            Type modelType = typeof(TModel);
            string modelName = modelType.Name;
            string collectionName = string.Empty;
            char endingCharacter = modelName[modelName.Length - 1];

            //Be smart about English
            if (char.ToLowerInvariant(endingCharacter) == 'y')
            {
                char nextChar = modelName[modelName.Length - 2];
                char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                if (vowels.Any(v => v == nextChar))
                    collectionName = string.Concat(modelName, 's'); //bays, toys, keys
                else
                    collectionName = string.Concat(modelName.Substring(0, modelName.Length - 2), "ies"); //histories, flies, countries, etc.
            }
            else if (char.ToLowerInvariant(endingCharacter) == 'o') //Gonna have the odd case here...pianoes
            {
                collectionName = string.Concat(modelName, "es");
            }
            else
                collectionName = string.Concat(modelName, 's'); //Bows, Arrows

            return collectionName;
        }

        private static FilterDefinition<TModel> GetFilterQuery<TFilter>(TFilter filter)
        {
            Type filterType = typeof(TFilter);
            var properties = filterType.GetProperties();

            var builder = Builders<TModel>.Filter;
            List<FilterDefinition<TModel>> filters = new List<FilterDefinition<TModel>>();

            foreach (var property in properties)
            {
                object propertyValue = property.GetValue(filter);
                if (propertyValue == null)
                    continue;

                if (property.PropertyType.IsInstanceOfType(typeof(List<>)))
                {
                    Type listType = property.PropertyType.GetGenericArguments()[0];

                    //TODO: Figure this out somehow..
                    //builder.In(property.Name, propertyValue);
                }
                else
                {
                    var filterParameter = builder.Eq(property.Name, propertyValue);
                    filters.Add(filterParameter);
                }
            }
            var query = builder.And(filters);
            return query;
        }
    }
}
