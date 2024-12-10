
#Weather Forecast API with MongoDB in .NET

This repository contains a basic weather forecast API built using MongoDB and .NET. The primary focus is to utilize the BaseRepository for performing various CRUD operations, along with text search functionality in MongoDB.

The API is ready to run for testing, but note that the Dockerfile is not updated. Feel free to reuse the BaseRepository as required.

#Features
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
Steps to Run Locally
Update the appsettings.json file with your database configuration:

json
Copy code
"DatabaseSettings": {
  "ConnectionString": "mongodb://localhost:27017/", // Replace with your connection string
  "DatabaseName": "weather-forecast" // Replace with your database name
}
Run the application:

bash
Copy code
dotnet run --project MongoNet
Feel free to explore and expand this repository as needed. 🎉
