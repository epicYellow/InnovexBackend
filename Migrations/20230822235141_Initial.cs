using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace InnovexBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "AccountTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        Type_name = table.Column<string>(type: "longtext", nullable: false),
            //        Transaction_fee = table.Column<float>(type: "float", nullable: false),
            //        Annual_interest_rate = table.Column<float>(type: "float", nullable: false),
            //        Free_limit = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountTypes", x => x.Id);
            //    })
            //    .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    First_name = table.Column<string>(type: "longtext", nullable: false),
                    Last_name = table.Column<string>(type: "longtext", nullable: false),
                    Id_number = table.Column<string>(type: "longtext", nullable: false),
                    Date_of_birth = table.Column<string>(type: "longtext", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Phone_number = table.Column<string>(type: "longtext", nullable: false),
                    Employment_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Monthly_income = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        //    migrationBuilder.CreateTable(
        //        name: "Staff",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
        //            Username = table.Column<string>(type: "longtext", nullable: false),
        //            Password = table.Column<string>(type: "longtext", nullable: false),
        //            Fullname = table.Column<string>(type: "longtext", nullable: false),
        //            Email = table.Column<string>(type: "longtext", nullable: false),
        //            RoleTitle = table.Column<string>(type: "longtext", nullable: false),
        //            IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Staff", x => x.Id);
        //        })
        //        .Annotation("MySQL:Charset", "utf8mb4");
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            //migrationBuilder.DropTable(
            //    name: "Staff");
        }
    }
}
