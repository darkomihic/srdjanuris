using Microsoft.EntityFrameworkCore;
using RatingService.Entities;
using System;

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
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Buyer>()
                .HasData(new
                {
                    buyerId = Guid.Parse("2c1c1ebf-d97b-4e00-a923-1ac5501de37e"),
                    username = "Buyer 1",
                    email = "buyer1@gmail.com"
                });
            builder.Entity<Purchase>()
                .HasData(new
                {
                    purchaseId = Guid.Parse("c731cb1a-c9de-42cc-81c7-ef0f9e19f852"),
                    date = DateOnly.Parse("2015-10-21"),
                    price = 100
                });
            builder.Entity<Rating>()
                .HasData(new
                {
                    ratingId = Guid.Parse("f3e51e2d-1c1f-4e98-98fa-b099e90ce0a2"),
                    date = DateOnly.Parse("2015-10-21"),
                    grade = 5,
                    comment = "Comment1",
                    title = "Title1"
                });
            builder.Entity<Seller>()
                .HasData(new
                {
                    sellerId = Guid.Parse("34a88e70-ed89-410a-ab1e-a9f35a9de5a2"),
                    username = "Seller1",
                    email = "seller1@gmail.com"
                });




        }

    }
}
