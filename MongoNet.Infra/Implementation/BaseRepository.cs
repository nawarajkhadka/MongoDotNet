﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoNet.Contracts.Interfaces;
using MongoNet.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MongoNet.Infra.Implementation
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IDocument
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbCollection { get; set; }
        protected string dbcollectionName;

        public BaseRepository(IMongoDbContext context, string collectionName)
        {
            Context = context;
            DbCollection = Context.GetCollection<TEntity>((collectionName));
            dbcollectionName = collectionName;
        }

        public async Task Create(TEntity document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + "object is null");
            }
            await DbCollection.InsertOneAsync(document);
        }

        public async Task<bool> Delete(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TEntity>.Filter.Eq(document => document.Id, objectId);
            var result = await DbCollection.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAllDocuments()
        {
            var result = await DbCollection.DeleteManyAsync(Builders<TEntity>.Filter.Empty);
            return result.IsAcknowledged;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await DbCollection.Find(filterExpression).SingleAsync();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await DbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetTop(int limit)
        {
            FindOptions<TEntity> options = new FindOptions<TEntity> { Limit = limit };
            var top = await DbCollection.FindAsync(Builders<TEntity>.Filter.Empty, options);
            return await top.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FilterBy(Expression<Func<TEntity, bool>> filterExpression)
        {
            var filteredList = await DbCollection.FindAsync(filterExpression);
            return await filteredList.ToListAsync();
        }


        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TProjected>> projectionExpression)
        {
            return DbCollection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public Task<TEntity> Replace(string id, TEntity newDocument)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, objectId);
            return DbCollection.FindOneAndReplaceAsync(filter, newDocument);
        }

        public async Task<TEntity> GetById(string id)
        {

            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq(document => document.Id, objectId);
            return await DbCollection.Find(filter).SingleAsync();
        }
        public IQueryable<TEntity> GetAsQuerable()
        {
            return DbCollection.AsQueryable<TEntity>();
        }
        public IEnumerable<TEntity> GetTextSearchResults(string index, string searchField, string searchText)
        {

            PipelineDefinition<TEntity, BsonDocument> pipeline = new BsonDocument[]
            {
                new BsonDocument("$search",
                    new BsonDocument
                    {
                        { "index", index },
                        { "text",
                            new BsonDocument{
                                { "path", searchField },
                                { "query", searchText }
                            }
                        }
                    })
            };
            return GetResultsFromPipelineDefinition(pipeline);
        }

        public IEnumerable<TEntity> GetRegexSearchResults(string searchField, string regex, string index)
        {
            PipelineDefinition<TEntity, BsonDocument> pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument
                {
                    { searchField, new BsonDocument("$regex", regex) }
                })
            };
            return GetResultsFromPipelineDefinition(pipeline);
        }

        private List<TEntity> GetResultsFromPipelineDefinition(PipelineDefinition<TEntity, BsonDocument> pipelineDefinition)
        {
            var pipeLineSearchResults = DbCollection.Aggregate(pipelineDefinition).ToList();
            var mappedSearchResults = pipeLineSearchResults.Select(t => BsonSerializer.Deserialize<TEntity>(t)).ToList();
            return mappedSearchResults;
        }

    }
}
