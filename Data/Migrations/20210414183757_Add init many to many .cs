using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addinitmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_id_role",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "clase_alumno");

            migrationBuilder.DropTable(
                name: "horario_alumno");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_id_role",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "username",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id_role",
                table: "usuarios",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "roles",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "roles",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "roles",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "id_rol",
                table: "roles",
                newName: "IdRol");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "usuarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldCollation: "latin1_swedish_ci")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<int>(
                name: "IdRole",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRol",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameNormalize",
                table: "usuarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "roles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldCollation: "latin1_swedish_ci")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "roles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldCollation: "latin1_swedish_ci")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Activo",
                table: "roles",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdRol",
                table: "roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserNameNormalize",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "usuarios",
                newName: "id_role");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "roles",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "roles",
                newName: "codigo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "roles",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "IdRol",
                table: "roles",
                newName: "id_rol");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "usuarios",
                type: "varchar(255)",
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<int>(
                name: "id_role",
                table: "usuarios",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "usuarios",
                type: "varchar(50)",
                nullable: true,
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "roles",
                type: "varchar(100)",
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "roles",
                type: "varchar(50)",
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<sbyte>(
                name: "activo",
                table: "roles",
                type: "tinyint(4)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_rol",
                table: "roles",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "clase_alumno",
                columns: table => new
                {
                    id_clase_alumno = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlumnoIdUsuario = table.Column<int>(type: "int(11)", nullable: true),
                    ClaseIdClase = table.Column<int>(type: "int(11)", nullable: true),
                    id_alumno = table.Column<int>(type: "int(11)", nullable: false),
                    id_clase = table.Column<int>(type: "int(11)", nullable: false),
                    parcial_1 = table.Column<double>(type: "double", nullable: true),
                    parcial_2 = table.Column<double>(type: "double", nullable: true),
                    parcial_3 = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_clase_alumno);
                    table.ForeignKey(
                        name: "FK_clase_alumno_clase_ClaseIdClase",
                        column: x => x.ClaseIdClase,
                        principalTable: "clase",
                        principalColumn: "id_clase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clase_alumno_usuarios_AlumnoIdUsuario",
                        column: x => x.AlumnoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horario_alumno",
                columns: table => new
                {
                    id_horario_alumno = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlumnoIdUsuario = table.Column<int>(type: "int(11)", nullable: true),
                    HorarioIdHorario = table.Column<int>(type: "int(11)", nullable: true),
                    id_alumno = table.Column<int>(type: "int(11)", nullable: false),
                    id_horario = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_horario_alumno);
                    table.ForeignKey(
                        name: "FK_horario_alumno_horario_HorarioIdHorario",
                        column: x => x.HorarioIdHorario,
                        principalTable: "horario",
                        principalColumn: "id_horario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horario_alumno_usuarios_AlumnoIdUsuario",
                        column: x => x.AlumnoIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_role",
                table: "usuarios",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_clase_alumno_AlumnoIdUsuario",
                table: "clase_alumno",
                column: "AlumnoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_clase_alumno_ClaseIdClase",
                table: "clase_alumno",
                column: "ClaseIdClase");

            migrationBuilder.CreateIndex(
                name: "IX_horario_alumno_AlumnoIdUsuario",
                table: "horario_alumno",
                column: "AlumnoIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_horario_alumno_HorarioIdHorario",
                table: "horario_alumno",
                column: "HorarioIdHorario");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_id_role",
                table: "usuarios",
                column: "id_role",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
