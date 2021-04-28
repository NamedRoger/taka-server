using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addactivegrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos");

            migrationBuilder.AlterColumn<int>(
                name: "id_especialidad",
                table: "grupos",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "grupos",
                type: "tinyint(4)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true,
                oldDefaultValueSql: "'1'");

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos",
                column: "id_especialidad",
                principalTable: "especialidades",
                principalColumn: "id_especialidad",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos");

            migrationBuilder.AlterColumn<int>(
                name: "id_especialidad",
                table: "grupos",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "grupos",
                type: "tinyint(4)",
                nullable: true,
                defaultValueSql: "'1'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValueSql: "'1'");

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_especialidades_id_especialidad",
                table: "grupos",
                column: "id_especialidad",
                principalTable: "especialidades",
                principalColumn: "id_especialidad",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
