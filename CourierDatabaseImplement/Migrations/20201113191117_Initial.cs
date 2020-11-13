using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourierDatabaseImplement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryActs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CourierFIO = table.Column<string>(nullable: true),
                    DeliveryType = table.Column<int>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryActs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryActs");
        }
    }
}
