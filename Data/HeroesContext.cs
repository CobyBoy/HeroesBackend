#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Heroes.Models;

namespace Heroes.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext (DbContextOptions<HeroesContext> options)
            : base(options)
        {
        }

        public DbSet<Heroe> Heroe { get; set; }
    }
}
