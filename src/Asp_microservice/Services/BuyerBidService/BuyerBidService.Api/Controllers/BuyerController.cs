using BuyerBidService.Api.Data;
using Framework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuyerBidService.Api.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<BuyerController> _logger;
        public BuyerController(IRepository repository, ILogger<BuyerController> logger)
        {
            _repository = repository;
            _logger = logger;

        }
        [HttpGet]
        [Route("GatAllBids")]
        [ProducesResponseType(typeof(IEnumerable<BuyerBid>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BuyerBid>>> GetAllBids()
        {
            try
            {
                var product = await _repository.GetAllBids();
                return Ok(product);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Unable to fetch Bid details");
            }

        }

        [HttpPost]
        [Route("Place-Bid")]

        public ActionResult PlaceBids([FromBody] BuyerBid _bid)
        {
            try
            {
                var productinfo = _repository.GetProductDtl(_bid.ProductId);
                var bidinfo = _repository.GetbidDtl(_bid.ProductId, _bid.Email);
                if (bidinfo == null)
                {
                    if (productinfo != null && productinfo.BidEndDT.Value.Date <= DateTime.Now.Date)
                    {

                        _repository.AddBids(_bid);
                        return Ok();
                    }
                    else
                    {
                        throw new Exception("Bid can not be place after the Bid End Date.");
                    }
                }
                else
                {
                    throw new Exception("Can not place multiple Bids on same product.");
                }


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [Route("update-Bid")]
        public ActionResult UpdateBid(string _ProductId, [FromBody] BuyerBid _bid)
        {
            try
            {
                var productinfo = _repository.GetProductDtl(_ProductId);
                if (productinfo != null && productinfo.BidEndDT.Value.Date <= DateTime.Now.Date)
                {
                    _repository.UpdateBids(_ProductId, _bid);
                    return Ok();
                }
                else
                {
                    throw new Exception("Can not Update Bids After Bid End Date.");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}