using MongoDB.Driver;

using Framework.Models;

namespace BuyerBidService.Api.Data
{
    public interface IDatacontext
    {
        public IMongoCollection<BuyerBid> BidsCollection { get; }
        public IMongoCollection<Products> ProductsCollection { get; }
    }
}
