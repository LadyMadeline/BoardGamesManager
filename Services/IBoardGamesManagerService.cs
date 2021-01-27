using BoardGamesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Services
{
    public interface IBoardGamesManagerService
    {
        public List<BoardGameViewModel> GetBoardGames();
        public BoardGameViewModel GetBoardGame(int id);
        public void AddBoardGame(string image, string title, string gameDuration, string recomendenAge, string numberOfPlayers, double price, string description, string linkToStore);
        public void DeleteBoardGame(int id);
        public void EditBoardGame(int id, string image, string title, string gameDuration, string recomendenAge, string numberOfPlayers, double price, string description, string linkToStore);
    }
}
