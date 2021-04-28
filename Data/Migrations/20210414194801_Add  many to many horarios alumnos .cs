using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addmanytomanyhorariosalumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_HorarioUsuario_HorariosIdHorario",
                table: "HorarioUsuario",
                column: "HorariosIdHorario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioUsuario");
        }
    }
}
