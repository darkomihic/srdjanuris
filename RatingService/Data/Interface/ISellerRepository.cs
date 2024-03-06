using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Data.Interface
{
    public interface ISellerRepository
    {
        SellerConfirmation CreateSeller(Seller seller);
        Seller GetSellerById(Guid sellerId);
        void DeleteSeller(Guid sellerId);
        List<Seller> GetSellers();
        bool SaveChanges();
        Seller UpdateSeller(Seller seller);
    }
}
