using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class inti10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9274a5f3-d7c6-4388-8982-88aa2fc5e216", "AQAAAAIAAYagAAAAEL+3JIQ6BIkpnU0U/z2CtuIq9Kij7V4lB0b4Ddzsm4bA7CGGp9GdGpOqK2S4DqPVbQ==", "b83c2277-300d-40ed-8163-1575a5a3f9f9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37cec015-0abd-457c-80d0-87f5b23ee31f", "AQAAAAIAAYagAAAAEFaQqJ0AFjWisE6TORccjCP9t/knHC1Og+pyupnN6Pvxx7s9ZdRtOD939JCJRLjIEw==", "8ee4cd31-060e-48cb-a150-116d0676d86d" });
        }
    }
}
