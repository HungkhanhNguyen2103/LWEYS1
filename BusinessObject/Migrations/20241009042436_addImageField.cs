using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addImageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3dad4f1-a4ee-4192-b5f1-0f2609100b0d", "AQAAAAIAAYagAAAAELgUpdske/ro7+IqUJnRbnSUk+Ke3TLmQl1ge6uhVI5YA5pIOZHrYbWZy9faPTatGw==", "20b11ca4-ff83-478d-aae9-e63d85d01e96" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7434a0db-9230-4bf7-9c42-37e2cd39c80e", "AQAAAAIAAYagAAAAEO7rsn3fiZykpBxRoJ1STV44ubqq5y3W61wP7RMSnuKgybQecDeRe5vxej2Ds2IGYA==", "dd71affd-d9fb-46c0-ae41-0ee0553b046c" });
        }
    }
}
