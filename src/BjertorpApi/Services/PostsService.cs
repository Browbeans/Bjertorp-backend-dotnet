using System.Collections.Generic;
using System.Threading.Tasks;
using BjertorpAPI.Models; 
using Microsoft.Extensions.Options; 
using MongoDB.Driver; 

namespace BjertorpAPI.Services
{
  public class PostsService 
  { 
    private readonly IMongoCollection<Posts> _postsCollection; 

    public PostsService(
      IOptions<DatabaseSettings> postDatabaseSettings)
    {
      var mongoClient = new MongoClient (
        postDatabaseSettings.Value.ConnectionString);

      var mongoDatabase = mongoClient.GetDatabase(
        postDatabaseSettings.Value.DatabaseName);
      
      _postsCollection = mongoDatabase.GetCollection<Posts>(
        postDatabaseSettings.Value.PostsCollectionName
      );
    }   

    public async Task<List<Posts>> GetAsync() => 
      await _postsCollection.Find(_ => true).ToListAsync();
  }
}