using Framework.Models;
using MongoDB.Driver;


namespace Product.API.Data
{
    public interface IDatacontext
    {
        public IMongoCollection<Products> Products { get; }
        public IMongoCollection<BuyerBid> BidsCollection { get; }
    }
}
