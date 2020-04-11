using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Models
{
    class Administrateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministrateur { get; set; }
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [MaxLength(20)]
        public string nom { get; set; }
        [Required(ErrorMessage = "Le Prenom est obligatoire")]
        [MaxLength(20)]
        public string prenom { get; set; }
        [Required(ErrorMessage = "L'Utilisateur est obligatoire")]
        public Utilisateur Utilisateur { get; set; }

    }
}