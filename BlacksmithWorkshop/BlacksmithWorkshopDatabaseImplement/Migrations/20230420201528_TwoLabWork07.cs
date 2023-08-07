using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class TwoLabWork07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM [dbo].[Orders]");
			migrationBuilder.Sql("DELETE FROM [dbo].[Messages]");

			migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ClientId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
