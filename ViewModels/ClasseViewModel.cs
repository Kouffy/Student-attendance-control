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
    public class ClasseViewModel
    {
        public Classe classe { get; set; }
        public IEnumerable<Filiere> Filieres { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public string LibelleFiliere { get; set; }
    }
}