using Microsoft.EntityFrameworkCore.Migrations;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Migrations
{
    public partial class productModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RotationId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RotationId",
                table: "Products",
                column: "RotationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RotationId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RotationId",
                table: "Products",
                column: "RotationId",
                unique: true);
        }
    }
}
