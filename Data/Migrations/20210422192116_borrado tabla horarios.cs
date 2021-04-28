using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class borradotablahorarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioUsuario");

            migrationBuilder.DropTable(
                name: "horario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "horario",
                columns: table => new
                {
                    id_horario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activo = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValue: (sbyte)1),
                    id_grupo = table.Column<int>(type: "int(11)", nullable: false),
                    id_periodo = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_horario);
                    table.ForeignKey(
                        name: "FK_horario_grupos_id_grupo",
                        column: x => x.id_grupo,
                        principalTable: "grupos",
                        principalColumn: "id_grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_horario_periodos_id_periodo",
                        column: x => x.id_periodo,
                        principalTable: "periodos",
                        principalColumn: "id_periodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioUsuario",
                columns: table => new
                {
                    AlumnosIdUsuario = table.Column<int>(type: "int(11)", nullable: false),
                    HorariosIdHorario = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioUsuario", x => new { x.AlumnosIdUsuario, x.HorariosIdHorario });
                    table.ForeignKey(
                        name: "FK_HorarioUsuario_horario_HorariosIdHorario",
                        column: x => x.HorariosIdHorario,
                        principalTable: "horario",
                        principalColumn: "id_horario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorarioUsuario_usuarios_AlumnosIdUsuario",
                        column: x => x.AlumnosIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_horario_id_grupo",
                table: "horario",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_horario_id_periodo",
                table: "horario",
                column: "id_periodo");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioUsuario_HorariosIdHorario",
                table: "HorarioUsuario",
                column: "HorariosIdHorario");
        }
    }
}
