using Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Product.API.Data;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/V1/Seller/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/<productsController>
        [HttpGet]
        [Route ("GatAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<Products>),(int)HttpStatusCode.OK)]
        public async Task <ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            try
            {
                var product = await _repository.GetAllProducts();
                return Ok(product);

            }
            catch (Exception ex)
            {             
                    _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Unable to fetch product details" );
            }
                
         }

        // GET api/<productsController>/5
        [HttpGet()]
        [Route("ProductId", Name ="GetProductDetails")]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task <ActionResult< Products>> Get(string ProductId)
        {
            try
            {
                var product = await _repository.GetProducts(ProductId);
                return Ok(product);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Unable to fetch product details");
            }
        }

        // POST api/<productsController>
        [HttpPost]
       [Route("Add-Product")]
       
        public ActionResult AddProduct([FromBody]Products _Pro)
        {
            try
            { 
                if (_Pro.BidEndDT.Value.Date >= DateTime.Now.Date)
                {
                    _repository.InsertProducts(_Pro);
                }
                else
                {
                    throw (new Exception("Product End date can not be a past date."));
                }
                return Ok();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<productsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<productsController>/5
        [HttpDelete("ProductId", Name ="DeleteProduct")]
        public ActionResult<bool> DeleteProduct(string  ProductId)
        {
            try
            {
                var productinfo = _repository.GetProducts(ProductId);

                if (productinfo != null && productinfo.Result.BidEndDT.Value.Date < DateTime.Now.Date)
                {
                    _repository.DeleteProduct(ProductId);
                }
                else
                {
                    throw new Exception("Product can not be deleted after Bid date.");
                }
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
        [Route("Show-Bids")]
        public async Task<ActionResult<ProductBids>> GetAllBids(string ProductId)
        {
            try
            {
                var BidsOnProduct = new ProductBids();
                BidsOnProduct._Product = await _repository.GetProducts(ProductId);
                BidsOnProduct._Bids = await _repository.GetAllBidsOnProduct(ProductId);
                return BidsOnProduct;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Unable to fetch product details");
            }

        }
    }
}
