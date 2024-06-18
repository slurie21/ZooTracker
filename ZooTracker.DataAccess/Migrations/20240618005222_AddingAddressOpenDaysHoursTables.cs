using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingAddressOpenDaysHoursTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ChildTicket",
                table: "Zoos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainAttraction",
                table: "Zoos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SeniorTicket",
                table: "Zoos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TicketCost",
                table: "Zoos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenDaysHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    CloseTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenDaysHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenDaysHours_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZooId",
                table: "Address",
                column: "ZooId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenDaysHours_ZooId",
                table: "OpenDaysHours",
                column: "ZooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OpenDaysHours");

            migrationBuilder.DropColumn(
                name: "ChildTicket",
                table: "Zoos");

            migrationBuilder.DropColumn(
                name: "MainAttraction",
                table: "Zoos");

            migrationBuilder.DropColumn(
                name: "SeniorTicket",
                table: "Zoos");

            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "Zoos");
        }
    }
}
