using BoardGamesManager.Data;
using BoardGamesManager.Models;
using BoardGamesManager.Services;
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
        public BoardGamesManagerService BoardGamesService { get; set; }
        public IWebHostEnvironment HostEnvironment { get; }

        public BoardGamesManagerController(BoardGamesManagerContext context, IWebHostEnvironment hostEnvironment)
        {
            this.BoardGamesService = new BoardGamesManagerService(context);
            HostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> CreateItem([Bind("Image, Title, GameDuration, RecomendedAge, NumberOfPlayers, Price, Description, LinkToStore")] BoardGameViewModel boardGameViewModel)
        {
            string wwwRootPath = Path.GetRelativePath(HostEnvironment.WebRootPath, "BoardGamesManager/wwwroot");
            string fileName = Path.GetFileNameWithoutExtension(boardGameViewModel.Image.FileName) + DateTime.Now.ToString("yymmssfff");
            string extension = Path.GetExtension(boardGameViewModel.Image.FileName);
            fileName = fileName + extension;
            string path = Path.Combine(wwwRootPath + "/image/", fileName);

            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                await boardGameViewModel.Image.CopyToAsync(fileStream);
            }

            BoardGamesService.AddBoardGame(Path.Combine("/image/", fileName), boardGameViewModel.Title, boardGameViewModel.GameDuration, boardGameViewModel.RecomendedAge, boardGameViewModel.NumberOfPlayers, boardGameViewModel.Price, boardGameViewModel.Description, boardGameViewModel.LinkToStore);
            return View("BoardGames", BoardGamesService.GetBoardGames());
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
            string imagePath = Path.Combine(wwwRootPath + boardGame.ImagePath);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            
            BoardGamesService.DeleteBoardGame(id);
            return View("BoardGames", BoardGamesService.GetBoardGames());
        }


        public IActionResult DetailsItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            return View("DetailsItem", boardGame);
        }

        public IActionResult EditItem(int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);
            ViewBag.BoardGameTitle = boardGame.Title;
            ViewBag.GameDuration = boardGame.GameDuration;
            ViewBag.RecomendedAge = boardGame.RecomendedAge;
            ViewBag.NumberOfPlayers = boardGame.NumberOfPlayers;
            ViewBag.Price = boardGame.Price;
            ViewBag.Description = boardGame.Description;
            ViewBag.LinkToStore = boardGame.LinkToStore;
            return View("EditItem");
        }

        [HttpPost]
        public async Task<IActionResult> EditItem([Bind("Image, Title, GameDuration, RecomendedAge, NumberOfPlayers, Price, Description, LinkToStore")] BoardGameViewModel boardGameViewModel, int id)
        {
            BoardGameViewModel boardGame = BoardGamesService.GetBoardGame(id);

            if (boardGameViewModel.Image != null)
            {
                string wwwRootPath = Path.GetRelativePath(HostEnvironment.WebRootPath, "BoardGamesManager/wwwroot");
                string fileName = Path.GetFileNameWithoutExtension(boardGameViewModel.Image.FileName) + DateTime.Now.ToString("yymmssfff");
                string extension = Path.GetExtension(boardGameViewModel.Image.FileName);
                fileName += extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                string imagePath = Path.Combine(wwwRootPath + boardGame.ImagePath);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await boardGameViewModel.Image.CopyToAsync(fileStream);
                }

                BoardGamesService.EditBoardGame(id, Path.Combine("/image/", fileName), boardGameViewModel.Title, boardGameViewModel.GameDuration, boardGameViewModel.RecomendedAge, boardGameViewModel.NumberOfPlayers, boardGameViewModel.Price, boardGameViewModel.Description, boardGameViewModel.LinkToStore);
            }

            else
            {
                BoardGamesService.EditBoardGame(id, boardGame.ImagePath, boardGameViewModel.Title, boardGameViewModel.GameDuration, boardGameViewModel.RecomendedAge, boardGameViewModel.NumberOfPlayers, boardGameViewModel.Price, boardGameViewModel.Description, boardGameViewModel.LinkToStore);
            }

            BoardGameViewModel newBoardGame = BoardGamesService.GetBoardGame(id);
            return View("DetailsItem", newBoardGame);
        }
    }
}
