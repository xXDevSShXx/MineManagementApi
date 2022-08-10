using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MineManagementApi.Migrations
{
    public partial class FixedaTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Spead",
                table: "Locations",
                newName: "Speed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Locations",
                newName: "Spead");
        }
    }
}
