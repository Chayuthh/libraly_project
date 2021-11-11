using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libraly.Migrations
{
    public partial class Initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "libralyModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libralyModels", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "libralyModels");
        }
    }
}
