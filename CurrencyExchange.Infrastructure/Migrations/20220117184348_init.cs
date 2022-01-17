using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exchange_rate",
                columns: table => new
                {
                    ExchangeRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EUR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GBP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RUB = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rate", x => x.ExchangeRateId);
                });

            migrationBuilder.InsertData(
                table: "exchange_rate",
                columns: new[] { "ExchangeRateId", "Date", "EUR", "GBP", "RUB", "USD" },
                values: new object[] { -3, new DateTime(2022, 1, 14, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3638), 3.35m, 3.19m, 0.312m, 3.40m });

            migrationBuilder.InsertData(
                table: "exchange_rate",
                columns: new[] { "ExchangeRateId", "Date", "EUR", "GBP", "RUB", "USD" },
                values: new object[] { -2, new DateTime(2022, 1, 15, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3633), 3.1m, 3.39m, 0.512m, 3.70m });

            migrationBuilder.InsertData(
                table: "exchange_rate",
                columns: new[] { "ExchangeRateId", "Date", "EUR", "GBP", "RUB", "USD" },
                values: new object[] { -1, new DateTime(2022, 1, 16, 22, 43, 48, 16, DateTimeKind.Local).AddTicks(3600), 3.5m, 3.9m, 0.12m, 3.0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exchange_rate");
        }
    }
}
