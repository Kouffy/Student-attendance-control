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
    public class EtudiantViewModel
    {
        public Etudiant Etudiant { get; set; }
        public IEnumerable<Etudiant> Etudiants { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public string LibelleClasse { get; set; }
    }
}