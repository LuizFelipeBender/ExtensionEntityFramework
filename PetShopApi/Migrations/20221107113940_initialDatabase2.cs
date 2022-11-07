using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopApi.Migrations
{
    public partial class initialDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TipoAtendimento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Profissional",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pet",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dono",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Consultas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TipoAtendimento");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Profissional");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dono");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Consultas");
        }
    }
}
