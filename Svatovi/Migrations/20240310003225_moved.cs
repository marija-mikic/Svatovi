using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Svatovi.Migrations
{
    /// <inheritdoc />
    public partial class moved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Datas");

            migrationBuilder.CreateTable(
                name: "ImagessModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagessModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagessModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryModel_ImagessModel_ImagessModelId",
                        column: x => x.ImagessModelId,
                        principalTable: "ImagessModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryModel_ImagessModelId",
                table: "GalleryModel",
                column: "ImagessModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryModel");

            migrationBuilder.DropTable(
                name: "ImagessModel");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Datas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
