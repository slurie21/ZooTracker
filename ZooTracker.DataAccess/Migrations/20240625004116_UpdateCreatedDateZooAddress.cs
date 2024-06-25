using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreatedDateZooAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                schema: "Zoo",
                table: "ZooAddress",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Zoo",
                table: "ZooAddress",
                newName: "Created");
        }
    }
}
