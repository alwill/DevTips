using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMigration.Migrations
{
    public partial class SpecialInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialInstructions",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialInstructions",
                table: "Order");
        }
    }
}
