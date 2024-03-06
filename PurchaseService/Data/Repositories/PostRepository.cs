using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PurchaseService.Data.Interface;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using PurchaseService.Data.Interface;
using PurchaseService.Entities;
using PurchaseService.Entities.Confirmations;

namespace RatingService.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PostRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PostConfirmation CreatePost(Post post)
        {
            var createdEntity = context.Post.Add(post);
            context.SaveChanges();
            return mapper.Map<PostConfirmation>(createdEntity.Entity);
        }

        public Post GetPostById(Guid postId)
        {
            return context.Post.FirstOrDefault(e => e.postId == postId);
        }

        public void DeletePost(Guid postId)
        {
            var post = GetPostById(postId);
            if (post != null)
            {
                context.Post.Remove(post);
                context.SaveChanges();
            }
        }

        public List<Post> GetPosts()
        {
            return context.Post.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Post UpdatePost(Post post)
        {
            try
            {
                var existingPost = context.Post.FirstOrDefault(e => e.postId == post.postId);
                if (existingPost != null)
                {
                    existingPost.title = post.title;
                    existingPost.date = post.date;
                    existingPost.ownerId = post.ownerId;
                    existingPost.ownerUsername = post.ownerUsername;


                    context.SaveChanges();
                    return existingPost;
                }
                else
                {
                    throw new KeyNotFoundException($"Post with ID {post.postId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
