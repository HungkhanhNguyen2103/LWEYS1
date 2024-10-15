using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class init15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "ServiceOrderHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRating",
                table: "ServiceOrderHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfa16678-33ab-40da-987a-9fcaf017acf0", "AQAAAAIAAYagAAAAEDsHgS60RPh17N9kTiUKEbS8JYA0BJLiAagyGWExFiMtCq5LqsltB5Rpub/LFuYwZQ==", "818550c2-bfd7-4444-b5e2-4f52bcb889bd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "ServiceOrderHistory");

            migrationBuilder.DropColumn(
                name: "IsRating",
                table: "ServiceOrderHistory");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8665159b-5b93-4d7a-9345-da73097438e4", "AQAAAAIAAYagAAAAEAQQqdLeihkCZnFa5VP4z2iypooy5Y+zFl8LP2KX8BGu6UYMPiNWDhgcIwx65mfn3g==", "7945d4f1-d6b9-45fd-a657-71ce90f22b9a" });
        }
    }
}
