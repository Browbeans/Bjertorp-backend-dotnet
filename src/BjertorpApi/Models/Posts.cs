using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BjertorpAPI.Models
{
  public class Posts 
  { 
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
    public int __v { get; set; }
  }
}