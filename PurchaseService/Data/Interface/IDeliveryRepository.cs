using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Data.Interface
{
    public interface IDeliveryRepository
    {
        DeliveryConfirmation CreateDelivery(Delivery delivery);
        Delivery GetDeliveryById(Guid deliveryId);
        void DeleteDelivery(Guid deliveryId);
        List<Delivery> GetDeliverys();
        bool SaveChanges();
        Delivery UpdateDelivery(Delivery delivery);
    }
}
