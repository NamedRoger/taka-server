using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class renamecolumnemailtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "usuarios",
                newName: "username");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                newName: "IX_usuarios_username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "usuarios",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_username",
                table: "usuarios",
                newName: "IX_usuarios_email");
        }
    }
}
