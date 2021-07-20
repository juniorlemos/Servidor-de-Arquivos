using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTecnico.Migrations
{
    public partial class bdRelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "Documentos");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Arquivo",
                table: "Documentos",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Arquivo",
                table: "Documentos",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "Documentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
