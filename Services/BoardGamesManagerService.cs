using BoardGamesManager.Data;
using BoardGamesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BoardGamesManager.Services
{
    public class BoardGamesManagerService : IBoardGamesManagerService
    {
        public BoardGamesManagerContext BoardGameContext { get; set; }

        public BoardGamesManagerService(BoardGamesManagerContext context)
        {
            this.BoardGameContext = context;
        }

        public List<BoardGameViewModel> GetBoardGames()
        {
            
            return BoardGameContext.BoardGame.ToList()
                .Select(boardGame => new BoardGameViewModel(boardGame.Id, boardGame.Image, boardGame.Title, boardGame.GameDuration, boardGame.RecomendedAge, boardGame.NumberOfPlayers, boardGame.Price, boardGame.Description, boardGame.LinkToStore))
                .ToList();
        }

        public BoardGameViewModel GetBoardGame(int id)
        {
            BoardGameDataBaseModel boardGame = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            BoardGameViewModel boardGameView = new BoardGameViewModel(boardGame.Id, boardGame.Image, boardGame.Title, boardGame.GameDuration, boardGame.RecomendedAge, boardGame.NumberOfPlayers, boardGame.Price, boardGame.Description, boardGame.LinkToStore);
            return boardGameView;
        }

        public void AddBoardGame(string image, BoardGameViewModel boardGameViewModel)
        {
            BoardGameDataBaseModel boardGame = new BoardGameDataBaseModel(image, boardGameViewModel.Title, boardGameViewModel.GameDuration, boardGameViewModel.RecomendedAge, boardGameViewModel.NumberOfPlayers, boardGameViewModel.Price, boardGameViewModel.Description, boardGameViewModel.LinkToStore);
            BoardGameContext.Add<BoardGameDataBaseModel>(boardGame);
            BoardGameContext.SaveChanges();
        }

        public void DeleteBoardGame(int id)
        {
            BoardGameDataBaseModel item = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            BoardGameContext.Remove(item);
            BoardGameContext.SaveChanges();
        }

        public void EditBoardGame(int id, BoardGameViewModel boardGameViewModel)
        {
            BoardGameDataBaseModel item = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            item.Title = boardGameViewModel.Title;
            item.GameDuration = boardGameViewModel.GameDuration;
            item.RecomendedAge = boardGameViewModel.RecomendedAge;
            item.NumberOfPlayers = boardGameViewModel.NumberOfPlayers;
            item.Price = boardGameViewModel.Price;
            item.Description = boardGameViewModel.Description;
            item.LinkToStore = boardGameViewModel.LinkToStore;
            BoardGameContext.Update(item);
            BoardGameContext.SaveChanges();
        }

        public void EditBoardGame(int id, string imagePath, BoardGameViewModel boardGameViewModel)
        {
            BoardGameDataBaseModel item = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            item.Image = imagePath;
            item.Title = boardGameViewModel.Title;
            item.GameDuration = boardGameViewModel.GameDuration;
            item.RecomendedAge = boardGameViewModel.RecomendedAge;
            item.NumberOfPlayers = boardGameViewModel.NumberOfPlayers;
            item.Price = boardGameViewModel.Price;
            item.Description = boardGameViewModel.Description;
            item.LinkToStore = boardGameViewModel.LinkToStore;
            BoardGameContext.Update(item);
            BoardGameContext.SaveChanges();
        }
    }
}
