using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_SportApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteByTestModel",
                table: "AthleteByTestModel");

            migrationBuilder.RenameTable(
                name: "AthleteByTestModel",
                newName: "AthleteByTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteByTest",
                table: "AthleteByTest",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AthleteList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoachId = table.Column<string>(nullable: true),
                    AthleteName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthleteList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteByTest",
                table: "AthleteByTest");

            migrationBuilder.RenameTable(
                name: "AthleteByTest",
                newName: "AthleteByTestModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteByTestModel",
                table: "AthleteByTestModel",
                column: "Id");
        }
    }
}
