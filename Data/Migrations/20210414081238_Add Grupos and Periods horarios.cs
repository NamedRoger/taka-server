using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class AddGruposandPeriodshorarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horario_grupos_GrupoIdGrupo",
                table: "horario");

            migrationBuilder.DropForeignKey(
                name: "FK_horario_periodos_PeriodoIdPeriodo",
                table: "horario");

            migrationBuilder.DropIndex(
                name: "IX_horario_GrupoIdGrupo",
                table: "horario");

            migrationBuilder.DropIndex(
                name: "IX_horario_PeriodoIdPeriodo",
                table: "horario");

            migrationBuilder.DropColumn(
                name: "GrupoIdGrupo",
                table: "horario");

            migrationBuilder.DropColumn(
                name: "PeriodoIdPeriodo",
                table: "horario");

            migrationBuilder.CreateIndex(
                name: "IX_horario_id_grupo",
                table: "horario",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_horario_id_periodo",
                table: "horario",
                column: "id_periodo");

            migrationBuilder.AddForeignKey(
                name: "FK_horario_grupos_id_grupo",
                table: "horario",
                column: "id_grupo",
                principalTable: "grupos",
                principalColumn: "id_grupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_horario_periodos_id_periodo",
                table: "horario",
                column: "id_periodo",
                principalTable: "periodos",
                principalColumn: "id_periodo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horario_grupos_id_grupo",
                table: "horario");

            migrationBuilder.DropForeignKey(
                name: "FK_horario_periodos_id_periodo",
                table: "horario");

            migrationBuilder.DropIndex(
                name: "IX_horario_id_grupo",
                table: "horario");

            migrationBuilder.DropIndex(
                name: "IX_horario_id_periodo",
                table: "horario");

            migrationBuilder.AddColumn<int>(
                name: "GrupoIdGrupo",
                table: "horario",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeriodoIdPeriodo",
                table: "horario",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_horario_GrupoIdGrupo",
                table: "horario",
                column: "GrupoIdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_horario_PeriodoIdPeriodo",
                table: "horario",
                column: "PeriodoIdPeriodo");

            migrationBuilder.AddForeignKey(
                name: "FK_horario_grupos_GrupoIdGrupo",
                table: "horario",
                column: "GrupoIdGrupo",
                principalTable: "grupos",
                principalColumn: "id_grupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_horario_periodos_PeriodoIdPeriodo",
                table: "horario",
                column: "PeriodoIdPeriodo",
                principalTable: "periodos",
                principalColumn: "id_periodo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
