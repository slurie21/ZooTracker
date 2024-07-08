using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypoZooAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateBy",
                schema: "Zoo",
                table: "ZooAddress",
                newName: "CreatedBy");

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "admin@admin.com", new DateTime(2024, 7, 4, 18, 35, 19, 859, DateTimeKind.Utc).AddTicks(6444) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "Zoo",
                table: "ZooAddress",
                newName: "CreateBy");

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609) });
        }
    }
}
