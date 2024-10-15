using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75bb2f49-54c7-43c7-8ac4-7bf7c65d4830", "AQAAAAIAAYagAAAAEHc6xhLJ2JwVvZaWCNDpTU+RbLlSEJYKLl9gMwNTY/5mL0PkyRxsmF5yUR/6DXN7wg==", "c3105bcf-313d-4ff6-8059-a6c9ba03892a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc54ef48-cb26-4169-81df-5025c0264c98", "AQAAAAIAAYagAAAAEGEm0b1HS/SbTJscYd1LVYxqSvSL8RaksB2cm/2sYvMWVN8RtnYJWoBYFgUOhg9bnA==", "3a22d8b6-8f91-4edf-8d0e-78087aedb0b8" });
        }
    }
}
