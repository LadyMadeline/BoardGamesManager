using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesManager.Migrations
{
    public partial class UpdateRecomendedAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RecomendedAge",
                table: "BoardGame",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "BoardGameViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomendedAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPlayers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkToStore = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "RecomendedAge",
                table: "BoardGame",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
