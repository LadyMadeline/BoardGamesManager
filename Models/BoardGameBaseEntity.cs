using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GameDuration { get; set; }
        public int RecomendedAge { get; set; }
        public string NumberOfPlayers { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string LinkToStore { get; set; }
    }
}
