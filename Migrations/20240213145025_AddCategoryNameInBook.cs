using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryNameInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Books",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Books");
        }
    }
}
