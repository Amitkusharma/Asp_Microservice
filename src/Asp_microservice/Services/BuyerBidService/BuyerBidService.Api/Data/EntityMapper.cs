using AutoMapper;
using EventBus.Messages.Event;
using Framework.Models;

namespace BuyerBidService.Api.Data
{
    public class EntityMapper: Profile
    {

        public EntityMapper()
        {
            CreateMap<BuyerBid ,BidEvent>().ReverseMap();   
        }
    }
}
