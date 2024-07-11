using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookCrud.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToComicModelForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ComicBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ComicBooks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ComicBooks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ComicBooks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ComicBooks_CategoryId",
                table: "ComicBooks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBooks_Categories_CategoryId",
                table: "ComicBooks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBooks_Categories_CategoryId",
                table: "ComicBooks");

            migrationBuilder.DropIndex(
                name: "IX_ComicBooks_CategoryId",
                table: "ComicBooks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ComicBooks");
        }
    }
}
