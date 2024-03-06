using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities.Confirmations
{
    public class PostConfirmation
    {
        public Guid postId { get; set; }
        public string title { get; set; }
        public DateOnly date { get; set; }
        public Guid ownerId { get; set; }
        public string ownerUsername { get; set; }
    }
}
