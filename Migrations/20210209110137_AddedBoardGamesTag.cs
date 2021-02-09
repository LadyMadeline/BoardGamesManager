﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesManager.Migrations
{
    public partial class AddedBoardGamesTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameDataBaseModelHuy");

            migrationBuilder.DropTable(
                name: "Huys");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGamesTag");

            migrationBuilder.CreateTable(
                name: "Huys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameDataBaseModelHuy",
                columns: table => new
                {
                    BoardGamesListId = table.Column<int>(type: "int", nullable: false),
                    BoardGamesListId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameDataBaseModelHuy", x => new { x.BoardGamesListId, x.BoardGamesListId1 });
                    table.ForeignKey(
                        name: "FK_BoardGameDataBaseModelHuy_BoardGame_BoardGamesListId",
                        column: x => x.BoardGamesListId,
                        principalTable: "BoardGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameDataBaseModelHuy_Huys_BoardGamesListId1",
                        column: x => x.BoardGamesListId1,
                        principalTable: "Huys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameDataBaseModelHuy_BoardGamesListId1",
                table: "BoardGameDataBaseModelHuy",
                column: "BoardGamesListId1");
        }
    }
}
