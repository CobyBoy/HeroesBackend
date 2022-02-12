using Heroes.Interfaces;
using Heroes.Models;
using Heroes.Data;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Repositories
{
    public class HeroeRepository : IHeroeRepository
    {
        private readonly HeroesContext _context;
        public HeroeRepository(HeroesContext context) 
        {
            this._context = context;
        }


        public async Task<IEnumerable<Heroe>> GetHeroes()
        {
            return await _context.Heroe.ToListAsync();
        }

        public async Task<Heroe> GetHeroe(int id)
        {
            var hero = await _context.Heroe.FindAsync(id);
            return hero;
        }

        public async Task<bool> UpdateHero(Heroe heroe)
        {
            var currentHero = await _context.Heroe.FindAsync(heroe.Id);
            if (currentHero != null)
            {
                currentHero.Id = heroe.Id;
                currentHero.Name = heroe.Name;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task PostHeroe(Heroe heroe)
        {
            _context.Heroe.Add(heroe);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteHeroe(Heroe heroe)
        {
            _context.Heroe.Remove(heroe);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
