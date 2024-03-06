using Microsoft.EntityFrameworkCore;
using PurchaseService.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RatingService.Data
{
    public class Context : DbContext
    {
        private readonly IConfiguration configuration;

        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Buyer>()
                .HasData(new
                {
                    buyerId = Guid.Parse("0c4429d7-205e-4f20-918a-8ffd4052f355"),
                    username = "Buyer1",
                    email = "buyer1@gmail.com"
                });
            builder.Entity<Post>()
                .HasData(new
                {
                    postId = Guid.Parse("2fb69455-e054-462c-bc05-7b22aba2514f"),
                    title = "Post1Title",
                    date = DateOnly.Parse("2015-10-21"),
                    ownerId = Guid.Parse("6bfdfeff-6655-46dd-8bcb-14dea3fadb51"),
                    ownerUsername = "OwnerUsername"
                });
            builder.Entity<Delivery>()
                .HasData(new
                {
                    deliveryId = Guid.Parse("2317fb31-0bbc-4e46-a800-16ee6dda0fc6"),
                    price = 3,

                });
            builder.Entity<Purchase>()
            .HasData(new
            {
                purchaseId = Guid.Parse("e009aa98-d0fa-4d92-8c05-de089de7e413"),
                date = DateOnly.Parse("2015-10-21"),
                price = 100,
                deliveryId = Guid.Parse("2317fb31-0bbc-4e46-a800-16ee6dda0fc6"),
                buyerId = Guid.Parse("0c4429d7-205e-4f20-918a-8ffd4052f355"),
                postId = Guid.Parse("2fb69455-e054-462c-bc05-7b22aba2514f")

            });
            ;




        }

    }
}
