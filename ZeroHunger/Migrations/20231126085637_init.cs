using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZeroHunger.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminUsername = table.Column<string>(type: "text", nullable: false),
                    adminPassword = table.Column<string>(type: "text", nullable: false),
                    adminPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminUsername);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    appName = table.Column<string>(type: "text", nullable: false),
                    appPhone = table.Column<string>(type: "text", nullable: false),
                    appAddress = table.Column<string>(type: "text", nullable: false),
                    applyDate = table.Column<string>(type: "text", nullable: false),
                    appStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    empUserName = table.Column<string>(type: "text", nullable: false),
                    empPassword = table.Column<string>(type: "text", nullable: false),
                    empName = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    empPhone = table.Column<string>(type: "text", nullable: false),
                    empAddress = table.Column<string>(type: "text", nullable: false),
                    joinningDate = table.Column<string>(type: "text", nullable: false),
                    completedReq = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.empUserName);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    restUserName = table.Column<string>(type: "text", nullable: false),
                    restPassword = table.Column<string>(type: "text", nullable: false),
                    restName = table.Column<string>(type: "text", nullable: false),
                    restPhone = table.Column<string>(type: "text", nullable: false),
                    restLocation = table.Column<string>(type: "text", nullable: false),
                    registratineDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.restUserName);
                });

            migrationBuilder.CreateTable(
                name: "CollectRequest",
                columns: table => new
                {
                    reqId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    foodType = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<string>(type: "text", nullable: false),
                    reqPosted = table.Column<string>(type: "text", nullable: false),
                    maxPreservationTime = table.Column<string>(type: "text", nullable: false),
                    empUsername = table.Column<string>(type: "text", nullable: false),
                    restUserName = table.Column<string>(type: "text", nullable: false),
                    reqStarus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectRequest", x => x.reqId);
                    table.ForeignKey(
                        name: "FK_CollectRequest_Restaurant_restUserName",
                        column: x => x.restUserName,
                        principalTable: "Restaurant",
                        principalColumn: "restUserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectRequest_restUserName",
                table: "CollectRequest",
                column: "restUserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "CollectRequest");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
