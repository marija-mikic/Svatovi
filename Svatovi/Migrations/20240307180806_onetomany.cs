using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Svatovi.Migrations
{
    /// <inheritdoc />
    public partial class onetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagessModelId",
                table: "Gallerys",
                type: "int",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
