using Microsoft.EntityFrameworkCore.Migrations;

namespace BleepControlPanel.Data.Migrations
{
    public partial class huts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "prijs",
                table: "Product",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "prijs",
                table: "Product",
                type: "float",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
