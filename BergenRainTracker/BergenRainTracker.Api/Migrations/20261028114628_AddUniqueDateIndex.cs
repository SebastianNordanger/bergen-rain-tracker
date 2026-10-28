using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BergenRainTracker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueDateIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DailyRains_Date",
                table: "DailyRains",
                column: "Date",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyRains_Date",
                table: "DailyRains");
        }
    }
}
