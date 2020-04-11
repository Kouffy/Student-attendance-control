using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Classe
    {
        public Classe()
        {
            Etudiant = new HashSet<Etudiant>();
            Seance = new HashSet<Seance>();
        }

        public int IdClasse { get; set; }
        public string Libelle { get; set; }
        public int FiliereIdFiliere { get; set; }

        public virtual Filiere FiliereIdFiliereNavigation { get; set; }
        public virtual ICollection<Etudiant> Etudiant { get; set; }
        public virtual ICollection<Seance> Seance { get; set; }
    }
}
