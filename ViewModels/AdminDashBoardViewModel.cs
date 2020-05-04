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
    public class AdminDashboardViewModel
    {
        public string LibelleMatiere;
        public DateTime DateSeance;
        public string NomComplet;
        public int EstAbsent;
        public double Countabs;
        public double NbAbsEtu;

    }
}