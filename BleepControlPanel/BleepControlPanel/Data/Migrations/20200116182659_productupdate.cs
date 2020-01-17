using Microsoft.EntityFrameworkCore.Migrations;

namespace BleepControlPanel.Data.Migrations
{
    public partial class productupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "barcode",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcode",
                table: "Product");
        }
    }
}
