using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameViewModel : BoardGameBaseEntity
    {
        [DisplayName("Image")]
        
        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        public BoardGameViewModel()
        {

        }

        public BoardGameViewModel(string imagePath, string title, string gameDuration, string recomendedAge, string numbersOfPlayers, double price, string description, string linkToStore)
            : base(title, gameDuration, recomendedAge, numbersOfPlayers, price, description, linkToStore)
        {
            this.ImagePath = imagePath;
        }

        public BoardGameViewModel(int id, string imagePath, string title, string gameDuration, string recomendedAge, string numbersOfPlayers, double price, string description, string linkToStore)
            : base(title, gameDuration, recomendedAge, numbersOfPlayers, price, description, linkToStore)
        {
            this.ImagePath = imagePath;
            this.Id = id;
        }
    }
}
