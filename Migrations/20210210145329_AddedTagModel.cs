using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesManager.Migrations
{
    public partial class AddedTagModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGamesTag");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGamesTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameDataBaseModelTagModel",
                columns: table => new
                {
                    BoardGamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameDataBaseModelTagModel", x => new { x.BoardGamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BoardGameDataBaseModelTagModel_BoardGame_BoardGamesId",
                        column: x => x.BoardGamesId,
                        principalTable: "BoardGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameDataBaseModelTagModel_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameDataBaseModelTagModel_TagsId",
                table: "BoardGameDataBaseModelTagModel",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameDataBaseModelTagModel");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.CreateTable(
                name: "BoardGamesTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGamesTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGamesTag", x => x.Id);
                });
        }
    }
}
