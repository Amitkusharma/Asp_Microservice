using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Event
{
    public class BidEvent:IntegrationBaseEvent
    {

        
        public string? _id { get; set; }
        public string ProductId { get; set; }
        public int BidAmount { get; set; }

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        public string message { get; set; }
    }
}
