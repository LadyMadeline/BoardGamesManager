﻿using BoardGamesManager.Data;
using BoardGamesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public List<BoardGameViewModel> GetBoardGames()
        {
            return BoardGameContext.BoardGame.ToList()
                .Select(boardGame => new BoardGameViewModel(boardGame.Id, null, boardGame.Title, boardGame.GameDuration, boardGame.RecomendedAge, boardGame.NumberOfPlayers, boardGame.Price, boardGame.Description, boardGame.LinkToStore))
                .ToList();
        }

        public BoardGameViewModel GetBoardGame(int id)
        {
            BoardGameDataBaseModel boardGame = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            BoardGameViewModel boardGameView = new BoardGameViewModel(boardGame.Id, null, boardGame.Title, boardGame.GameDuration, boardGame.RecomendedAge, boardGame.NumberOfPlayers, boardGame.Price, boardGame.Description, boardGame.LinkToStore);
            return boardGameView;
        }

        public void AddBoardGame(string image, string title, string gameDuration, string recomendenAge, string numberOfPlayers, double price, string description, string linkToStore)
        {
            BoardGameDataBaseModel boardGame = new BoardGameDataBaseModel(image, title, gameDuration, recomendenAge, numberOfPlayers, price, description, linkToStore);
            BoardGameContext.Add<BoardGameDataBaseModel>(boardGame);
            BoardGameContext.SaveChanges();
        }

        public void DeleteBoardGame(int id)
        {
            BoardGameDataBaseModel item = BoardGameContext.Find<BoardGameDataBaseModel>(id);
            BoardGameContext.Remove(item);
            BoardGameContext.SaveChanges();
        }
    }
}
