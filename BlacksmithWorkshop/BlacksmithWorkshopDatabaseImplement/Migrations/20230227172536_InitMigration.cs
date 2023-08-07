using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkPieceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPieces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateImplement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Manufactures_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Manufactures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ManufactureWorkPieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureId = table.Column<int>(type: "int", nullable: false),
                    WorkPieceId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureWorkPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufactureWorkPieces_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufactureWorkPieces_WorkPieces_WorkPieceId",
                        column: x => x.WorkPieceId,
                        principalTable: "WorkPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureWorkPieces_ManufactureId",
                table: "ManufactureWorkPieces",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureWorkPieces_WorkPieceId",
                table: "ManufactureWorkPieces",
                column: "WorkPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufactureWorkPieces");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WorkPieces");

            migrationBuilder.DropTable(
                name: "Manufactures");
        }
    }
}
