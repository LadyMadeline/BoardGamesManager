using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameBaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Game duration")]
        public string GameDuration { get; set; }

        [DisplayName("Recomended age")]
        public int RecomendedAge { get; set; }

        [DisplayName("Number of players")]
        public string NumberOfPlayers { get; set; }

        [DisplayName("Price")]
        public double Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Link to store")]
        public string LinkToStore { get; set; }

        public BoardGameBaseEntity()
        {

        }

        public BoardGameBaseEntity(string title, string gameDuration, int recomendedAge, string numbersOfPlayers, double price, string description, string linkToStore)
        {
            this.Title = title;
            this.GameDuration = gameDuration;
            this.RecomendedAge = recomendedAge;
            this.NumberOfPlayers = numbersOfPlayers;
            this.Price = price;
            this.Description = description;
            this.LinkToStore = linkToStore;
        }
    }
}
