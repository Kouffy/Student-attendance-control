using System;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MiniProjet_alpha.Controllers
{
    public class MatiereController : Controller
    {
        private readonly miniprojetContext _context;
        public MatiereController(miniprojetContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matiere.ToListAsync());
        }
          public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matieres = await _context.Matiere
                .FirstOrDefaultAsync(m => m.IdMatiere == id);
            if (matieres == null)
            {
                return NotFound();
            }

            return View(matieres);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle")] Model.Matiere Matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Matiere);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Matieres = await _context.Matiere.FindAsync(id);
            if (Matieres == null)
            {
                return NotFound();
            }
            return View(Matieres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatiere,Libelle")] Model.Matiere Matiere)
        {
            if (id != Matiere.IdMatiere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(Matiere.IdMatiere))
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
            return View(Matiere);
        }
           
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matieres = await _context.Matiere
                .FirstOrDefaultAsync(m => m.IdMatiere == id);
            if (matieres == null)
            {
                return NotFound();
            }

            return View(matieres);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matieres = await _context.Matiere.FindAsync(id);
            _context.Matiere.Remove(matieres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool MatiereExists(int id)
        {
            return _context.Matiere.Any(e => e.IdMatiere == id);
        }
    }
}