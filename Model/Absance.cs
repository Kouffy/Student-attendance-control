using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Absance
    {
        public int IdAbsance { get; set; }
        public int EstAbsant { get; set; }
        public int SeanceIdSeance { get; set; }
        public int EtudiantIdEtudiant { get; set; }

        public virtual Etudiant EtudiantIdEtudiantNavigation { get; set; }
        public virtual Seance SeanceIdSeanceNavigation { get; set; }
    }
}
