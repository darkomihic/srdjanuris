using RatingService.Entities;

namespace RatingService.Data.Interface
{
    public interface ISellerRepository
    {
        Seller CreateSeller(Seller seller);
        Seller GetSellerById(Guid sellerId);
        void DeleteSeller(Guid sellerId);
        List<Seller> GetSellers();
        bool SaveChanges();
        Seller UpdateSeller(Seller seller);
    }
}
