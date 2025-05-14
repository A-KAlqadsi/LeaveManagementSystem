using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ddcbe1-9eed-4999-8bd1-62ba82b299d5\r\n");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirht",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44ddcbe1-9eed-4999-8bd1-62ba82b299d5", null, "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92da7035-5c36-4e70-80e0-ec40af95f29d",
                columns: new[] { "ConcurrencyStamp", "DateOfBirht", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78d0fb9-4c13-479d-b4bc-7a31547a0aef", new DateOnly(2004, 11, 4), "Default", "Admin", "AQAAAAIAAYagAAAAEIXsk5rOgpn1BTu7UGKZd3oLu181GqKh8Xqds/xyM+b/ExbordjB+UTMzE9BbonJJw==", "13fd618b-5cc6-406b-9cce-59db2483e3da" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ddcbe1-9eed-4999-8bd1-62ba82b299d5");

            migrationBuilder.DropColumn(
                name: "DateOfBirht",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44ddcbe1-9eed-4999-8bd1-62ba82b299d5\r\n", null, "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92da7035-5c36-4e70-80e0-ec40af95f29d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6d33adc-b104-48b2-a237-3c84bfe0429a", "AQAAAAIAAYagAAAAEJNIcvzqnqWTy6XR3x9Axb2d4+/XvAIFGB4s5aySHPWXNGRA58rnoEVBaIvZFYcv+A==", "30870215-1cc3-48d0-b255-5f57ac8759fe" });
        }
    }
}
