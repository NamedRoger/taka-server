using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addmaestrosymateriasenclase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clase_horario_HorarioIdHorario",
                table: "clase");

            migrationBuilder.DropForeignKey(
                name: "FK_clase_materias_MateriaIdMateria",
                table: "clase");

            migrationBuilder.DropForeignKey(
                name: "FK_clase_usuarios_MaestroIdUsuario",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_HorarioIdHorario",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_MaestroIdUsuario",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_MateriaIdMateria",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "HorarioIdHorario",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "MaestroIdUsuario",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "MateriaIdMateria",
                table: "clase");

            migrationBuilder.CreateIndex(
                name: "IX_clase_id_horario",
                table: "clase",
                column: "id_horario");

            migrationBuilder.CreateIndex(
                name: "IX_clase_id_maestro",
                table: "clase",
                column: "id_maestro");

            migrationBuilder.CreateIndex(
                name: "IX_clase_id_materia",
                table: "clase",
                column: "id_materia");

            migrationBuilder.AddForeignKey(
                name: "FK_clase_horario_id_horario",
                table: "clase",
                column: "id_horario",
                principalTable: "horario",
                principalColumn: "id_horario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clase_materias_id_materia",
                table: "clase",
                column: "id_materia",
                principalTable: "materias",
                principalColumn: "id_materia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clase_usuarios_id_maestro",
                table: "clase",
                column: "id_maestro",
                principalTable: "usuarios",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clase_horario_id_horario",
                table: "clase");

            migrationBuilder.DropForeignKey(
                name: "FK_clase_materias_id_materia",
                table: "clase");

            migrationBuilder.DropForeignKey(
                name: "FK_clase_usuarios_id_maestro",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_id_horario",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_id_maestro",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_id_materia",
                table: "clase");

            migrationBuilder.AddColumn<int>(
                name: "HorarioIdHorario",
                table: "clase",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaestroIdUsuario",
                table: "clase",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MateriaIdMateria",
                table: "clase",
                type: "int(11)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_clase_horario_HorarioIdHorario",
                table: "clase",
                column: "HorarioIdHorario",
                principalTable: "horario",
                principalColumn: "id_horario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clase_materias_MateriaIdMateria",
                table: "clase",
                column: "MateriaIdMateria",
                principalTable: "materias",
                principalColumn: "id_materia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clase_usuarios_MaestroIdUsuario",
                table: "clase",
                column: "MaestroIdUsuario",
                principalTable: "usuarios",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
