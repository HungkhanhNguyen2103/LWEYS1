using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnUserQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminMessage",
                table: "UserQuestion",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminUserName",
                table: "UserQuestion",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminMessage",
                table: "UserQuestion");

            migrationBuilder.DropColumn(
                name: "AdminUserName",
                table: "UserQuestion");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b1f515b-590d-49c2-a84d-3d59b9432c1b", "AQAAAAIAAYagAAAAEDDILRm+gUhct1cItcokpwibVhXCStRB/JIO1Co7bSa3ANWd36CtC2MMNJt+SpN9fA==", "53d53a03-706f-4924-8c88-79852ba3718c" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f5c795e-ca2c-4930-8381-8f334f036d13", "AQAAAAIAAYagAAAAEAg7+0Ek/ArLK0wLn8TKhS9VErYcZnMBQHAbb/f24o9p4bZ6sSoM4uoXB6dawbkB5Q==", "07f53e68-f49e-45a3-bf9a-a4623fb532a8" });
        }
    }
}
