using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguage",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test 1" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguage",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Test 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguage");
        }
    }
}
