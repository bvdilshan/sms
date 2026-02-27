using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentMgmt.Core.Entities;

namespace StudentMgmt.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Student> Students => _database.GetCollection<Student>("Students");
}