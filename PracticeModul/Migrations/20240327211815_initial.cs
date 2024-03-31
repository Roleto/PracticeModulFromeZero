using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeModul.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Kast = table.Column<int>(type: "int", nullable: false),
                    HasMount = table.Column<bool>(type: "bit", nullable: false),
                    Exp = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<int>(type: "int", nullable: false),
                    Dex = table.Column<int>(type: "int", nullable: false),
                    Inte = table.Column<int>(type: "int", nullable: false),
                    Vit = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
