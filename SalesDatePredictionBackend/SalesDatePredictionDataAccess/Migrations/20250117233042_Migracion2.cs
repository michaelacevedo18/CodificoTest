using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesDatePredictionDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipCountry",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Shippers",
                newName: "ShipName");

            migrationBuilder.AddColumn<string>(
                name: "ShipAddress",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipCity",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipCountry",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipAddress",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "ShipCity",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "ShipCountry",
                table: "Shippers");

            migrationBuilder.RenameColumn(
                name: "ShipName",
                table: "Shippers",
                newName: "CompanyName");

            migrationBuilder.AddColumn<string>(
                name: "ShipAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipCity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipCountry",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
