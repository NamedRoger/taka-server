using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class AddEspecialidadfromgrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupos_especialidades_EspecialidadIdEspecialidad",
                table: "grupos");

            migrationBuilder.DropIndex(
                name: "IX_grupos_EspecialidadIdEspecialidad",
                table: "grupos");

            migrationBuilder.DropColumn(
                name: "EspecialidadIdEspecialidad",
                table: "grupos");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_id_especialidad",
                table: "grupos",
                column: "id_especialidad");

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos",
                column: "id_especialidad",
                principalTable: "especialidades",
                principalColumn: "id_especialidad",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos");

            migrationBuilder.DropIndex(
                name: "IX_grupos_id_especialidad",
                table: "grupos");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadIdEspecialidad",
                table: "grupos",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_grupos_EspecialidadIdEspecialidad",
                table: "grupos",
                column: "EspecialidadIdEspecialidad");

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_especialidades_EspecialidadIdEspecialidad",
                table: "grupos",
                column: "EspecialidadIdEspecialidad",
                principalTable: "especialidades",
                principalColumn: "id_especialidad",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
