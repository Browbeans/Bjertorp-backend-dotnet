namespace BjertorpAPI.Models
{
public class DatabaseSettings
{
  public string ConnectionString { get; set; }
  public string DatabaseName { get; set; }
  public string PostsCollectionName { get; set; }
  public string UserCollectionName { get; set; }

}
}