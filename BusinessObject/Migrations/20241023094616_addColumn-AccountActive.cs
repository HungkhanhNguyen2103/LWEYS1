using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnAccountActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AccountActive",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "f168ae3d-ff64-4161-a7e0-910bff2f41ac", "AQAAAAIAAYagAAAAEEpYbWwcJyGyrRzeOWQv/VOWt9f9yZugpHKBLdQl/qXDIuJ5mteD7DhJwhnJwmusGw==", "abce34eb-c346-467d-a28a-8bca9c1edc33" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "9846d2d4-05b5-41f8-a8ee-f7d8d5b77a7a", "AQAAAAIAAYagAAAAEIz2C3aImtNknnkVAmAfNCsAYBl8VQw1aAFqAG9hZpktqlXq8Rug312cNxNYCeIfVw==", "a4ca1424-9e1d-4c39-9d40-79d08162da1c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountActive",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfaeb268-c916-420c-981f-8609be5e4385", "AQAAAAIAAYagAAAAEIMu3M5Ax+03zdjebTArXJq1J9FsTsxGLlsbl5STMp+0v9erJo9O6iphuxeVd8vj8g==", "582567f2-3d46-40dc-a68b-78148dcb7815" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7da7bec-1bf7-42b8-b932-562e54eb0547", "AQAAAAIAAYagAAAAEH1OQEAIBSyhNZqgodcHQ67f1j3av1WhrcwQ15NfqYSFDcaSYXy54WjJ0g1n4GltuQ==", "5c15c7c8-1ee9-4ab3-af06-f494bfa4d873" });
        }
    }
}
