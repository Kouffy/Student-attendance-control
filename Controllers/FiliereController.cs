using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using Microsoft.AspNetCore.Authorization;

namespace MiniProjet_alpha.Controllers
{

    [Authorize(Roles = RoleManagement.Adminuser)]
    public class FiliereController : Controller
    {
        private readonly miniprojetContext _context;
        public FiliereController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filiere.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filieres = await _context.Filiere
                .FirstOrDefaultAsync(m => m.IdFiliere == id);
            if (filieres == null)
            {
                return NotFound();
            }

            return View(filieres);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle")] Model.Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiere);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filieres = await _context.Filiere.FindAsync(id);
            if (filieres == null)
            {
                return NotFound();
            }
            return View(filieres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFiliere,Libelle")] Model.Filiere filiere)
        {
            if (id != filiere.IdFiliere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.IdFiliere))
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
            return View(filiere);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filieres = await _context.Filiere
                .FirstOrDefaultAsync(m => m.IdFiliere == id);
            if (filieres == null)
            {
                return NotFound();
            }

            return View(filieres);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filieres = await _context.Filiere.FindAsync(id);
            _context.Filiere.Remove(filieres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
            return _context.Filiere.Any(e => e.IdFiliere == id);
        }
    }
}
