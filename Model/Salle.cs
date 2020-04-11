using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Salle
    {
        public Salle()
        {
            Seance = new HashSet<Seance>();
        }

        public int IdSalle { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Seance> Seance { get; set; }
    }
}
