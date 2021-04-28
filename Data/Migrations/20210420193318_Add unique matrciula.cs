using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Adduniquematrciula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "horario",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "clase",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_matricula",
                table: "usuarios",
                column: "matricula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuarios_matricula",
                table: "usuarios");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "horario",
                type: "tinyint(4)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "clase",
                type: "tinyint(4)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");
        }
    }
}
