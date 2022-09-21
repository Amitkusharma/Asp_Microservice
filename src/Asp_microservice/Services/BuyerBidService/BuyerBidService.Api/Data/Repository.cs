using MongoDB.Driver;
using System.Threading.Tasks;
using Framework.Models;

namespace BuyerBidService.Api.Data
{
    public class Repository : IRepository
    {
        private readonly IDatacontext _dbcontext;
        
        public Repository(IDatacontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> AddBids(BuyerBid _Bids)
        {
            try
            {
               
                        await _dbcontext.BidsCollection.InsertOneAsync(_Bids);
                        return true;
                   
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateBids(string _ProductId,BuyerBid _Bids)
        {
            try
            {
                 await _dbcontext.BidsCollection.ReplaceOneAsync(filter: p => p.ProductId == _ProductId, replacement: _Bids);
                
                return true;
            }
            catch (Exception)
            {

                return false; 
            }
        }
        

        public async Task<List<BuyerBid>> GetAllBids()
        {
            try
            {
                return await _dbcontext.BidsCollection.Find(p => true).ToListAsync();
            }
            catch (Exception )
            {

                throw;
            }
        }

        public Products GetProductDtl( string productId)
        {
            try
            {
                return _dbcontext.ProductsCollection.Find(p => p._id == productId).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BuyerBid GetbidDtl(string productId , string EmailId)
        {
            try
            {
                return _dbcontext.BidsCollection.Find(p => p.ProductId == productId && p.Email==EmailId).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
