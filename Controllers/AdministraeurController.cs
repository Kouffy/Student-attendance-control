using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using MiniProjet_alpha.Models;
using Microsoft.AspNetCore.Authorization;

namespace MiniProjet_alpha.Controllers
{
    [Authorize(Roles = RoleManagement.Adminuser)]
    public class AdministrateurController : Controller
    {
        private readonly miniprojetContext _context;
        public AdministrateurController(miniprojetContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrateur.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Administrateurs = await _context.Administrateur
                .FirstOrDefaultAsync(m => m.IdAdministrateur == id);
            if (Administrateurs == null)
            {
                return NotFound();
            }

            return View(Administrateurs);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Administrateurs = await _context.Administrateur.FindAsync(id);
            if (Administrateurs == null)
            {
                return NotFound();
            }
            return View(Administrateurs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdAdministrateur,Nom,Prenom,UtilisateurId")] Model.Administrateur Administrateur)
        {
            if (id != Administrateur.IdAdministrateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Administrateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrateurExists(Administrateur.IdAdministrateur))
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
            return View(Administrateur);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Administrateurs = await _context.Administrateur
                .FirstOrDefaultAsync(m => m.IdAdministrateur == id);
            if (Administrateurs == null)
            {
                return NotFound();
            }

            return View(Administrateurs);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Administrateurs = await _context.Administrateur.FindAsync(id);
            _context.Administrateur.Remove(Administrateurs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrateurExists(int id)
        {
            return _context.Administrateur.Any(e => e.IdAdministrateur == id);
        }
    }
}