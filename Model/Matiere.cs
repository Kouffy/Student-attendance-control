using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Matiere
    {
        public Matiere()
        {
            Professeur = new HashSet<Professeur>();
        }

        public int IdMatiere { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Professeur> Professeur { get; set; }
    }
}
