using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lavajato.Data;
using lavajato.Models;

namespace lavajato.Controllers
{
    public class LavagemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LavagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lavagem
        public async Task<IActionResult> Index()
        {
              return _context.Lavagem != null ? 
                          View(await _context.Lavagem.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Lavagem'  is null.");
        }

        // GET: Lavagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lavagem == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem
                .FirstOrDefaultAsync(m => m.CodLav == id);
            if (lavagem == null)
            {
                return NotFound();
            }

            return View(lavagem);
        }

        // GET: Lavagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lavagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodLav,DataLav,ValorLav,CodCarro,CodTipoLav")] Lavagem lavagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lavagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lavagem);
        }

        // GET: Lavagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lavagem == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem.FindAsync(id);
            if (lavagem == null)
            {
                return NotFound();
            }
            return View(lavagem);
        }

        // POST: Lavagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodLav,DataLav,ValorLav,CodCarro,CodTipoLav")] Lavagem lavagem)
        {
            if (id != lavagem.CodLav)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LavagemExists(lavagem.CodLav))
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
            return View(lavagem);
        }

        // GET: Lavagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lavagem == null)
            {
                return NotFound();
            }

            var lavagem = await _context.Lavagem
                .FirstOrDefaultAsync(m => m.CodLav == id);
            if (lavagem == null)
            {
                return NotFound();
            }

            return View(lavagem);
        }

        // POST: Lavagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lavagem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lavagem'  is null.");
            }
            var lavagem = await _context.Lavagem.FindAsync(id);
            if (lavagem != null)
            {
                _context.Lavagem.Remove(lavagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LavagemExists(int id)
        {
          return (_context.Lavagem?.Any(e => e.CodLav == id)).GetValueOrDefault();
        }
    }
}
