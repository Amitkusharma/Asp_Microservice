using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public  class ProductBids
    {
        public  Products _Product { get; set; }
        public  List<BuyerBid> _Bids { get; set; }
    }
}
