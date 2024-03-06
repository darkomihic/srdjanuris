using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Data.Interface
{
    public interface IBuyerRepository
    {
        BuyerConfirmation CreateBuyer(Buyer buyer);
        Buyer GetBuyerById(Guid buyerId);
        void DeleteBuyer(Guid buyerId);
        List<Buyer> GetBuyers();
        bool SaveChanges();
        Buyer UpdateBuyer(Buyer buyer);
    }
}
