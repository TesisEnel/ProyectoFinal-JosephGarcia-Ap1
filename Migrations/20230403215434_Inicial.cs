using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    TotalGastado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "PagosTennis",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TenniId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosTennis", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Tennis",
                columns: table => new
                {
                    TenniId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tennis", x => x.TenniId);
                });

            migrationBuilder.CreateTable(
                name: "DetallePagosTennis",
                columns: table => new
                {
                    DetallesPagosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorPago = table.Column<double>(type: "REAL", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePagosTennis", x => x.DetallesPagosId);
                    table.ForeignKey(
                        name: "FK_DetallePagosTennis_PagosTennis_PagoId",
                        column: x => x.PagoId,
                        principalTable: "PagosTennis",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tennis",
                columns: new[] { "TenniId", "Costo", "Existencia", "Marca", "Precio" },
                values: new object[,]
                {
                    { 1, 80.0, 50, "Nike", 100.0 },
                    { 2, 50.0, 50, "Adidas", 80.0 },
                    { 3, 150.0, 50, "Jordan", 200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePagosTennis_PagoId",
                table: "DetallePagosTennis",
                column: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "DetallePagosTennis");

            migrationBuilder.DropTable(
                name: "Tennis");

            migrationBuilder.DropTable(
                name: "PagosTennis");
        }
    }
}
