using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawnHolder.Infrastructure.Persistence.Migrations
{
    public partial class BusinessFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Business_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.CreateTable(
                name: "BusinessProfile",
                columns: table => new
                {
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicedAreas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfile", x => x.BusinessId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BusinessProfile_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                principalTable: "BusinessProfile",
                principalColumn: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BusinessProfile_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusinessProfile");

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicedAreas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Business_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "BusinessId");
        }
    }
}
