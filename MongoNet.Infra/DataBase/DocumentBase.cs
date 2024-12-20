﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoNet.Contracts.Interfaces;

namespace MongoNet.Infra.DataBase
{
    public class DocumentBase : IDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
