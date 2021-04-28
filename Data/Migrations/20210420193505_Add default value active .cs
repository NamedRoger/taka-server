using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Adddefaultvalueactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "materias",
                type: "tinyint(4)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValueSql: "'1'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "materias",
                type: "tinyint(4)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldDefaultValueSql: "1");
        }
    }
}
