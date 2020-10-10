using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Cuestionario.AccessData.Migrations
{
    public partial class CreateMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaseId",
                table: "Cuestionarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaseId",
                table: "Cuestionarios");
        }
    }
}
