using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BjertorpAPI.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int __v { get; set; }
    }
}
