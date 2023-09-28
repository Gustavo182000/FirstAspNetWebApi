using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAspNetWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photo",
                table: "Funcionarios",
                newName: "photoPath");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photoPath",
                table: "Funcionarios",
                newName: "photo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Funcionarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
