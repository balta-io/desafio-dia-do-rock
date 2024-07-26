using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioDiaDoRock.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                INSERT INTO [User] (Name, Email, Password, CreatedAt, Roles)
                VALUES ('Admin', 'admin@example.com', '1234567890', GETUTCDATE(), 'Admin')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");
        }
    }
}
