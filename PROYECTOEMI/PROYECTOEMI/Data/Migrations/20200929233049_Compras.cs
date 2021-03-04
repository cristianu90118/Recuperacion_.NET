using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTOEMI.Data.Migrations
{
    public partial class Compras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    IdPago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPago = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    NumFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFactura = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    IdPago = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    PagoIdPago = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.NumFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Pago_PagoIdPago",
                        column: x => x.PagoIdPago,
                        principalTable: "Pago",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprar",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechacompra = table.Column<DateTime>(nullable: true, defaultValue: DateTime.Now),
                    UsuarioId = table.Column<string>(nullable: true),
                    Total = table.Column<float>(nullable: false),
                    FacturaNumFactura = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprar", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Comprar_Factura_FacturaNumFactura",
                        column: x => x.FacturaNumFactura,
                        principalTable: "Factura",
                        principalColumn: "NumFactura",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprarProducto",
                columns: table => new
                {
                    ComprarCursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprarId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprarProducto", x => x.ComprarCursoId);
                    table.ForeignKey(
                        name: "FK_ComprarProducto_Comprar_ComprarId",
                        column: x => x.ComprarId,
                        principalTable: "Comprar",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprarProducto_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprarProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprar_FacturaNumFactura",
                table: "Comprar",
                column: "FacturaNumFactura");

            migrationBuilder.CreateIndex(
                name: "IX_ComprarProducto_ComprarId",
                table: "ComprarProducto",
                column: "ComprarId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprarProducto_EmpleadoId",
                table: "ComprarProducto",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprarProducto_ProductoId",
                table: "ComprarProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PagoIdPago",
                table: "Factura",
                column: "PagoIdPago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprarProducto");

            migrationBuilder.DropTable(
                name: "Comprar");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProducto",
                table: "Producto",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<double>(type: "float", nullable: true),
                    NombreVenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                });
        }
    }
}
