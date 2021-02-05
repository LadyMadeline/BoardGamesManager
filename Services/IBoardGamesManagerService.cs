using BoardGamesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Services
{
    public interface IBoardGamesManagerService
    {
        public IEnumerable<BoardGameViewModel> GetBoardGames();
        public BoardGameViewModel GetBoardGame(int id);
        public void AddBoardGame(string image, BoardGameViewModel boardGameViewModel);
        public void DeleteBoardGame(int id);
        public void EditBoardGame(int id, BoardGameViewModel boardGameViewModel);
        public void EditBoardGame(int id, string imagePath, BoardGameViewModel boardGameViewModel);
    }
}
