using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Data.Interface
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
