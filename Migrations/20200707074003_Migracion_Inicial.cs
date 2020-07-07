using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2doParcial.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    DescripcionProyecto = table.Column<string>(nullable: true),
                    TiempoTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    Requerimiento = table.Column<string>(nullable: true),
                    TiempoMinutos = table.Column<int>(nullable: false),
                    ProyectosProyectoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectosProyectoId",
                        column: x => x.ProyectosProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Tareas_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tareas",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 3, "Programación" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 4, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectosProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectosProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_TipoId",
                table: "ProyectosDetalle",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
