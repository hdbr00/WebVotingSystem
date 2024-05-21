using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalPrograWeb.DataAccess.Migrations
{
    public partial class IndexCedulaVotacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_AspNetUsers_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacion_AspNetUsers_UsuarioId",
                table: "Votacion");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Votacion",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Votacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Publicacion",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_AspNetUsers_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacion_AspNetUsers_UsuarioId",
                table: "Votacion",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_AspNetUsers_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacion_AspNetUsers_UsuarioId",
                table: "Votacion");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Votacion");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Votacion",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Publicacion",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_AspNetUsers_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacion_AspNetUsers_UsuarioId",
                table: "Votacion",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
