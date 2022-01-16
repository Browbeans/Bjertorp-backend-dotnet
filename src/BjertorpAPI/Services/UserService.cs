using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BjertorpAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BjertorpAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(
          IOptions<DatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(
              userDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
              userDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(
              userDatabaseSettings.Value.UserCollectionName
            );
        }

        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<string> CreateUser(User newUser)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.password);
            var existingUser = await _userCollection.Find(x => x.email == newUser.email).FirstOrDefaultAsync();
            if (existingUser != null) return $"User with email: {newUser.email} already exist";
            newUser.password = hashedPassword;
            await _userCollection.InsertOneAsync(newUser);
            return $"User with email {newUser.email} has been created"; 
        }

        public async Task<string> DeleteUser(string id)
        {
            User user = await _userCollection.Find(x => x._id == id).FirstOrDefaultAsync();
            if (user == null) return "No user with provided id found";
            await _userCollection.DeleteOneAsync(x => x._id == id);
            return $"{user.email} has been deleted";
        }

        public async Task<string> Login(LoginModel user)
        {
            var existingUser = await GetUserByEmail(user.email);
            if (existingUser == null) return "Wrong password or email";
            if(!BCrypt.Net.BCrypt.Verify(user.password, existingUser.password)) return "wrong password or username";
            return $"{user.email} has logged in";
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _userCollection.Find(x => x.email == email).FirstOrDefaultAsync();
            return user; 
        }
    }
}
