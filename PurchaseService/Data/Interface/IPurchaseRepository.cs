using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Data.Interface
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
