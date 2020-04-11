using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;

namespace MiniProjet_alpha.Controllers
{
   public class SeanceController : Controller
    {
        private readonly miniprojetContext _context;
        public SeanceController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seance.ToListAsync());
        }
         public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seances = await _context.Seance
                .FirstOrDefaultAsync(m => m.IdSeance == id);
            if (seances == null)
            {
                return NotFound();
            }

            return View(seances);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dateseance,Heuredebut,Heurefin,ClasseId,ProfesseurId,SalleId")] Model.Seance Seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Seance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Seance);
        }
         public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seances = await _context.Seance.FindAsync(id);
            if (seances == null)
            {
                return NotFound();
            }
            return View(seances);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSeance,Dateseance,Heuredebut,Heurefin,ClasseId,ProfesseurId")] Model.Seance seance)
        {
            if (id != seance.IdSeance)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.IdSeance))
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
            return View(seance);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Seance = await _context.Seance
                .FirstOrDefaultAsync(m => m.IdSeance == id);
            if (Seance == null)
            {
                return NotFound();
            }
            return View(Seance);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seances = await _context.Seance.FindAsync(id);
            _context.Seance.Remove(seances);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.IdSeance == id);
        }
    }
}
