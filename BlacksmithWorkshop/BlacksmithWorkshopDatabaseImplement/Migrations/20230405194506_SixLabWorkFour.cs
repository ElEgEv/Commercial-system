using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class SixLabWorkFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM [dbo].[Orders]");

			migrationBuilder.DropForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ImplementerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders",
                column: "ImplementerId",
                principalTable: "Implementers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ImplementerId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders",
                column: "ImplementerId",
                principalTable: "Implementers",
                principalColumn: "Id");
        }
    }
}
