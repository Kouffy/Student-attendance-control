using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Seance
    {
        public Seance()
        {
            Absance = new HashSet<Absance>();
        }

        public int IdSeance { get; set; }
        public DateTime Dateseance { get; set; }
        public TimeSpan Heuredebut { get; set; }
        public TimeSpan Heurefin { get; set; }
        public int ClasseId { get; set; }
        public int ProfesseurId { get; set; }
        public int IdSalle { get; set; }

        public virtual Classe Classe { get; set; }
        public virtual Salle IdSalleNavigation { get; set; }
        public virtual Professeur Professeur { get; set; }
        public virtual ICollection<Absance> Absance { get; set; }
    }
}
