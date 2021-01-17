using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Models
{
    public class BoardGameViewModel : BoardGameBaseEntity
    {
        public byte[] Image { get; set; }
    }
}
