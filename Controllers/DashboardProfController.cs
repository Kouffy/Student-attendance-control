using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using MiniProjet_alpha.Models;
using Microsoft.AspNetCore.Authorization;
using MiniProjet_alpha.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MiniProjet_alpha.Controllers
{
    [Authorize(Roles = RoleManagement.Profuser)]
    public class DashboardProfController : Controller
    {

        private readonly miniprojetContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardProfController(miniprojetContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> ListePresence()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Model.Professeur pr = await _context.Professeur.FirstOrDefaultAsync(x => x.UtilisateurId == userId);
            var results = await (from ab in _context.Absance
                                 join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                 join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                 join m in _context.Matiere on p.MatiereId equals m.IdMatiere
                                 join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                 where p.IdProfesseur == pr.IdProfesseur
                                 select new AdminDashboardViewModel()
                                 {

                                     LibelleMatiere = m.Libelle,
                                     DateSeance = ab.DateAbsance,
                                     NomComplet = etu.Nom + " " + etu.Prenom,
                                     EstAbsent = ab.EstAbsant,
                                 }).ToListAsync();


            return View(results);
        }
        public async Task<IActionResult> TauxAbsMat()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Model.Professeur pr = await _context.Professeur.FirstOrDefaultAsync(x => x.UtilisateurId == userId);
            IEnumerable<AdminDashboardViewModel> v1 = await (from ab in _context.Absance
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere

                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 LibelleMatiere = m.Libelle,
                                                                 Countabs = _context.Absance.Where(n => n.SeanceIdSeanceNavigation.Professeur.Matiere.IdMatiere == m.IdMatiere && n.SeanceIdSeanceNavigation.Professeur.IdProfesseur == pr.IdProfesseur).Count()
                                                             }).Distinct().ToListAsync();



            IEnumerable<AdminDashboardViewModel> v2 = await (from ab in _context.Absance
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere

                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 LibelleMatiere = m.Libelle,
                                                                 Countabs = _context.Absance.Where(n => n.SeanceIdSeanceNavigation.Professeur.Matiere.IdMatiere == m.IdMatiere && n.SeanceIdSeanceNavigation.Professeur.IdProfesseur == pr.IdProfesseur && n.EstAbsant == 0).Count()
                                                             }).Distinct().ToListAsync();
            IEnumerator<AdminDashboardViewModel> enumerator = v1.GetEnumerator();
            IEnumerator<AdminDashboardViewModel> enumerator2 = v2.GetEnumerator();
            while (enumerator2.MoveNext() && enumerator.MoveNext())
            {
  
                enumerator2.Current.Countabs = enumerator2.Current.Countabs / enumerator.Current.Countabs * 100;

            }
            return View(v2);
        }
        public async Task<IActionResult> TauxAbsEtu()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Model.Professeur pr = await _context.Professeur.FirstOrDefaultAsync(x => x.UtilisateurId == userId);
           IEnumerable<AdminDashboardViewModel> v1 = await (from ab in _context.Absance
                                                             join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere where p.IdProfesseur == pr.IdProfesseur
                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 Countabs = etu.Absance.Count()
                                                             }).ToListAsync();

            IEnumerable<AdminDashboardViewModel> v2 = await (from ab in _context.Absance
                                                             join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere where ab.EstAbsant == 0

                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 NomComplet = etu.Nom + " " + etu.Prenom,
                                                                 EstAbsent = ab.EstAbsant,
                                                                 NbAbsEtu = _context.Absance.Where(n=>n.EtudiantIdEtudiant==etu.IdEtudiant&&n.EstAbsant==0&&n.SeanceIdSeanceNavigation.ProfesseurId==pr.IdProfesseur).Count(),

                                                             }).ToListAsync();


            IEnumerator<AdminDashboardViewModel> enumerator = v1.GetEnumerator();
            IEnumerator<AdminDashboardViewModel> enumerator2 = v2.GetEnumerator();
            while (enumerator2.MoveNext() && enumerator.MoveNext())
            {
                enumerator2.Current.Countabs = enumerator2.Current.NbAbsEtu / enumerator.Current.Countabs * 100;

            }
            return View(v2);
        }
    }

}