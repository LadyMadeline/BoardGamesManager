using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Models;

namespace BoardGamesManager.Data
{
    public class BoardGamesManagerContext : DbContext
    {
        public BoardGamesManagerContext(DbContextOptions<BoardGamesManagerContext> options)
            : base(options)
        {
        }

        public DbSet<BoardGameDataBaseModel> BoardGame { get; set; }
        public DbSet<BoardGamesTagModel> BoardGamesTag { get; set; }
    }
}
