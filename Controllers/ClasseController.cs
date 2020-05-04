using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using Microsoft.AspNetCore.Authorization;
using MiniProjet_alpha.ViewModels;

namespace MiniProjet_alpha.Controllers
{

    [Authorize(Roles = RoleManagement.Adminuser)]
    public class ClasseController : Controller
    {
        private readonly miniprojetContext _context;
        public ClasseController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ClasseViewModel mymodel = new ClasseViewModel();
            mymodel.Classes = await _context.Classe.ToListAsync();
            mymodel.Filieres = await _context.Filiere.ToListAsync();
            return View(mymodel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClasseViewModel mymodel = new ClasseViewModel();
            mymodel.classe = await _context.Classe
                 .FirstOrDefaultAsync(m => m.IdClasse == id);
            mymodel.LibelleFiliere = _context.Filiere.Find(mymodel.classe.FiliereIdFiliere).Libelle;
            if (mymodel.classe == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }

        public async Task<IActionResult> Create()
        {
            ClasseViewModel mymodel = new ClasseViewModel();
            mymodel.classe = new Model.Classe();
            mymodel.Filieres = await _context.Filiere.ToListAsync();
            return View(mymodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle,FiliereIdFiliere")] Model.Classe Classe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Classe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Classe);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClasseViewModel mymodel = new ClasseViewModel();
            mymodel.classe = await _context.Classe.FindAsync(id);
            mymodel.Filieres = await _context.Filiere.ToListAsync();
            if (mymodel.classe == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClasse,Libelle,FiliereIdFiliere")] Model.Classe Classe)
        {
            if (id != Classe.IdClasse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(Classe.IdClasse))
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
            return View(Classe);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClasseViewModel mymodel = new ClasseViewModel();
            mymodel.classe = await _context.Classe
                 .FirstOrDefaultAsync(m => m.IdClasse == id);
            mymodel.LibelleFiliere = _context.Filiere.Find(mymodel.classe.FiliereIdFiliere).Libelle;
            if (mymodel.classe == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Classes = await _context.Classe.FindAsync(id);
            _context.Classe.Remove(Classes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(int id)
        {
            return _context.Classe.Any(e => e.IdClasse == id);
        }
    }
}
