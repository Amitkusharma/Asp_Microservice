using Framework.Models;
using MongoDB.Driver;


namespace Product.API.Data
{
    public class DataContext :IDatacontext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        
        public IMongoCollection<Products> Products { get; }
        public IMongoCollection<BuyerBid> BidsCollection { get; }

        public DataContext(IConfiguration _configuration)
        {
             _client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _database = _client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
             Products = _database.GetCollection<Products>(_configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            BidsCollection = _database.GetCollection<BuyerBid>(_configuration.GetValue<string>("DatabaseSettings:CollectionNameBid"));
        }
        
       
    }
}
