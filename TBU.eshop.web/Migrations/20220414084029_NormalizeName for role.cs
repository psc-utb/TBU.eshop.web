using Microsoft.EntityFrameworkCore.Migrations;

namespace TBU.eshop.web.Migrations
{
    public partial class NormalizeNameforrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "50dc10b2-cbd9-4ef9-9160-9a8dcdf73527", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "8ae376b8-507f-4a58-9908-43abda7b2cdb", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "72320e38-a37c-4ba9-837e-91fc1fefa158", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "cce94347-aeb6-4320-8e2c-2a44db9fb781", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "4f54c3f1-3883-4565-9f9b-88467ecf39cd", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "57aeb0ce-3339-49df-9078-da94ae513c7d", null });
        }
    }
}
