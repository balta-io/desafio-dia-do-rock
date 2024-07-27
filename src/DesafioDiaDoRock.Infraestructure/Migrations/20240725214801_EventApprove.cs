using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioDiaDoRock.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class EventApprove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approve",
                table: "Event",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approve",
                table: "Event");
        }
    }
}
