using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class addclasesAlumosdataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaseAlumno_clase_IdClase",
                table: "ClaseAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaseAlumno_usuarios_IdAlumno",
                table: "ClaseAlumno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaseAlumno",
                table: "ClaseAlumno");

            migrationBuilder.RenameTable(
                name: "ClaseAlumno",
                newName: "ClaseAlumnos");

            migrationBuilder.RenameIndex(
                name: "IX_ClaseAlumno_IdClase",
                table: "ClaseAlumnos",
                newName: "IX_ClaseAlumnos_IdClase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaseAlumnos",
                table: "ClaseAlumnos",
                columns: new[] { "IdAlumno", "IdClase" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseAlumnos_clase_IdClase",
                table: "ClaseAlumnos",
                column: "IdClase",
                principalTable: "clase",
                principalColumn: "id_clase",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseAlumnos_usuarios_IdAlumno",
                table: "ClaseAlumnos",
                column: "IdAlumno",
                principalTable: "usuarios",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaseAlumnos_clase_IdClase",
                table: "ClaseAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaseAlumnos_usuarios_IdAlumno",
                table: "ClaseAlumnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaseAlumnos",
                table: "ClaseAlumnos");

            migrationBuilder.RenameTable(
                name: "ClaseAlumnos",
                newName: "ClaseAlumno");

            migrationBuilder.RenameIndex(
                name: "IX_ClaseAlumnos_IdClase",
                table: "ClaseAlumno",
                newName: "IX_ClaseAlumno_IdClase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaseAlumno",
                table: "ClaseAlumno",
                columns: new[] { "IdAlumno", "IdClase" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseAlumno_clase_IdClase",
                table: "ClaseAlumno",
                column: "IdClase",
                principalTable: "clase",
                principalColumn: "id_clase",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseAlumno_usuarios_IdAlumno",
                table: "ClaseAlumno",
                column: "IdAlumno",
                principalTable: "usuarios",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
