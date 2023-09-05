using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovexBackend.Migrations
{
    /// <inheritdoc />
    public partial class Freelimitinaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Free_transactions_left",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Free_transactions_left",
                table: "Accounts");
        }
    }
}
