using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjet_alpha.Models
{
    class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClasse { get; set; }
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        [MaxLength(10)]
        public string libelle { get; set; }
        [Required(ErrorMessage = "La Filiere est obligatoire")]
        public Filiere Filiere { get; set; }

    }
}