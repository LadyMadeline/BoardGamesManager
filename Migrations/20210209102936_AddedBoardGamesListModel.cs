using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesManager.Migrations
{
    public partial class AddedBoardGamesListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BoardGameViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "BoardGameViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "BoardGameViewModel");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "BoardGameViewModel",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
