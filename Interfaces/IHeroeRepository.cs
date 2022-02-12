using Heroes.Models;

namespace Heroes.Interfaces
{
    public interface IHeroeRepository
    {
        public Task<IEnumerable<Heroe>> GetHeroes();
        public Task<Heroe> GetHeroe(int id);
        public Task PostHeroe(Heroe heroe);
        public Task<bool> DeleteHeroe(Heroe heroe);
        public Task<bool> UpdateHero(Heroe heroe);
    }
}
