using BoardGamesManager.Data;
using BoardGamesManager.Models;
using BoardGamesManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Controllers
{
    public class BoardGamesManagerController : Controller
    {
        public BoardGamesManagerService BoardGamesService { get; set; }

        public BoardGamesManagerController(BoardGamesManagerContext context)
        {
            this.BoardGamesService = new BoardGamesManagerService(context);
        }

        [HttpGet("/")]
        public IActionResult BoardGames()
        {
            return View(BoardGamesService.GetBoardGames());
        }

        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(byte[] Image, string Title, string GameDuration, int RecomendedAge, string NumberOfPlayers, double Price, string Description, string LinkToStore)
        {
            BoardGamesService.AddBoardGame(Image, Title, GameDuration, RecomendedAge, NumberOfPlayers, Price, Description, LinkToStore);
            return View("BoardGames", BoardGamesService.GetBoardGames());
        }

        public IActionResult DeleteItem(int id)
        {
            BoardGamesService.DeleteBoardGame(id);
            return View("BoardGames", BoardGamesService.GetBoardGames());
        }
    }
}
