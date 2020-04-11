using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Models;

namespace MiniProjet_alpha.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        private DbSet<Utilisateur> utilisateur { get; set; }
        private DbSet<Administrateur> administrateur { get; set; }
        private DbSet<Etudiant> etudiant { get; set; }
        private DbSet<Professeur> professeur { get; set; }
        private DbSet<Filiere> filiere { get; set; }
        private DbSet<Matiere> matiere { get; set; }
        private DbSet<Absance> absance { get; set; }
        private DbSet<Seance> seance { get; set; }
        private DbSet<Classe> classe { get; set; }
        private DbSet<Salle> salle { get; set; }
    }

}
