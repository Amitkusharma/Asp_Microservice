using MongoDB.Driver;

using Framework.Models;

namespace BuyerBidService.Api.Data
{
    public class DataContext :IDatacontext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        
        public IMongoCollection<BuyerBid> BidsCollection { get; }
        public IMongoCollection<Products> ProductsCollection { get; }
        public DataContext(IConfiguration _configuration)
        {
             _client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _database = _client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            BidsCollection = _database.GetCollection<BuyerBid>(_configuration.GetValue<string>("DatabaseSettings:CollectionNameBid"));
            ProductsCollection = _database.GetCollection<Products>(_configuration.GetValue<string>("DatabaseSettings:CollectionName"));

        }
        
       
    }
}
