using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MiniProjet_alpha.Model;
using MiniProjet_alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly miniprojetContext _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, miniprojetContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
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

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            //await _context.Matiere.ToListAsync();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Utilisateur { UserName = Input.Email, Email = Input.Email, datenaissance = Input.Datenaissance,statut = Input.Statut };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var createduser = await _context.Aspnetusers.Where(s => s.Id == user.Id)
                                      .FirstOrDefaultAsync();
                 //   if(Input.Statut == "Professeur")
                 //   {                        
                    var professeur = new Model.Professeur { Nom = Input.Nom, Prenom = Input.Prenom, Dateembauche = Input.DateEmbauche, UtilisateurId = createduser.Id,Matericule=Input.Matricule,MatiereId= Input.MatiereId};
                        _context.Professeur.Add(professeur);
                    await _context.SaveChangesAsync();
                     _logger.LogInformation("Prof created a new account with password.");
                      _logger.LogInformation(createduser.Id);
                  /*  }
                    else
                    {
                    var administrateur = new Model.Administrateur { Nom = Input.Nom, Prenom = Input.Prenom, UtilisateurId = createduser.Id};
                    _context.Administrateur.Add(administrateur);
                    await _context.SaveChangesAsync();
                     _logger.LogInformation("Prof created a new account with password.");
                      _logger.LogInformation(createduser.Id);
                    }*/
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);
                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
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
