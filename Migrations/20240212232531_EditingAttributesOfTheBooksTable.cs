using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHub.API.Migrations
{
    /// <inheritdoc />
    public partial class EditingAttributesOfTheBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Books",
                type: "text",
                nullable: true);
        }
    }
}
