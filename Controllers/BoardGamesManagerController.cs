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
        public IActionResult CreateItem(string image, string title, string gameDuration, string recomendedAge, string numberOfPlayers, double price, string Description, string LinkToStore)
        {
            BoardGamesService.AddBoardGame(image, title, gameDuration, recomendedAge, numberOfPlayers, price, Description, LinkToStore);
            return View("BoardGames", BoardGamesService.GetBoardGames());
        }

        public IActionResult DeleteItem(int id)
        {
            BoardGamesService.DeleteBoardGame(id);
            return View("BoardGames", BoardGamesService.GetBoardGames());
        }


        public IActionResult DetailsItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            return View("DetailsItem", boardGame);
        }
    }
}
