using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsApplication.Migrations
{
    public partial class add1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "TestLists",
                newName: "coachId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AllAthleteLists",
                newName: "coachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "coachId",
                table: "TestLists",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "coachId",
                table: "AllAthleteLists",
                newName: "userId");
        }
    }
}
