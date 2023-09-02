using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovexBackend.Migrations
{
    /// <inheritdoc />
    public partial class ClientNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client_name",
                table: "Accounts",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client_name",
                table: "Accounts");
        }
    }
}
