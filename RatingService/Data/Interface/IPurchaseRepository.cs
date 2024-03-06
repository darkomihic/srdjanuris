using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Data.Interface
{
    public interface IPurchaseRepository
    {
        PurchaseConfirmation CreatePurchase(Purchase purchase);
        Purchase GetPurchaseById(Guid purchaseId);
        void DeletePurchase(Guid purchaseId);
        List<Purchase> GetPurchases();
        bool SaveChanges();
        Purchase UpdatePurchase(Purchase purchase);
    }
}
