using Microsoft.EntityFrameworkCore.Migrations;

namespace api.eProduct.Migrations
{
    public partial class removecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
