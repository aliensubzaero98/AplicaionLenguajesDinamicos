using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GestorEstudiantil.DataAcces.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    EstudianteId = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    MateriaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreMateria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Semestre",
                columns: table => new
                {
                    SemestreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreSemestre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestre", x => x.SemestreId);
                });

            migrationBuilder.CreateTable(
                name: "SemestreMateria",
                columns: table => new
                {
                    SemestreMateriaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MateriaId = table.Column<int>(nullable: false),
                    SemestreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemestreMateria", x => x.SemestreMateriaId);
                    table.ForeignKey(
                        name: "FK_SemestreMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemestreMateria_Semestre_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semestre",
                        principalColumn: "SemestreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteMatriculado",
                columns: table => new
                {
                    EstudianteMatriculadoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstudianteId = table.Column<int>(nullable: false),
                    EstudianteId1 = table.Column<string>(nullable: true),
                    FechaMatricula = table.Column<DateTime>(nullable: false),
                    SemestreMateriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteMatriculado", x => x.EstudianteMatriculadoId);
                    table.ForeignKey(
                        name: "FK_EstudianteMatriculado_Estudiante_EstudianteId1",
                        column: x => x.EstudianteId1,
                        principalTable: "Estudiante",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudianteMatriculado_SemestreMateria_SemestreMateriaId",
                        column: x => x.SemestreMateriaId,
                        principalTable: "SemestreMateria",
                        principalColumn: "SemestreMateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Asistio = table.Column<bool>(nullable: false),
                    EstudianteMatriculadoId = table.Column<int>(nullable: false),
                    FechaAsistencia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.AsistenciaId);
                    table.ForeignKey(
                        name: "FK_Asistencia_EstudianteMatriculado_EstudianteMatriculadoId",
                        column: x => x.EstudianteMatriculadoId,
                        principalTable: "EstudianteMatriculado",
                        principalColumn: "EstudianteMatriculadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_EstudianteMatriculadoId",
                table: "Asistencia",
                column: "EstudianteMatriculadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteMatriculado_EstudianteId1",
                table: "EstudianteMatriculado",
                column: "EstudianteId1");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteMatriculado_SemestreMateriaId",
                table: "EstudianteMatriculado",
                column: "SemestreMateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMateria_MateriaId",
                table: "SemestreMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMateria_SemestreId",
                table: "SemestreMateria",
                column: "SemestreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "EstudianteMatriculado");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "SemestreMateria");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Semestre");
        }
    }
}
