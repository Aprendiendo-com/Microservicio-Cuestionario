using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Cuestionario.AccessData.Migrations
{
    public partial class CuestionarioMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuestionarios",
                columns: table => new
                {
                    CuestionarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Calificacion = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionarios", x => x.CuestionarioID);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    RegistroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_Registros_Cuestionarios_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionarios",
                        principalColumn: "CuestionarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_CuestionarioId",
                table: "Registros",
                column: "CuestionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Cuestionarios");
        }
    }
}
