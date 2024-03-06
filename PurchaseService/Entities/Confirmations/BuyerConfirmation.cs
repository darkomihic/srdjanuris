using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities.Confirmations
{
    public class BuyerConfirmation
    {
        public Guid buyerId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
