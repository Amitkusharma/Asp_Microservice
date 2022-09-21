
using Framework.Models;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public interface IRepository
    {
        public  Task< List<Products> > GetAllProducts();
        public Task<Products> GetProducts( string _Id);

        public   Task<Products>  InsertProducts(Products _product);
        public Task<bool> DeleteProduct(string _Id);

        public Task<List<BuyerBid>> GetAllBidsOnProduct(string _productId);

    }
}
