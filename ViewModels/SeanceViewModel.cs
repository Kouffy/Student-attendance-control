using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProjet_alpha.Model;
using Microsoft.AspNetCore.Authorization;

namespace MiniProjet_alpha.ViewModels
{
    public class SeanceViewModel
    {
        public Seance seance { get; set; }
        public string NomProfesseur { get; set; }
        public string LibelleClasse { get; set; }
        public string LibelleSalle { get; set; }
        public IEnumerable<Professeur> Professeurs { get; set; }
        public IEnumerable<Salle> Salles { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public IEnumerable<Seance> Seances { get; set; }
    }
}