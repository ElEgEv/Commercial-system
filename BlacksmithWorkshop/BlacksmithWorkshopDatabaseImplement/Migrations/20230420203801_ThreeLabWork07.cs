using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class ThreeLabWork07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM [dbo].[Clients]");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
