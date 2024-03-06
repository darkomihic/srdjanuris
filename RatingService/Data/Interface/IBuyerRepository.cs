using RatingService.Entities;

namespace RatingService.Data.Interface
{
    public interface IBuyerRepository
    {
        Buyer CreateBuyer(Buyer buyer);
        Buyer GetBuyerById(Guid buyerId);
        void DeleteBuyer(Guid buyerId);
        List<Buyer> GetBuyers();
        bool SaveChanges();
        Buyer UpdateBuyer(Buyer buyer);
    }
}
