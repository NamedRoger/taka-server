using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class deletedependecyhorarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clase_horario_id_horario",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_id_horario",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "id_horario",
                table: "clase");

            migrationBuilder.AddColumn<int>(
                name: "IdGrupo",
                table: "clase",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPeriodo",
                table: "clase",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_clase_IdGrupo",
                table: "clase",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_clase_IdPeriodo",
                table: "clase",
                column: "IdPeriodo");

            migrationBuilder.AddForeignKey(
                name: "FK_clase_grupos_IdGrupo",
                table: "clase",
                column: "IdGrupo",
                principalTable: "grupos",
                principalColumn: "id_grupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clase_periodos_IdPeriodo",
                table: "clase",
                column: "IdPeriodo",
                principalTable: "periodos",
                principalColumn: "id_periodo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clase_grupos_IdGrupo",
                table: "clase");

            migrationBuilder.DropForeignKey(
                name: "FK_clase_periodos_IdPeriodo",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_IdGrupo",
                table: "clase");

            migrationBuilder.DropIndex(
                name: "IX_clase_IdPeriodo",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "IdGrupo",
                table: "clase");

            migrationBuilder.DropColumn(
                name: "IdPeriodo",
                table: "clase");

            migrationBuilder.AddColumn<int>(
                name: "id_horario",
                table: "clase",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clase_id_horario",
                table: "clase",
                column: "id_horario");

            migrationBuilder.AddForeignKey(
                name: "FK_clase_horario_id_horario",
                table: "clase",
                column: "id_horario",
                principalTable: "horario",
                principalColumn: "id_horario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
