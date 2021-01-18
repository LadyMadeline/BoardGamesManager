using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameViewModel : BoardGameBaseEntity
    {
        [DisplayName("Image")]
        public byte[] Image { get; set; }

        public BoardGameViewModel()
        {

        }

        public BoardGameViewModel(byte[] image, string title, string gameDuration, string recomendedAge, string numbersOfPlayers, double price, string description, string linkToStore)
            : base(title, gameDuration, recomendedAge, numbersOfPlayers, price, description, linkToStore)
        {
            this.Image = image;
        }
    }
}
