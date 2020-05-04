using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using MiniProjet_alpha.Models;
using MiniProjet_alpha.ViewModels;

namespace MiniProjet_alpha.Controllers
{
    [Authorize(Roles = RoleManagement.Adminuser)]
    public class SeanceController : Controller
    {

        private readonly miniprojetContext _context;
        public SeanceController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            SeanceViewModel mymodel = new SeanceViewModel();
            mymodel.Seances = await _context.Seance.ToListAsync();
            mymodel.Professeurs = await _context.Professeur.ToListAsync();
            mymodel.Classes = await _context.Classe.ToListAsync();
            mymodel.Salles = await _context.Salle.ToListAsync();
            return View(mymodel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SeanceViewModel mymodel = new SeanceViewModel();
            mymodel.seance = await _context.Seance
                .FirstOrDefaultAsync(m => m.IdSeance == id);
            mymodel.NomProfesseur = _context.Professeur.Find(mymodel.seance.ProfesseurId).Nom + " " + _context.Professeur.Find(mymodel.seance.ProfesseurId).Prenom;
            mymodel.LibelleClasse = _context.Classe.Find(mymodel.seance.ClasseId).Libelle;
            mymodel.LibelleSalle = _context.Salle.Find(mymodel.seance.IdSalle).Libelle;
            if (mymodel.seance == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }
        public async Task<IActionResult> Create()
        {
            SeanceViewModel mymodel = new SeanceViewModel();
            mymodel.seance = new Model.Seance();
            mymodel.Professeurs = await _context.Professeur.ToListAsync();
            mymodel.Classes = await _context.Classe.ToListAsync();
            mymodel.Salles = await _context.Salle.ToListAsync();
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Heuredebut,Heurefin,ClasseId,ProfesseurId,IdSalle,Jourseance")] Model.Seance Seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Seance);
                await _context.SaveChangesAsync();
                Console.Write("zbi");
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
            SeanceViewModel mymodel = new SeanceViewModel();
            mymodel.seance = await _context.Seance
                .FirstOrDefaultAsync(m => m.IdSeance == id);
            mymodel.Professeurs = await _context.Professeur.ToListAsync();
            mymodel.Classes = await _context.Classe.ToListAsync();
            mymodel.Salles = await _context.Salle.ToListAsync();
            if (mymodel.seance == null)
            {
                return NotFound();
            }
            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSeance,Jourseance,Heuredebut,Heurefin,ClasseId,ProfesseurId,IdSalle")] Model.Seance seance)
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

            SeanceViewModel mymodel = new SeanceViewModel();
            mymodel.seance = await _context.Seance
                 .FirstOrDefaultAsync(m => m.IdSeance == id);
            mymodel.NomProfesseur = _context.Professeur.Find(mymodel.seance.ProfesseurId).Nom + " " + _context.Professeur.Find(mymodel.seance.ProfesseurId).Prenom;
            mymodel.LibelleClasse = _context.Classe.Find(mymodel.seance.ClasseId).Libelle;
            mymodel.LibelleSalle = _context.Salle.Find(mymodel.seance.IdSalle).Libelle;
            if (mymodel.seance == null)
            {
                return NotFound();
            }
            return View(mymodel);
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
