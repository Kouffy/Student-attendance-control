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
    public class SalleController : Controller
    {
        private readonly miniprojetContext _context;
        public SalleController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salle.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Salles = await _context.Salle
                .FirstOrDefaultAsync(m => m.IdSalle == id);
            if (Salles == null)
            {
                return NotFound();
            }

            return View(Salles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle")] Model.Salle Salle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Salle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Salle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Salles = await _context.Salle.FindAsync(id);
            if (Salles == null)
            {
                return NotFound();
            }
            return View(Salles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSalle,Libelle")] Model.Salle Salle)
        {
            if (id != Salle.IdSalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Salle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleExists(Salle.IdSalle))
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
            return View(Salle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salle
                .FirstOrDefaultAsync(m => m.IdSalle == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Salles = await _context.Salle.FindAsync(id);
            _context.Salle.Remove(Salles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleExists(int id)
        {
            return _context.Salle.Any(e => e.IdSalle == id);
        }
    }
}
