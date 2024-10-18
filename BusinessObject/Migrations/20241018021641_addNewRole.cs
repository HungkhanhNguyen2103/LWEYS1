using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNewRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b1f515b-590d-49c2-a84d-3d59b9432c1b", "AQAAAAIAAYagAAAAEDDILRm+gUhct1cItcokpwibVhXCStRB/JIO1Co7bSa3ANWd36CtC2MMNJt+SpN9fA==", "53d53a03-706f-4924-8c88-79852ba3718c" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d5002bd-f22f-4c7c-bce1-3d22eff321ef", 0, null, "9f5c795e-ca2c-4930-8381-8f334f036d13", "staff@gmail.com", false, "Staff", 0, false, null, null, "STAFF", "AQAAAAIAAYagAAAAEAg7+0Ek/ArLK0wLn8TKhS9VErYcZnMBQHAbb/f24o9p4bZ6sSoM4uoXB6dawbkB5Q==", null, false, "07f53e68-f49e-45a3-bf9a-a4623fb532a8", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "627ec4a3-646f-455f-b65f-2903cf7819b2", null, "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "627ec4a3-646f-455f-b65f-2903cf7819b2", "7d5002bd-f22f-4c7c-bce1-3d22eff321ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf7819b2", "7d5002bd-f22f-4c7c-bce1-3d22eff321ef" });

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903cf7819b2");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f076990-59a7-461e-9886-8314a1be7ba5", "AQAAAAIAAYagAAAAEI4MOplyP4UmzzlS9h0m5QQ7DEmEDUMnR/xqVN2qUeLcjeMk83TfVNtorAxgfvM1fQ==", "378d7936-32c8-481a-a42c-f1c02b92393a" });
        }
    }
}
