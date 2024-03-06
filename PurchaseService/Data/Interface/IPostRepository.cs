using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Data.Interface
{
    public interface IPostRepository
    {
        PostConfirmation CreatePost(Post post);
        Post GetPostById(Guid postId);
        void DeletePost(Guid postId);
        List<Post> GetPosts();
        bool SaveChanges();
        Post UpdatePost(Post post);
    }
}
