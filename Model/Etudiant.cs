using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Absance = new HashSet<Absance>();
        }

        public int IdEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }
        public int ClasseIdClasse { get; set; }

        public virtual Classe ClasseIdClasseNavigation { get; set; }
        public virtual ICollection<Absance> Absance { get; set; }
    }
}
