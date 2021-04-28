using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_RoleIdRol",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_RoleIdRol",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "RoleIdRol",
                table: "usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_IdRole",
                table: "usuarios",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_IdRole",
                table: "usuarios",
                column: "IdRole",
                principalTable: "roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_IdRole",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_IdRole",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRol",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RoleIdRol",
                table: "usuarios",
                column: "RoleIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_RoleIdRol",
                table: "usuarios",
                column: "RoleIdRol",
                principalTable: "roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
