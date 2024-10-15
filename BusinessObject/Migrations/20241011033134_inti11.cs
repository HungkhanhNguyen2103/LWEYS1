using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class inti11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ServiceOrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ServiceOrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "ServiceOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ServiceOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "206e994c-48ae-4b5d-af34-6feb065de1b3", "AQAAAAIAAYagAAAAECsFoOpMyM4hE3U9G9S9XfkK3m+czx4F5hKb2SR6sryCU8AuDoUC0yh7rILbbm+S2A==", "50d7506f-1a8a-40db-8d03-d7bee2356df2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ServiceOrderHistory");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceOrderHistory");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "ServiceOrder");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ServiceOrder");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9274a5f3-d7c6-4388-8982-88aa2fc5e216", "AQAAAAIAAYagAAAAEL+3JIQ6BIkpnU0U/z2CtuIq9Kij7V4lB0b4Ddzsm4bA7CGGp9GdGpOqK2S4DqPVbQ==", "b83c2277-300d-40ed-8163-1575a5a3f9f9" });
        }
    }
}
