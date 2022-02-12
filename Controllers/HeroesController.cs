#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;
using Heroes.Interfaces;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroesContext _context;
        private readonly IHeroeRepository _heroRepository;

        public HeroesController(HeroesContext context, IHeroeRepository heroeRepository)
        {
            _context = context;
            this._heroRepository = heroeRepository; 
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroes()
        {
            var heroes = await _heroRepository.GetHeroes();
            return heroes.ToList();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetHeroe(int id)
        {
            var heroe = await _heroRepository.GetHeroe(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroe(int id, Heroe heroe)
        {
            if (id != heroe.Id)
            {
                return BadRequest();
            }
            var result = await _heroRepository.UpdateHero(heroe);

            return Ok(result);
        }

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Heroe>> PostHeroe(Heroe heroe)
        {
            if(HeroeExists(heroe.Id))
            {
                return BadRequest(); //I don't know what to return
            }
            await _heroRepository.PostHeroe(heroe);  

            return CreatedAtAction("GetHeroe", new { id = heroe.Id }, heroe);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(int id)
        {
            var heroe = await _heroRepository.GetHeroe(id);
            if (heroe == null)
            {
                return NotFound();
            }

            var result = await _heroRepository.DeleteHeroe(heroe); 

            return Ok(result);
        }

        private bool HeroeExists(int id)
        {
            return _context.Heroe.Any(e => e.Id == id);
        }
    }
}
