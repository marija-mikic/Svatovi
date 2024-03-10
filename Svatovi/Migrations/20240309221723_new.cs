using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Svatovi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallerys_Datas_ImagessModelId",
                table: "Gallerys");

            migrationBuilder.DropIndex(
                name: "IX_Gallerys_ImagessModelId",
                table: "Gallerys");

            migrationBuilder.DropColumn(
                name: "ImagessModelId",
                table: "Gallerys");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Datas");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Gallerys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Coment",
                table: "Datas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Datas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gallerys_ImageId",
                table: "Gallerys",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallerys_Datas_ImageId",
                table: "Gallerys",
                column: "ImageId",
                principalTable: "Datas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallerys_Datas_ImageId",
                table: "Gallerys");

            migrationBuilder.DropIndex(
                name: "IX_Gallerys_ImageId",
                table: "Gallerys");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Gallerys");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Datas");

            migrationBuilder.AddColumn<int>(
                name: "ImagessModelId",
                table: "Gallerys",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Coment",
                table: "Datas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Datas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallerys_ImagessModelId",
                table: "Gallerys",
                column: "ImagessModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallerys_Datas_ImagessModelId",
                table: "Gallerys",
                column: "ImagessModelId",
                principalTable: "Datas",
                principalColumn: "Id");
        }
    }
}
