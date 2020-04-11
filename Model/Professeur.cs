using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Professeur
    {
        public Professeur()
        {
            Seance = new HashSet<Seance>();
        }

        public int IdProfesseur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matericule { get; set; }
        public DateTime Dateembauche { get; set; }
        public int MatiereId { get; set; }
        public string UtilisateurId { get; set; }

        public virtual Matiere Matiere { get; set; }
        public virtual Aspnetusers Utilisateur { get; set; }
        public virtual ICollection<Seance> Seance { get; set; }
    }
}
