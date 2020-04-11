using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjet_alpha.Models
{
    class Etudiant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEtudiant { get; set; }
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [MaxLength(20)]
        public string nom { get; set; }
        [Required(ErrorMessage = "Le Prenom est obligatoire")]
        [MaxLength(20)]
        public string prenom { get; set; }
        [Required(ErrorMessage = "Le Matricule est obligatoire")]
        [MaxLength(10)]
        public string matricule { get; set; }
        [Required(ErrorMessage = "La Classe est obligatoire")]
        public Classe Classe { get; set; }
    }
}