using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc54ef48-cb26-4169-81df-5025c0264c98", "AQAAAAIAAYagAAAAEGEm0b1HS/SbTJscYd1LVYxqSvSL8RaksB2cm/2sYvMWVN8RtnYJWoBYFgUOhg9bnA==", "3a22d8b6-8f91-4edf-8d0e-78087aedb0b8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3dad4f1-a4ee-4192-b5f1-0f2609100b0d", "AQAAAAIAAYagAAAAELgUpdske/ro7+IqUJnRbnSUk+Ke3TLmQl1ge6uhVI5YA5pIOZHrYbWZy9faPTatGw==", "20b11ca4-ff83-478d-aae9-e63d85d01e96" });
        }
    }
}
