using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddUserSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 10, 12, 20, 42, 23, 826, DateTimeKind.Utc).AddTicks(365), "R+JkA1kEfjE6ow8WTuy65p2Yjp2xvcWG7rgF5n0Z52n7dXOiyMmyRZmqXKCMjzCY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 10, 12, 20, 34, 28, 372, DateTimeKind.Utc).AddTicks(4686), "rVLu/5Lfxh037NkVnvY9wllFWoXw3RDBCw+Ed0zCwFQ/m+8kw0KNTIuZZ5U3J4AK" });
        }
    }
}
