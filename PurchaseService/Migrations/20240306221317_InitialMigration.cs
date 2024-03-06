using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseService.Migrations
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
                name: "Delivery",
                columns: table => new
                {
                    deliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.deliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    ownerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ownerUsername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    purchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    deliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.purchaseId);
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "buyerId", "email", "username" },
                values: new object[] { new Guid("0c4429d7-205e-4f20-918a-8ffd4052f355"), "buyer1@gmail.com", "Buyer1" });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "deliveryId", "price" },
                values: new object[] { new Guid("2317fb31-0bbc-4e46-a800-16ee6dda0fc6"), 3 });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "postId", "date", "ownerId", "ownerUsername", "title" },
                values: new object[] { new Guid("2fb69455-e054-462c-bc05-7b22aba2514f"), new DateOnly(2015, 10, 21), new Guid("6bfdfeff-6655-46dd-8bcb-14dea3fadb51"), "OwnerUsername", "Post1Title" });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "purchaseId", "buyerId", "date", "deliveryId", "postId", "price" },
                values: new object[] { new Guid("e009aa98-d0fa-4d92-8c05-de089de7e413"), new Guid("0c4429d7-205e-4f20-918a-8ffd4052f355"), new DateOnly(2015, 10, 21), new Guid("2317fb31-0bbc-4e46-a800-16ee6dda0fc6"), new Guid("2fb69455-e054-462c-bc05-7b22aba2514f"), 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
