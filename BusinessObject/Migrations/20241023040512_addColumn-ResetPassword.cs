using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "UserQuestion",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminMessage",
                table: "UserQuestion",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Service",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Feedbacks",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResetPassword",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ResetPassword", "SecurityStamp" },
                values: new object[] { "cfaeb268-c916-420c-981f-8609be5e4385", "AQAAAAIAAYagAAAAEIMu3M5Ax+03zdjebTArXJq1J9FsTsxGLlsbl5STMp+0v9erJo9O6iphuxeVd8vj8g==", 0, "582567f2-3d46-40dc-a68b-78148dcb7815" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ResetPassword", "SecurityStamp" },
                values: new object[] { "f7da7bec-1bf7-42b8-b932-562e54eb0547", "AQAAAAIAAYagAAAAEH1OQEAIBSyhNZqgodcHQ67f1j3av1WhrcwQ15NfqYSFDcaSYXy54WjJ0g1n4GltuQ==", 0, "5c15c7c8-1ee9-4ab3-af06-f494bfa4d873" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPassword",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "UserQuestion",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminMessage",
                table: "UserQuestion",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Service",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Feedbacks",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ac10293-62a2-4cf1-a631-abc479487211", "AQAAAAIAAYagAAAAEA6T2QB5Fu5YxktVovP3NJmwc3HETq85p0thJhjUfeTxVY09lzl3oVYieYwLXuQ4YQ==", "7f13cbb0-04ce-497c-bff9-4fc07ec21a0a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "addc4821-08cb-4656-ac65-a8991f7221ef", "AQAAAAIAAYagAAAAEMkcan+uucthihuB4jA40wP1PdlCmbOdUXGNVf+cz1XlMSvTVoG0XMFnFxxMFDJWPg==", "90950c34-03e5-46ba-8cb6-860d5d306860" });
        }
    }
}
