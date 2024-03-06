using System.ComponentModel.DataAnnotations;


namespace PurchaseService.Entities
{
    public class Post
    {
        [Key] public Guid postId { get; set; }
        [Required] public string title { get; set; }
        [Required] public DateOnly date {  get; set; }
        [Required] public Guid ownerId { get; set; }
        [Required] public string ownerUsername { get; set; }

    }
}
