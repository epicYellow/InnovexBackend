using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace InnovexBackend.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

           // migrationBuilder.CreateTable(
             //   name: "Staff",
               // columns: table => new
                //{
                  //  Id = table.Column<int>(type: "int", nullable: false)
                    //    .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    //Username = table.Column<string>(type: "longtext", nullable: false),
                    //Password = table.Column<string>(type: "longtext", nullable: false),
                    //Fullname = table.Column<string>(type: "longtext", nullable: false),
                    //Email = table.Column<string>(type: "longtext", nullable: false),
                    //RoleTitle = table.Column<string>(type: "longtext", nullable: false),
                    //IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                //},
                //constraints: table =>
                //{
                 //   table.PrimaryKey("PK_Staff", x => x.Id);
                //})
                //.Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Transaction_type = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    Date_and_time = table.Column<string>(type: "longtext", nullable: false),
                    Transaction_fee = table.Column<float>(type: "float", nullable: false),
                    Account_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DropTable(
            //    name: "Staff");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
