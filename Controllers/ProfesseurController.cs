using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using Microsoft.AspNetCore.Authorization;
using MiniProjet_alpha.ViewModels;
using Microsoft.Extensions.Logging;

namespace MiniProjet_alpha.Controllers
{
    [Authorize(Roles = RoleManagement.Adminuser)]
    public class ProfesseurController : Controller
    {
        private readonly miniprojetContext _context;
        private readonly ILogger<ProfesseurController> _logger;
        public ProfesseurController(miniprojetContext context, ILogger<ProfesseurController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            ProfesseurViewModel mymodel = new ProfesseurViewModel();
            mymodel.Professeurs = await _context.Professeur.ToListAsync();
            mymodel.Matieres = _context.Matiere.ToList();
            return View(mymodel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProfesseurViewModel mymodel = new ProfesseurViewModel();
            mymodel.Professeur = await _context.Professeur
                .FirstOrDefaultAsync(m => m.IdProfesseur == id);
            mymodel.LibelleMatiere = _context.Classe.Find(mymodel.Professeur.MatiereId).Libelle;

            if (mymodel.Professeur == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProfesseurViewModel mymodel = new ProfesseurViewModel();
            mymodel.Professeur = await _context.Professeur.FindAsync(id);
            mymodel.Matieres = _context.Matiere.ToList();
            if (mymodel.Professeur == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdProfesseur,Nom,Prenom,Matericule,Dateembauche,MatiereId,UtilisateurId")] Model.Professeur professeur)
        {
            _logger.LogInformation(professeur.UtilisateurId.ToString());
            if (id != professeur.IdProfesseur)
            {

                return NotFound();

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesseurExists(professeur.IdProfesseur))
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
            return View(professeur);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
   ProfesseurViewModel mymodel = new ProfesseurViewModel();
            mymodel.Professeur =  await _context.Professeur
                .FirstOrDefaultAsync(m => m.IdProfesseur == id);
            mymodel.Matieres = _context.Matiere.ToList();
            if (mymodel.Professeur == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Professeurs = await _context.Professeur.FindAsync(id);
            _context.Professeur.Remove(Professeurs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesseurExists(int id)
        {
            return _context.Professeur.Any(e => e.IdProfesseur == id);
        }
    }
}
