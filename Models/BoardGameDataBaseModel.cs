using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameDataBaseModel : BoardGameBaseEntity
    {
        public string Image { get; set; }

        public BoardGameDataBaseModel()
        {

        }

        public BoardGameDataBaseModel(string image, string title, string gameDuration, string recomendedAge, string numbersOfPlayers, double price, string description, string linkToStore) 
            : base(title, gameDuration, recomendedAge, numbersOfPlayers, price, description, linkToStore)
        {
            this.Image = image;
        }
    }
}
