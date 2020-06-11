using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex3.Models;

namespace Pokedex3.Controllers
{
    public class PokemonesController : Controller
    {
        private readonly pokedex1Context _context;

        public PokemonesController(pokedex1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pokedex1Context = _context.Pokemon.Include(p => p.RegionNavigation).Include(p => p.TipoNavigation);
            return View(await pokedex1Context.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .Include(p => p.RegionNavigation)
                .Include(p => p.TipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        public IActionResult Create()
        {
            ViewData["Region"] = new SelectList(_context.Region, "Id", "Nombre");
            ViewData["Tipo"] = new SelectList(_context.Tipo, "Id", "Tipo1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ataque1,Ataque2,Ataque3,Ataque4,Region,Tipo")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Region"] = new SelectList(_context.Region, "Id", "Nombre", pokemon.Region);
            ViewData["Tipo"] = new SelectList(_context.Tipo, "Id", "Tipo1", pokemon.Tipo);
            return View(pokemon);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            ViewData["Region"] = new SelectList(_context.Region, "Id", "Nombre", pokemon.Region);
            ViewData["Tipo"] = new SelectList(_context.Tipo, "Id", "Tipo1", pokemon.Tipo);
            return View(pokemon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ataque1,Ataque2,Ataque3,Ataque4,Region,Tipo")] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Region"] = new SelectList(_context.Region, "Id", "Nombre", pokemon.Region);
            ViewData["Tipo"] = new SelectList(_context.Tipo, "Id", "Tipo1", pokemon.Tipo);
            return View(pokemon);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .Include(p => p.RegionNavigation)
                .Include(p => p.TipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.Id == id);
        }
    }
}
