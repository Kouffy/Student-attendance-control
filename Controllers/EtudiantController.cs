using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;

namespace MiniProjet_alpha.Controllers
{
   public class EtudiantController : Controller
    {
        private readonly miniprojetContext _context;
        public EtudiantController(miniprojetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etudiant.ToListAsync());
        }
         public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiants = await _context.Etudiant
                .FirstOrDefaultAsync(m => m.IdEtudiant == id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return View(etudiants);
        }
        public IActionResult Create()
        {
            return View();
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

            var etudiants = await _context.Etudiant.FindAsync(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            return View(etudiants);
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

            var etudiant = await _context.Etudiant
                .FirstOrDefaultAsync(m => m.IdEtudiant == id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
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
