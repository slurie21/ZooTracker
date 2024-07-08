using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                schema: "Zoo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FemaleNum = table.Column<int>(type: "int", nullable: false),
                    MaleNum = table.Column<int>(type: "int", nullable: false),
                    TotalNum = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZooId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalSchema: "Zoo",
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Zoo",
                table: "Zoos",
                columns: new[] { "Id", "ChildTicket", "CreatedBy", "CreatedDate", "IsActive", "MainAttraction", "ModifiedBy", "ModifiedDate", "Name", "SeniorTicket", "TicketCost" },
                values: new object[,]
                {
                    { 1, 15.0, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), true, "Lions", null, null, "CityA Zoo", 20.0, 25.0 },
                    { 2, 18.0, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), true, "Tigers", null, null, "CityB Zoo", 25.0, 30.0 }
                });

            migrationBuilder.InsertData(
                schema: "Zoo",
                table: "Animals",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FemaleNum", "Habitat", "IsActive", "MaleNum", "ModifiedBy", "ModifiedDate", "Name", "TotalNum", "ZooId" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 3, "Savannah", true, 2, null, null, "Lion", 5, 1 },
                    { 2, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Forest", true, 3, null, null, "Tiger", 5, 1 },
                    { 3, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 4, "Grassland", true, 1, null, null, "Elephant", 5, 1 },
                    { 4, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Savannah", true, 2, null, null, "Giraffe", 4, 1 },
                    { 5, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Forest", true, 2, null, null, "Panda", 4, 1 },
                    { 6, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 5, "Arctic", true, 5, null, null, "Penguin", 10, 1 },
                    { 7, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 3, "Savannah", true, 2, null, null, "Lion", 5, 2 },
                    { 8, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Forest", true, 3, null, null, "Tiger", 5, 2 },
                    { 9, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 4, "Grassland", true, 1, null, null, "Elephant", 5, 2 },
                    { 10, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Savannah", true, 2, null, null, "Giraffe", 4, 2 },
                    { 11, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 2, "Forest", true, 2, null, null, "Panda", 4, 2 },
                    { 12, "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), 5, "Arctic", true, 5, null, null, "Penguin", 10, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Zoo",
                table: "OpenDaysHours",
                columns: new[] { "Id", "CloseTime", "DayOfWeek", "IsOpen", "OpenTime", "ZooId" },
                values: new object[,]
                {
                    { 1, new TimeOnly(17, 0, 0), "Monday", true, new TimeOnly(9, 0, 0), 1 },
                    { 2, new TimeOnly(17, 0, 0), "Tuesday", true, new TimeOnly(9, 0, 0), 1 },
                    { 3, new TimeOnly(17, 0, 0), "Wednesday", true, new TimeOnly(9, 0, 0), 1 },
                    { 4, new TimeOnly(17, 0, 0), "Thursday", true, new TimeOnly(9, 0, 0), 1 },
                    { 5, new TimeOnly(17, 0, 0), "Friday", true, new TimeOnly(9, 0, 0), 1 },
                    { 6, new TimeOnly(18, 0, 0), "Saturday", true, new TimeOnly(10, 0, 0), 1 },
                    { 7, new TimeOnly(18, 0, 0), "Sunday", true, new TimeOnly(10, 0, 0), 1 },
                    { 8, new TimeOnly(16, 0, 0), "Monday", true, new TimeOnly(8, 0, 0), 2 },
                    { 9, new TimeOnly(16, 0, 0), "Tuesday", true, new TimeOnly(8, 0, 0), 2 },
                    { 10, new TimeOnly(16, 0, 0), "Wednesday", true, new TimeOnly(8, 0, 0), 2 },
                    { 11, new TimeOnly(16, 0, 0), "Thursday", true, new TimeOnly(8, 0, 0), 2 },
                    { 12, new TimeOnly(16, 0, 0), "Friday", true, new TimeOnly(8, 0, 0), 2 },
                    { 13, new TimeOnly(17, 0, 0), "Saturday", true, new TimeOnly(9, 0, 0), 2 },
                    { 14, new TimeOnly(17, 0, 0), "Sunday", true, new TimeOnly(9, 0, 0), 2 }
                });

            migrationBuilder.InsertData(
                schema: "Zoo",
                table: "ZooAddress",
                columns: new[] { "Id", "City", "CreateBy", "CreatedDate", "IsActive", "State", "Street1", "Street2", "Zip", "ZooId" },
                values: new object[,]
                {
                    { 1, "CityA", "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), true, "StateA", "123 Zoo St", null, "12345", 1 },
                    { 2, "CityB", "Admin", new DateTime(2024, 7, 3, 15, 0, 31, 816, DateTimeKind.Utc).AddTicks(6609), true, "StateB", "456 Zoo Ln", null, "67890", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Name_ZooId",
                schema: "Zoo",
                table: "Animals",
                columns: new[] { "Name", "ZooId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooId",
                schema: "Zoo",
                table: "Animals",
                column: "ZooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals",
                schema: "Zoo");

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "OpenDaysHours",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "ZooAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Zoo",
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
