using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Aspnetusers
    {
        public Aspnetusers()
        {
            Administrateur = new HashSet<Administrateur>();
            Aspnetuserclaims = new HashSet<Aspnetuserclaims>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogins>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
            Aspnetusertokens = new HashSet<Aspnetusertokens>();
            Professeur = new HashSet<Professeur>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Discriminator { get; set; }
        public DateTime? Datenaissance { get; set; }
        public string Statut { get; set; }

        public virtual ICollection<Administrateur> Administrateur { get; set; }
        public virtual ICollection<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual ICollection<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual ICollection<Professeur> Professeur { get; set; }
    }
}
