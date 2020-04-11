using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MiniProjet_alpha.Models
{
    class Utilisateur : IdentityUser
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        public DateTime datenaissance { get; set; }
        public string statut { get; set; }
    }
}