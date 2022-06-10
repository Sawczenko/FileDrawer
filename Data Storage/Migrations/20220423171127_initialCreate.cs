using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorage.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Drawers");

            migrationBuilder.EnsureSchema(
                name: "Files");

            migrationBuilder.CreateTable(
                name: "Drawers",
                schema: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    DrawerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalSchema: "Drawers",
                        principalTable: "Drawers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_Name",
                schema: "Drawers",
                table: "Drawers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DrawerId",
                schema: "Files",
                table: "Files",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Name",
                schema: "Files",
                table: "Files",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "Drawers",
                schema: "Drawers");
        }
    }
}
