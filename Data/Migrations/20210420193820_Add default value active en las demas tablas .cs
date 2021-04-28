using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Adddefaultvalueactiveenlasdemastablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "usuarios",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "materias",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "horario",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "grupos",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValueSql: "'1'");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "especialidades",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "clase",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "usuarios",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "materias",
                type: "tinyint(4)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "horario",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "grupos",
                type: "tinyint(4)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "especialidades",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "clase",
                type: "tinyint(4)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValue: (sbyte)1);
        }
    }
}
