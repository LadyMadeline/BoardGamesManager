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
        public IActionResult BoardGamesManagerGet()
        {
            var temp = BoardGamesService.GetBoardGames();
            return View("BoardGames", temp);
        }
    }
}
