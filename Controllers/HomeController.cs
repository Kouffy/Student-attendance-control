using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProjet_alpha.Model;
using MiniProjet_alpha.Models;
using MiniProjet_alpha.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MiniProjet_alpha.Controllers
{
    [Authorize(Roles = RoleManagement.Adminuser)]
    public class HomeController : Controller
    {
        private readonly miniprojetContext _context;
         private readonly ILogger<HomeController> _logger;
        public HomeController( miniprojetContext context,ILogger<HomeController> logger)
        {
            _context = context;
             _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var results = await (from ab in _context.Absance
                                 join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                 join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                 join m in _context.Matiere on p.MatiereId equals m.IdMatiere
                                 join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                 select new AdminDashboardViewModel()
                                 {

                                     LibelleMatiere = m.Libelle,
                                     DateSeance = ab.DateAbsance,
                                     NomComplet = etu.Nom + " " + etu.Prenom,
                                     EstAbsent = ab.EstAbsant,
                                 }).ToListAsync();
            return View(results);
        }
        public async Task<IActionResult> TauxAdmin()
        {
            IEnumerable<AdminDashboardViewModel> v1 = await (from ab in _context.Absance
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere
                                                             
                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 LibelleMatiere = m.Libelle,
                                                                 Countabs =  _context.Absance.Where(n=>n.SeanceIdSeanceNavigation.Professeur.Matiere.IdMatiere==m.IdMatiere).Count()
                                                             }).Distinct().ToListAsync();
                                


            IEnumerable<AdminDashboardViewModel> v2 = await  (from ab in _context.Absance
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere 
                                                             
                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 LibelleMatiere = m.Libelle,
                                                                 Countabs =  _context.Absance.Where(n=>n.SeanceIdSeanceNavigation.Professeur.Matiere.IdMatiere==m.IdMatiere&&n.EstAbsant==0).Count()
                                                             }).Distinct().ToListAsync();
            IEnumerator<AdminDashboardViewModel> enumerator = v1.GetEnumerator();
            IEnumerator<AdminDashboardViewModel> enumerator2 = v2.GetEnumerator();
            while (enumerator2.MoveNext() && enumerator.MoveNext())
            {
                   _logger.LogInformation(enumerator2.Current.Countabs.ToString());
                  _logger.LogInformation("/");
                _logger.LogInformation(enumerator.Current.Countabs.ToString());
                enumerator2.Current.Countabs = enumerator2.Current.Countabs / enumerator.Current.Countabs * 100;
             
            }
            return View(v2);
        }
        public async Task<IActionResult> TauxAdminEtudiant()
        {
            IEnumerable<AdminDashboardViewModel> v1 = await (from ab in _context.Absance
                                                             join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere
                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 Countabs = etu.Absance.Count(),
                                                             }).ToListAsync();

            IEnumerable<AdminDashboardViewModel> v2 = await (from ab in _context.Absance
                                                             join etu in _context.Etudiant on ab.EtudiantIdEtudiant equals etu.IdEtudiant
                                                             join se in _context.Seance on ab.SeanceIdSeance equals se.IdSeance
                                                             join p in _context.Professeur on se.ProfesseurId equals p.IdProfesseur
                                                             join m in _context.Matiere on p.MatiereId equals m.IdMatiere where ab.EstAbsant == 0

                                                             select new AdminDashboardViewModel()
                                                             {
                                                                 NomComplet = etu.Nom + " " + etu.Prenom,
                                                                 NbAbsEtu = _context.Absance.Where(n=>n.EtudiantIdEtudiant==etu.IdEtudiant&&n.EstAbsant==0).Count(),

                                                             }).ToListAsync();




            IEnumerator<AdminDashboardViewModel> enumerator = v1.GetEnumerator();
            IEnumerator<AdminDashboardViewModel> enumerator2 = v2.GetEnumerator();
            while (enumerator2.MoveNext() && enumerator.MoveNext())
            {
                _logger.LogInformation(enumerator2.Current.NomComplet);
                  _logger.LogInformation(enumerator2.Current.NbAbsEtu.ToString());
                  _logger.LogInformation("/");
                _logger.LogInformation(enumerator.Current.Countabs.ToString());
                enumerator2.Current.Countabs = enumerator2.Current.NbAbsEtu / enumerator.Current.Countabs * 100;

            }
            return View(v2);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
