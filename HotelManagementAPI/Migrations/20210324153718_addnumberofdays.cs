using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementAPI.Migrations
{
    public partial class addnumberofdays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfdaysToBook",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfdaysToBook",
                table: "Customers");
        }
    }
}
