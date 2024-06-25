using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActivetoZoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Zoo",
                table: "Zoos",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Zoo",
                table: "Zoos");
        }
    }
}
