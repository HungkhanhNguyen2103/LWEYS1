using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class kythuyninh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f596653-adbe-4107-a082-0c14fcb4e5d7", "AQAAAAIAAYagAAAAEO8mhlxpOs5mbFU3pO6qvIlH+o7+KqIWtWZFKIZUAfx3AA8vzvAfWjTX+8ouMbmNCQ==", "2b9e75d3-ac0f-4352-8d9d-32f0ed4ed2b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb21a52-cd74-4ba4-bb43-5b01039ba122", "AQAAAAIAAYagAAAAEBpPa7jtqBggK3RZloLaTLPyipf1OlCkBIU7fAvfnHWpLIKP5zfy56Hq5WiFX4v04Q==", "93910375-d6a4-4064-aa5e-fe5ff875865d" });
        }
    }
}
