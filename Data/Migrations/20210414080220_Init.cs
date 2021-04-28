using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "especialidades",
                columns: table => new
                {
                    id_especialidad = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_especialidad);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id_materia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_materia);
                });

            migrationBuilder.CreateTable(
                name: "periodos",
                columns: table => new
                {
                    id_periodo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "date", nullable: true),
                    nombre = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_periodo);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    id_grupo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true, defaultValueSql: "'1'"),
                    id_especialidad = table.Column<int>(type: "int(11)", nullable: true),
                    EspecialidadIdEspecialidad = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_grupo);
                    table.ForeignKey(
                        name: "FK_grupos_especialidades_EspecialidadIdEspecialidad",
                        column: x => x.EspecialidadIdEspecialidad,
                        principalTable: "especialidades",
                        principalColumn: "id_especialidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    apellido_paterno = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    apellido_materno = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    username = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    password = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    email = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    curp = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    id_role = table.Column<int>(type: "int(11)", nullable: true),
                    RoleIdRol = table.Column<int>(type: "int(11)", nullable: true),
                    matricula = table.Column<string>(type: "varchar(100)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_RoleIdRol",
                        column: x => x.RoleIdRol,
                        principalTable: "roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horario",
                columns: table => new
                {
                    id_horario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_grupo = table.Column<int>(type: "int(11)", nullable: false),
                    GrupoIdGrupo = table.Column<int>(type: "int(11)", nullable: true),
                    id_periodo = table.Column<int>(type: "int(11)", nullable: false),
                    PeriodoIdPeriodo = table.Column<int>(type: "int(11)", nullable: true),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_horario);
                    table.ForeignKey(
                        name: "FK_horario_grupos_GrupoIdGrupo",
                        column: x => x.GrupoIdGrupo,
                        principalTable: "grupos",
                        principalColumn: "id_grupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horario_periodos_PeriodoIdPeriodo",
                        column: x => x.PeriodoIdPeriodo,
                        principalTable: "periodos",
                        principalColumn: "id_periodo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clase",
                columns: table => new
                {
                    id_clase = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    id_materia = table.Column<int>(type: "int(11)", nullable: true),
                    MateriaIdMateria = table.Column<int>(type: "int(11)", nullable: true),
                    id_maestro = table.Column<int>(type: "int(11)", nullable: true),
                    MaestroIdUsuario = table.Column<int>(type: "int(11)", nullable: true),
                    hora_inicio = table.Column<TimeSpan>(type: "time", nullable: true),
                    hora_fin = table.Column<TimeSpan>(type: "time", nullable: true),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    id_horario = table.Column<int>(type: "int(11)", nullable: true),
                    HorarioIdHorario = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_clase);
                    table.ForeignKey(
                        name: "FK_clase_horario_HorarioIdHorario",
                        column: x => x.HorarioIdHorario,
                        principalTable: "horario",
                        principalColumn: "id_horario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clase_materias_MateriaIdMateria",
                        column: x => x.MateriaIdMateria,
                        principalTable: "materias",
                        principalColumn: "id_materia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clase_usuarios_MaestroIdUsuario",
                        column: x => x.MaestroIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horario_alumno",
                columns: table => new
                {
                    id_horario_alumno = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_horario = table.Column<int>(type: "int(11)", nullable: false),
                    HorarioIdHorario = table.Column<int>(type: "int(11)", nullable: true),
                    id_alumno = table.Column<int>(type: "int(11)", nullable: false),
                    AlumnoIdUsuario = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_horario_alumno);
                    table.ForeignKey(
                        name: "FK_horario_alumno_horario_HorarioIdHorario",
                        column: x => x.HorarioIdHorario,
                        principalTable: "horario",
                        principalColumn: "id_horario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horario_alumno_usuarios_AlumnoIdUsuario",
                        column: x => x.AlumnoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clase_alumno",
                columns: table => new
                {
                    id_clase_alumno = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_clase = table.Column<int>(type: "int(11)", nullable: false),
                    ClaseIdClase = table.Column<int>(type: "int(11)", nullable: true),
                    id_alumno = table.Column<int>(type: "int(11)", nullable: false),
                    AlumnoIdUsuario = table.Column<int>(type: "int(11)", nullable: true),
                    parcial_1 = table.Column<double>(type: "double", nullable: true),
                    parcial_2 = table.Column<double>(type: "double", nullable: true),
                    parcial_3 = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_clase_alumno);
                    table.ForeignKey(
                        name: "FK_clase_alumno_clase_ClaseIdClase",
                        column: x => x.ClaseIdClase,
                        principalTable: "clase",
                        principalColumn: "id_clase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clase_alumno_usuarios_AlumnoIdUsuario",
                        column: x => x.AlumnoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clase_HorarioIdHorario",
                table: "clase",
                column: "HorarioIdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_clase_MaestroIdUsuario",
                table: "clase",
                column: "MaestroIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_clase_MateriaIdMateria",
                table: "clase",
                column: "MateriaIdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_clase_alumno_AlumnoIdUsuario",
                table: "clase_alumno",
                column: "AlumnoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_clase_alumno_ClaseIdClase",
                table: "clase_alumno",
                column: "ClaseIdClase");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_EspecialidadIdEspecialidad",
                table: "grupos",
                column: "EspecialidadIdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_horario_GrupoIdGrupo",
                table: "horario",
                column: "GrupoIdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_horario_PeriodoIdPeriodo",
                table: "horario",
                column: "PeriodoIdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_horario_alumno_AlumnoIdUsuario",
                table: "horario_alumno",
                column: "AlumnoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_horario_alumno_HorarioIdHorario",
                table: "horario_alumno",
                column: "HorarioIdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RoleIdRol",
                table: "usuarios",
                column: "RoleIdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clase_alumno");

            migrationBuilder.DropTable(
                name: "horario_alumno");

            migrationBuilder.DropTable(
                name: "clase");

            migrationBuilder.DropTable(
                name: "horario");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "periodos");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "especialidades");
        }
    }
}
