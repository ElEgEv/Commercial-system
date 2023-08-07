using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class SixLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM [dbo].[Orders]");

			migrationBuilder.AddColumn<int>(
                name: "ImplementerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Implementers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementerFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ImplementerId",
                table: "Orders",
                column: "ImplementerId");

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

            migrationBuilder.DropTable(
                name: "Implementers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ImplementerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImplementerId",
                table: "Orders");
        }
    }
}
