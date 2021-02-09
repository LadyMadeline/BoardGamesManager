using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGamesTagModel
    {
        public int Id { get; set; }
        public string BoardGamesTag { get; set; }
        
        public BoardGamesTagModel()
        {

        }

        public BoardGamesTagModel(string tag)
        {
            BoardGamesTag = tag;
        }
    }
}
