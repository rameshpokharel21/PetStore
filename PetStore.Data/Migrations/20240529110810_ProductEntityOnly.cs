using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductEntityOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "KittenFood",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LengthInches",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WeightPounds",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "KittenFood",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LengthInches",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeightPounds",
                table: "Products",
                type: "REAL",
                nullable: true);
        }
    }
}
