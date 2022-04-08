using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SomeUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Added",
                table: "ExpectedCost",
                newName: "Date");

            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ExpectedCost",
                newName: "Added");
        }
    }
}
