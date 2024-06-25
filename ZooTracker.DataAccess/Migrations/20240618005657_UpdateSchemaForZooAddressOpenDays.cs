using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaForZooAddressOpenDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.EnsureSchema(
                name: "Zoo");

            migrationBuilder.RenameTable(
                name: "Zoos",
                newName: "Zoos",
                newSchema: "Zoo");

            migrationBuilder.RenameTable(
                name: "OpenDaysHours",
                newName: "OpenDaysHours",
                newSchema: "Zoo");

            migrationBuilder.CreateTable(
                name: "ZooAddress",
                schema: "Zoo",
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
                    table.PrimaryKey("PK_ZooAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZooAddress_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalSchema: "Zoo",
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZooAddress_ZooId",
                schema: "Zoo",
                table: "ZooAddress",
                column: "ZooId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZooAddress",
                schema: "Zoo");

            migrationBuilder.RenameTable(
                name: "Zoos",
                schema: "Zoo",
                newName: "Zoos");

            migrationBuilder.RenameTable(
                name: "OpenDaysHours",
                schema: "Zoo",
                newName: "OpenDaysHours");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZooId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZooId",
                table: "Address",
                column: "ZooId",
                unique: true);
        }
    }
}
