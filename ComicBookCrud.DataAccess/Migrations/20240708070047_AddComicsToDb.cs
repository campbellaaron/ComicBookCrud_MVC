using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComicBookCrud.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddComicsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ComicBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    CoverPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicBooks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComicBooks",
                columns: new[] { "Id", "Author", "CoverPrice", "Description", "Issue", "ListPrice", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Neil Gaiman & Dave McKean", 3.5, "Two girls awaken in a greenhouse and encounter DC characters like Batman and Swamp Thing", 1, 11.99, "DC Comics", "Black Orchid: Book One" },
                    { 2, "Neil Gaiman & Dave McKean", 3.5, "Black Orchid tries to remember her sister; Carl returns to get revenge on Philip for stealing his woman", 2, 12.99, "DC Comics", "Black Orchid: Book Two" },
                    { 3, "James Tynion & Fernando Blanco", 9.9900000000000002, "Issues 1-5 of the infamouse \"w0rldtr33\" series. In 1999, Gabriel and his friends discover the Undernet -- a secret architecture to the Internet.", 1, 9.9900000000000002, "Image Comics", "w0rltr33" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicBooks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
