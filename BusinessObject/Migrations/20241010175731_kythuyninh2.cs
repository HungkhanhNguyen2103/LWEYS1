using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class kythuyninh2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37cec015-0abd-457c-80d0-87f5b23ee31f", "AQAAAAIAAYagAAAAEFaQqJ0AFjWisE6TORccjCP9t/knHC1Og+pyupnN6Pvxx7s9ZdRtOD939JCJRLjIEw==", "8ee4cd31-060e-48cb-a150-116d0676d86d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f596653-adbe-4107-a082-0c14fcb4e5d7", "AQAAAAIAAYagAAAAEO8mhlxpOs5mbFU3pO6qvIlH+o7+KqIWtWZFKIZUAfx3AA8vzvAfWjTX+8ouMbmNCQ==", "2b9e75d3-ac0f-4352-8d9d-32f0ed4ed2b5" });
        }
    }
}
