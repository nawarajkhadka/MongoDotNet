This repo contains a basic weather forecast api utilising mongodb in .net. The main idea is to utilise the baserepository for performing different crud operations along with text search in mongodb. Feel free to reuse the baserepository as required. The dockerfile 
is not updated but the api is runnable to test.

Features
1. CRUD Operations
Create: Add new documents to a collection.
Read: Retrieve documents by ID, filter expressions, or get all documents.
Update: Replace existing documents by ID.
Delete: Remove documents by ID or clear an entire collection.
2. Query Support
Custom Filtering: Use Expression<Func<TEntity, bool>> for dynamic queries.
Pagination: Fetch top documents with a specified limit.
Queryable Interface: Provides IQueryable access to MongoDB collections for LINQ queries.
3. Text and Regex Search
Perform text-based and regex-based searches using MongoDB's powerful search capabilities.
4. Pipeline Support
Build and execute custom MongoDB aggregation pipelines.
Requirements
.NET 6.0 or later
MongoDB.Driver
MongoDB.Bson

Steps to run it locally:
1. Replace appsettings.json section
   "DatabaseSettings": {
  "ConnectionString": "mongodb://localhost:27017/", //your connection string
  "DatabaseName": "weather-forecast" //your database name/ 
}
2. Run the app MongoNet


