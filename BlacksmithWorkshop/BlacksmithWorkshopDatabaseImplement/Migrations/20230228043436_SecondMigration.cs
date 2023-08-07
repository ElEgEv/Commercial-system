using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Manufactures_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ManufactureId",
                table: "Orders",
                column: "ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Manufactures_ManufactureId",
                table: "Orders",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Manufactures_ManufactureId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ManufactureId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Manufactures_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Manufactures",
                principalColumn: "Id");
        }
    }
}
