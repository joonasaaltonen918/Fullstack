using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlan1.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Host",
                table: "Event",
                newName: "EventDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Event",
                newName: "Host");
        }
    }
}
