using BoardGamesManager.Data;
using BoardGamesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Services
{
    public class BoardGamesManagerService
    {
        public BoardGamesManagerContext BoardGameContext { get; set; }

        public BoardGamesManagerService(BoardGamesManagerContext context)
        {
            this.BoardGameContext = context;
        }

        public List<BoardGameDataBaseModel> GetBoardGames()
        {
            return BoardGameContext.BoardGame.ToList();
        }

        public void AddBoardGame(byte[] image, string title, string gameDuration, int recomendenAge, string numberOfPlayers, double price, string description, string linkToStore)
        {
            BoardGameDataBaseModel boardGame = new BoardGameDataBaseModel("d;afjf", title, gameDuration, recomendenAge, numberOfPlayers, price, description, linkToStore);
            BoardGameContext.Add<BoardGameDataBaseModel>(boardGame);
            BoardGameContext.SaveChanges();
        }
    }
}
