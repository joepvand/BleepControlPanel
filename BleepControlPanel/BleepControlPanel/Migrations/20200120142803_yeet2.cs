using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BleepControlPanel.Migrations
{
    public partial class yeet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoriet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoriet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoriet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoriet_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favoriet_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoriet_ProductId",
                table: "Favoriet",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoriet_UserId",
                table: "Favoriet",
                column: "UserId");
        }
    }
}
