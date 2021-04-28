using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class Addmanytomanyclasesalumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaseAlumno",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "int(11)", nullable: false),
                    IdAlumno = table.Column<int>(type: "int(11)", nullable: false),
                    Parcial1 = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Parcial2 = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Parcial3 = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseAlumno", x => new { x.IdAlumno, x.IdClase });
                    table.ForeignKey(
                        name: "FK_ClaseAlumno_clase_IdClase",
                        column: x => x.IdClase,
                        principalTable: "clase",
                        principalColumn: "id_clase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseAlumno_usuarios_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaseAlumno_IdClase",
                table: "ClaseAlumno",
                column: "IdClase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaseAlumno");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_email",
                table: "usuarios");
        }
    }
}
