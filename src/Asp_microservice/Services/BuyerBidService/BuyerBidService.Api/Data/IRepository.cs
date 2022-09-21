
using Framework.Models;
using System.Threading.Tasks;

namespace BuyerBidService.Api.Data
{
    public interface IRepository
    {
        public Task<List<BuyerBid>> GetAllBids();
        public Task<bool> AddBids(BuyerBid _Bids);
        public Task<bool> UpdateBids( string _ProductId,BuyerBid _Bids);

        public Products GetProductDtl(string productId);

        public BuyerBid GetbidDtl(string productId, string EmailId);

    }
}
