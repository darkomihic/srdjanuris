namespace PurchaseService.DTOs.Post
{
    public class PostConfirmationDTO
    {
        public Guid postId { get; set; }
        public string title { get; set; }
        public DateOnly date { get; set; }
        public Guid ownerId { get; set; }
        public string ownerUsername { get; set; }
    }
}
