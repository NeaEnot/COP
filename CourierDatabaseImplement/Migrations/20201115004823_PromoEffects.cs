using Microsoft.EntityFrameworkCore.Migrations;

namespace CourierDatabaseImplement.Migrations
{
    public partial class PromoEffects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromoEffects",
                table: "DeliveryActs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromoEffects",
                table: "DeliveryActs");
        }
    }
}
