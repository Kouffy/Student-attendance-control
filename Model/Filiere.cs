using System;
using System.Collections.Generic;

namespace MiniProjet_alpha.Model
{
    public partial class Filiere
    {
        public Filiere()
        {
            Classe = new HashSet<Classe>();
        }

        public int IdFiliere { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Classe> Classe { get; set; }
    }
}
