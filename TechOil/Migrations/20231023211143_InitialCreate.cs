using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    codProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.codProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    codServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.codServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    codUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.codUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    codTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cantHoras = table.Column<int>(type: "int", nullable: false),
                    valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    codProyecto = table.Column<int>(type: "int", nullable: true),
                    codServicio = table.Column<int>(type: "int", nullable: true),
                    proyectocodProyecto = table.Column<int>(type: "int", nullable: false),
                    serviciocodServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.codTrabajo);
                    table.ForeignKey(
                        name: "FK_Trabajos_Proyectos_proyectocodProyecto",
                        column: x => x.proyectocodProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "codProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Servicios_serviciocodServicio",
                        column: x => x.serviciocodServicio,
                        principalTable: "Servicios",
                        principalColumn: "codServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_proyectocodProyecto",
                table: "Trabajos",
                column: "proyectocodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_serviciocodServicio",
                table: "Trabajos",
                column: "serviciocodServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
