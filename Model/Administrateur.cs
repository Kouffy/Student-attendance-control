using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Administrateur
    {
        public int IdAdministrateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UtilisateurId { get; set; }

        public virtual Aspnetusers Utilisateur { get; set; }
    }
}
