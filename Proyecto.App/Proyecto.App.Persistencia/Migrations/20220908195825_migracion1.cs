using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.App.Persistencia.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    faseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombreFase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.faseId);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    programaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    categoriaId = table.Column<int>(type: "int", nullable: true),
                    faseId = table.Column<int>(type: "int", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tiempoEstimado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaEjecucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.programaId);
                    table.ForeignKey(
                        name: "FK_Programas_Categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programas_Fases_faseId",
                        column: x => x.faseId,
                        principalTable: "Fases",
                        principalColumn: "faseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programas_categoriaId",
                table: "Programas",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Programas_clienteId",
                table: "Programas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Programas_faseId",
                table: "Programas",
                column: "faseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fases");
        }
    }
}
