using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTecnico.Migrations
{
    public partial class BancoArquivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "Documentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivo",
                table: "Documentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "NomeArquivo",
                table: "Documentos");
        }
    }
}
