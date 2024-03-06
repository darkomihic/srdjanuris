using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatingService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.buyerId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    purchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.purchaseId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ratingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    purchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ratingId);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    sellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.sellerId);
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "buyerId", "email", "username" },
                values: new object[] { new Guid("2c1c1ebf-d97b-4e00-a923-1ac5501de37e"), "buyer1@gmail.com", "Buyer 1" });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "purchaseId", "date", "price" },
                values: new object[] { new Guid("c731cb1a-c9de-42cc-81c7-ef0f9e19f852"), new DateOnly(2015, 10, 21), 100 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "ratingId", "buyerId", "comment", "date", "grade", "purchaseId", "sellerId", "title" },
                values: new object[] { new Guid("f3e51e2d-1c1f-4e98-98fa-b099e90ce0a2"), new Guid("2c1c1ebf-d97b-4e00-a923-1ac5501de37e"), "Comment1", new DateOnly(2015, 10, 21), 5, new Guid("c731cb1a-c9de-42cc-81c7-ef0f9e19f852"), new Guid("34a88e70-ed89-410a-ab1e-a9f35a9de5a2"), "Title1" });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "sellerId", "email", "username" },
                values: new object[] { new Guid("34a88e70-ed89-410a-ab1e-a9f35a9de5a2"), "seller1@gmail.com", "Seller1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
