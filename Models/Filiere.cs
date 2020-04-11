using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjet_alpha.Models
{
    class Filiere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFiliere { get; set; }
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        [MaxLength(5)]
        public string libelle { get; set; }

    }
}