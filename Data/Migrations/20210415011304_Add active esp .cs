using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addactiveesp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "especialidades",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "especialidades",
                type: "tinyint(4)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)");
        }
    }
}
