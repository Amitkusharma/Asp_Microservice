using Framework.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class Repository : IRepository
    {
        private readonly IDatacontext _dbcontext;
        
        public Repository(IDatacontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> DeleteProduct(string _Id)
        {
            var deletedResult = await _dbcontext.Products.DeleteOneAsync(p=>p._id==_Id);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount>0;
        }

        public async Task<List<BuyerBid>> GetAllBidsOnProduct(string _productId)
        {
            return await _dbcontext.BidsCollection.Find(p=>p.ProductId == _productId).ToListAsync();
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _dbcontext.Products.Find(p => true).ToListAsync();

        }

        public async Task<Products> GetProducts(string _Id)
        {
            return await _dbcontext.Products.Find(p => p._id == _Id).FirstOrDefaultAsync();
        }

        public async Task<Products> InsertProducts(Products _product)
        {  
            await _dbcontext.Products.InsertOneAsync(_product);
            return _product;
           
        }


    }
}
