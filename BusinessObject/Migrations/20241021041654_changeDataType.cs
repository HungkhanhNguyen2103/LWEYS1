using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Post",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostDescription",
                table: "Post",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ac10293-62a2-4cf1-a631-abc479487211", "AQAAAAIAAYagAAAAEA6T2QB5Fu5YxktVovP3NJmwc3HETq85p0thJhjUfeTxVY09lzl3oVYieYwLXuQ4YQ==", "7f13cbb0-04ce-497c-bff9-4fc07ec21a0a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "addc4821-08cb-4656-ac65-a8991f7221ef", "AQAAAAIAAYagAAAAEMkcan+uucthihuB4jA40wP1PdlCmbOdUXGNVf+cz1XlMSvTVoG0XMFnFxxMFDJWPg==", "90950c34-03e5-46ba-8cb6-860d5d306860" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Post",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostDescription",
                table: "Post",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3298b934-5040-4e84-b2d3-dbf0272291cb", "AQAAAAIAAYagAAAAEDfsJ5aaHIC+f6XTX5vDnJjm8w1f6DR+Ez6szfHKCTU+scuxw4CNBXLCBSScIomnaw==", "ac5f70b3-94d9-48c8-bfa3-f17359d35fa0" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a8b3883-53fb-4014-a4df-a46dc56e0243", "AQAAAAIAAYagAAAAEC1+qMG94pn1KxFciRwr9yebA40jaTdJjaUiUqLpmml9dJs3SOdYccll7lQsyBxNbQ==", "d37dec01-08b8-41a2-8523-9f6e7ae2f803" });
        }
    }
}
