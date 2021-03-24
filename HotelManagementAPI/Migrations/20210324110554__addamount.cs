using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementAPI.Migrations
{
    public partial class _addamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "Roomtypes",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Roomtypes");
        }
    }
}
