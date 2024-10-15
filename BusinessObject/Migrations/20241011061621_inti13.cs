using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class inti13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8665159b-5b93-4d7a-9345-da73097438e4", "AQAAAAIAAYagAAAAEAQQqdLeihkCZnFa5VP4z2iypooy5Y+zFl8LP2KX8BGu6UYMPiNWDhgcIwx65mfn3g==", "7945d4f1-d6b9-45fd-a657-71ce90f22b9a" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ServiceId",
                table: "Feedbacks",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Service_ServiceId",
                table: "Feedbacks",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Service_ServiceId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ServiceId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e53d2cd8-70a2-4604-a14c-ff18c7361a98", "AQAAAAIAAYagAAAAEPyTsQ8rFEgKTpnP0SQyA9y2/bsjRFSJPnJBaPFyZU+Ff+QKlsEsA72V9cffeWmvKQ==", "46f72287-8866-4aa1-9851-5c9dd1ca861c" });
        }
    }
}
