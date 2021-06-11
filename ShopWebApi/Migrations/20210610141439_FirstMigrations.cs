using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApi.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reserved_orders",
                columns: table => new
                {
                    id_order = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserved_orders", x => x.id_order);
                });

            migrationBuilder.CreateTable(
                name: "storage_warehouse",
                columns: table => new
                {
                    article = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductInformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage_warehouse", x => x.article);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reserved_orders");

            migrationBuilder.DropTable(
                name: "storage_warehouse");
        }
    }
}
