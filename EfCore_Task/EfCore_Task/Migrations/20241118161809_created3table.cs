using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore_Task.Migrations
{
    /// <inheritdoc />
    public partial class created3table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_products_ProductId",
                table: "baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_baskets_users_UserId",
                table: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_baskets_ProductId",
                table: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_baskets_UserId",
                table: "baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_baskets_ProductId",
                table: "baskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_baskets_UserId",
                table: "baskets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_products_ProductId",
                table: "baskets",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_users_UserId",
                table: "baskets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
