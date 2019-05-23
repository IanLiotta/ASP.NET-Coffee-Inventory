using Microsoft.EntityFrameworkCore.Migrations;

namespace SelectListTest.Migrations
{
    public partial class AddRoastToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoastId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_RoastId",
                table: "Inventory",
                column: "RoastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Roasts_RoastId",
                table: "Inventory",
                column: "RoastId",
                principalTable: "Roasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Roasts_RoastId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_RoastId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "RoastId",
                table: "Inventory");
        }
    }
}
