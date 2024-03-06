using RatingService.Entities;

namespace RatingService.Data.Interface
{
    public interface PurchaseRepository
    {
        Purchase CreatePurchase(Purchase purchase);
        Purchase GetPurchaseById(Guid purchaseId);
        void DeletePurchase(Guid purchaseId);
        List<Purchase> GetPurchases();
        bool SaveChanges();
        Purchase UpdatePurchase(Purchase purchase);
    }
}
