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
    public class ProfesseurViewModel
    {
        public Professeur Professeur { get; set; }
        public IEnumerable<Professeur> Professeurs { get; set; }
        public IEnumerable<Matiere> Matieres { get; set; }
        public string LibelleMatiere { get; set; }
         public string NomComplet { get; set; }
    }
}