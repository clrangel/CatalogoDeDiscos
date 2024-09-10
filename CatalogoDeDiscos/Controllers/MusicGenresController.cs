using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;

namespace CatalogoDeDiscos.Controllers
{
    public class MusicGenresController : Controller
    {
        private readonly CatalogoDeDiscosContext _context;

        public MusicGenresController(CatalogoDeDiscosContext context)
        {
            _context = context;
        }

        // GET: MusicGenres
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicGenre.ToListAsync());
        }

        // GET: MusicGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicGenre = await _context.MusicGenre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicGenre == null)
            {
                return NotFound();
            }

            return View(musicGenre);
        }

        // GET: MusicGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Genre")] MusicGenre musicGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicGenre);
        }

        // GET: MusicGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicGenre = await _context.MusicGenre.FindAsync(id);
            if (musicGenre == null)
            {
                return NotFound();
            }
            return View(musicGenre);
        }

        // POST: MusicGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Genre")] MusicGenre musicGenre)
        {
            if (id != musicGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicGenreExists(musicGenre.Id))
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
            return View(musicGenre);
        }

        // GET: MusicGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicGenre = await _context.MusicGenre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicGenre == null)
            {
                return NotFound();
            }

            return View(musicGenre);
        }

        // POST: MusicGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicGenre = await _context.MusicGenre.FindAsync(id);
            if (musicGenre != null)
            {
                _context.MusicGenre.Remove(musicGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicGenreExists(int id)
        {
            return _context.MusicGenre.Any(e => e.Id == id);
        }
    }
}
