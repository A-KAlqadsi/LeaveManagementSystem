using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43609b62-813a-4c0c-be99-f6945346c591", null, "Supervisor", "SUPERVISOR" },
                    { "44ddcbe1-9eed-4999-8bd1-62ba82b299d5\r\n", null, "Employee", "EMPLOYEE" },
                    { "5d168a9c-5a99-4204-8dbe-07f2447797d0", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92da7035-5c36-4e70-80e0-ec40af95f29d", 0, "a6d33adc-b104-48b2-a237-3c84bfe0429a", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEJNIcvzqnqWTy6XR3x9Axb2d4+/XvAIFGB4s5aySHPWXNGRA58rnoEVBaIvZFYcv+A==", null, false, "30870215-1cc3-48d0-b255-5f57ac8759fe", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d168a9c-5a99-4204-8dbe-07f2447797d0", "92da7035-5c36-4e70-80e0-ec40af95f29d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43609b62-813a-4c0c-be99-f6945346c591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ddcbe1-9eed-4999-8bd1-62ba82b299d5\r\n");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d168a9c-5a99-4204-8dbe-07f2447797d0", "92da7035-5c36-4e70-80e0-ec40af95f29d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d168a9c-5a99-4204-8dbe-07f2447797d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92da7035-5c36-4e70-80e0-ec40af95f29d");
        }
    }
}
