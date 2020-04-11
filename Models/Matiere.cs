using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjet_alpha.Models
{
    class Matiere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatiere { get; set; }
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        [MaxLength(30)]
        public string libelle { get; set; }
    }
}