using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewsletterCheckbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox1",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox2",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox3",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox4",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox5",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterCheckbox6",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox1",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox2",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox3",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox4",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox5",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsletterCheckbox6",
                table: "Subscribers");
        }
    }
}
