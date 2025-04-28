using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techofest_Team_Website.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Services",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Services",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
