using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    /// <inheritdoc />
    public partial class fixDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajos_Proyectos_proyectocodProyecto",
                table: "Trabajos");

            migrationBuilder.DropForeignKey(
                name: "FK_Trabajos_Servicios_serviciocodServicio",
                table: "Trabajos");

            migrationBuilder.DropIndex(
                name: "IX_Trabajos_proyectocodProyecto",
                table: "Trabajos");

            migrationBuilder.DropIndex(
                name: "IX_Trabajos_serviciocodServicio",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "proyectocodProyecto",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "serviciocodServicio",
                table: "Trabajos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proyectocodProyecto",
                table: "Trabajos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "serviciocodServicio",
                table: "Trabajos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_proyectocodProyecto",
                table: "Trabajos",
                column: "proyectocodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_serviciocodServicio",
                table: "Trabajos",
                column: "serviciocodServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajos_Proyectos_proyectocodProyecto",
                table: "Trabajos",
                column: "proyectocodProyecto",
                principalTable: "Proyectos",
                principalColumn: "codProyecto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajos_Servicios_serviciocodServicio",
                table: "Trabajos",
                column: "serviciocodServicio",
                principalTable: "Servicios",
                principalColumn: "codServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
