using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MiniProjet_alpha.Model;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Areas.Identity.Pages.Account
{
    [Authorize(Roles = RoleManagement.Adminuser)]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly miniprojetContext _context;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly miniprojetContext _db;
        public IEnumerable<Model.Matiere> Matieres;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            miniprojetContext context, RoleManager<IdentityRole> roleManager, miniprojetContext db)
        {
            _userManager = userManager;
            _context = context;
            _rolemanager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Date de naissance")]
            [DataType(DataType.Date)]
            public DateTime Datenaissance { get; set; }

            [Display(Name = "Statut")]
            public string Statut { get; set; }
            [Display(Name = "Nom")]
            public string Nom { get; set; }
            [Display(Name = "Prenom")]
            public string Prenom { get; set; }
            [Display(Name = "Date d'embauche")]
            [DataType(DataType.Date)]
            public DateTime DateEmbauche { get; set; }
            [Display(Name = "Matricule")]
            public string Matricule { get; set; }
            [Display(Name = "Matiere")]
            public int MatiereId { get; set; }

        }

public async Task<IActionResult> OnGetAsync()
{
    this.Matieres = await _db.Matiere.ToListAsync();
    return Page();
}

        public async Task<IActionResult> OnPostAsync()
        {
             this.Matieres = await _db.Matiere.ToListAsync();
            if (ModelState.IsValid)
            {
                var user = new Utilisateur { UserName = Input.Email, Email = Input.Email, datenaissance = Input.Datenaissance, statut = Input.Statut };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var createduser = await _context.Aspnetusers.Where(s => s.Id == user.Id)
                                      .FirstOrDefaultAsync();
                    if (Input.Statut == "prof")
                    {
                        var professeur = new Model.Professeur { Nom = Input.Nom, Prenom = Input.Prenom, Dateembauche = Input.DateEmbauche, UtilisateurId = createduser.Id, Matericule = Input.Matricule, MatiereId = Input.MatiereId };
                        _context.Professeur.Add(professeur);
                        await _context.SaveChangesAsync();
                        if (!await _rolemanager.RoleExistsAsync(RoleManagement.Adminuser))
                        {
                            await _rolemanager.CreateAsync(new IdentityRole(RoleManagement.Adminuser));
                        }
                        if (!await _rolemanager.RoleExistsAsync(RoleManagement.Profuser))
                        {
                            await _rolemanager.CreateAsync(new IdentityRole(RoleManagement.Profuser));
                        }
                        await _userManager.AddToRoleAsync(user, RoleManagement.Profuser);

                    }
                    else
                    {
                        var administrateur = new Model.Administrateur { Nom = Input.Nom, Prenom = Input.Prenom, UtilisateurId = createduser.Id };
                        _context.Administrateur.Add(administrateur);
                        await _context.SaveChangesAsync();
                        if (!await _rolemanager.RoleExistsAsync(RoleManagement.Adminuser))
                        {
                            await _rolemanager.CreateAsync(new IdentityRole(RoleManagement.Adminuser));
                        }
                        if (!await _rolemanager.RoleExistsAsync(RoleManagement.Profuser))
                        {
                            await _rolemanager.CreateAsync(new IdentityRole(RoleManagement.Profuser));
                        }
                        await _userManager.AddToRoleAsync(user, RoleManagement.Adminuser);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
