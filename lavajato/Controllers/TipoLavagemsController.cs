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
    public class TipoLavagemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoLavagemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoLavagems
        public async Task<IActionResult> Index()
        {
              return _context.TipoLavagem != null ? 
                          View(await _context.TipoLavagem.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TipoLavagem'  is null.");
        }

        // GET: TipoLavagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoLavagem == null)
            {
                return NotFound();
            }

            var tipoLavagem = await _context.TipoLavagem
                .FirstOrDefaultAsync(m => m.CodTipoLav == id);
            if (tipoLavagem == null)
            {
                return NotFound();
            }

            return View(tipoLavagem);
        }

        // GET: TipoLavagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoLavagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTipoLav,DescTipoLav,PrecoTipoLav")] TipoLavagem tipoLavagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoLavagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoLavagem);
        }

        // GET: TipoLavagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoLavagem == null)
            {
                return NotFound();
            }

            var tipoLavagem = await _context.TipoLavagem.FindAsync(id);
            if (tipoLavagem == null)
            {
                return NotFound();
            }
            return View(tipoLavagem);
        }

        // POST: TipoLavagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTipoLav,DescTipoLav,PrecoTipoLav")] TipoLavagem tipoLavagem)
        {
            if (id != tipoLavagem.CodTipoLav)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoLavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoLavagemExists(tipoLavagem.CodTipoLav))
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
            return View(tipoLavagem);
        }

        // GET: TipoLavagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoLavagem == null)
            {
                return NotFound();
            }

            var tipoLavagem = await _context.TipoLavagem
                .FirstOrDefaultAsync(m => m.CodTipoLav == id);
            if (tipoLavagem == null)
            {
                return NotFound();
            }

            return View(tipoLavagem);
        }

        // POST: TipoLavagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoLavagem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoLavagem'  is null.");
            }
            var tipoLavagem = await _context.TipoLavagem.FindAsync(id);
            if (tipoLavagem != null)
            {
                _context.TipoLavagem.Remove(tipoLavagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoLavagemExists(int id)
        {
          return (_context.TipoLavagem?.Any(e => e.CodTipoLav == id)).GetValueOrDefault();
        }
    }
}
