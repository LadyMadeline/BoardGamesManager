using BoardGamesManager.Data;
using BoardGamesManager.Models;
using BoardGamesManager.Services;
using BoardGamesManager.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Controllers
{
    public class BoardGamesManagerController : Controller
    {
        public IBoardGamesManagerService BoardGamesService { get; set; }
        public IWebHostEnvironment HostEnvironment { get; }

        public BoardGamesManagerController(IWebHostEnvironment hostEnvironment, IBoardGamesManagerService boardGamesService)
        {
            this.BoardGamesService = boardGamesService;
            this.HostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult BoardGames(string searchString, SortTypes sort)
        {
            IEnumerable<BoardGameViewModel> boardGames = BoardGamesService.GetBoardGames();
            boardGames = BoardGamesService.Search(searchString, boardGames);
            boardGames = BoardGamesService.Sort(sort, boardGames);

            return View(boardGames);
        }

        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([Bind("Image, Title, GameDuration, RecomendedAge, NumberOfPlayers, Price, Description, LinkToStore")] BoardGameViewModel boardGameViewModel)
        {
            string wwwRootPath = HostEnvironment.WebRootPath;
            string fileName = await FileStorageUtil.CreateFile(wwwRootPath, boardGameViewModel.Image.FileName, boardGameViewModel.Image);
            BoardGamesService.AddBoardGame(Path.Combine("/image/", fileName), boardGameViewModel);
            return Redirect("BoardGames");
        }

        [HttpGet]
        public IActionResult DeleteItemPage (int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            return View("DeleteItem", boardGame);
        }

        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            string wwwRootPath = HostEnvironment.WebRootPath;
            FileStorageUtil.DeleteFile(wwwRootPath, boardGame.ImagePath);
            BoardGamesService.DeleteBoardGame(id);
            return Redirect("BoardGames");
        }


        public IActionResult DetailsItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            return View("DetailsItem", boardGame);
        }

        public IActionResult EditItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            ViewBag.EditedBoardGame = boardGame;
            return View("EditItem");
        }

        [HttpPost]
        public async Task<IActionResult> EditItem([Bind("Image, Title, GameDuration, RecomendedAge, NumberOfPlayers, Price, Description, LinkToStore")] BoardGameViewModel boardGameViewModel, int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);

            if (boardGameViewModel.Image != null)
            {
                string wwwRootPath = HostEnvironment.WebRootPath;
                FileStorageUtil.DeleteFile(wwwRootPath, boardGame.ImagePath);
                string fileName = await FileStorageUtil.CreateFile(wwwRootPath, boardGameViewModel.Image.FileName, boardGameViewModel.Image);
                BoardGamesService.EditBoardGame(id, Path.Combine("/image/", fileName), boardGameViewModel);
            }

            else
            {
                BoardGamesService.EditBoardGame(id, boardGameViewModel);
            }

            return RedirectToAction("BoardGames");
        }

        public IActionResult CreateList()
        {
            return View();
        }

        public IActionResult CreateList(string listName)
        {
            
            return Redirect("List");
        }
    }
}
