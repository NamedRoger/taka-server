using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class AddUserRole : Migration
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
                name: "IX_usuarios_id_role",
                table: "usuarios",
                column: "id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_id_role",
                table: "usuarios",
                column: "id_role",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_id_role",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_id_role",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRol",
                table: "usuarios",
                type: "int(11)",
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
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
