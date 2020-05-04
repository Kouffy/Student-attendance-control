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
    public class EtudiantController : Controller
    {
        private readonly miniprojetContext _context;
        public EtudiantController(miniprojetContext context)
        {
            _context = context;

        }
        public async Task <IActionResult> Index()
        {
             EtudiantViewModel mymodel = new EtudiantViewModel();
            mymodel.Etudiants = await _context.Etudiant.ToListAsync();
            mymodel.Classes =_context.Classe.ToList();
            return View(mymodel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EtudiantViewModel mymodel = new EtudiantViewModel();
            mymodel.Etudiant =  await _context.Etudiant
                .FirstOrDefaultAsync(m => m.IdEtudiant == id);
            mymodel.LibelleClasse =_context.Classe.Find(mymodel.Etudiant.ClasseIdClasse).Libelle;
       
            if (mymodel.Etudiant == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }
        public IActionResult Create()
        {
            EtudiantViewModel mymodel = new EtudiantViewModel();
            mymodel.Etudiant = new Model.Etudiant();
            mymodel.Classes = _context.Classe.ToList();
            return View(mymodel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Matricule,ClasseIdClasse")] Model.Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiant);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EtudiantViewModel mymodel = new EtudiantViewModel();
            mymodel.Etudiant = await _context.Etudiant.FindAsync(id);
            mymodel.Classes = _context.Classe.ToList();
            if (mymodel.Etudiant == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdEtudiant,Nom,Prenom,Matricule,ClasseIdClasse")] Model.Etudiant etudiant)
        {
            if (id != etudiant.IdEtudiant)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.IdEtudiant))
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
            return View(etudiant);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EtudiantViewModel mymodel = new EtudiantViewModel();
            mymodel.Etudiant =  await _context.Etudiant
                .FirstOrDefaultAsync(m => m.IdEtudiant == id);
            mymodel.LibelleClasse =_context.Classe.Find(mymodel.Etudiant.ClasseIdClasse).Libelle;

            if (mymodel.Etudiant == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etudiants = await _context.Etudiant.FindAsync(id);
            _context.Etudiant.Remove(etudiants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiant.Any(e => e.IdEtudiant == id);
        }
    }
}
