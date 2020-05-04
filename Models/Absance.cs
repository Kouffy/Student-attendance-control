using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Models
{
    class Absance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAbsance { get; set; }
        [Required(ErrorMessage = "Veillier indiquer la date d'absance")]
        [DataType(DataType.Date)]
        public DateTime DateAbsance { get; set; }

        [Required(ErrorMessage = "Veillier indiquer labsance")]
        public int EstAbsant { get; set; }
        [Required(ErrorMessage = "La Seance est obligatoire")]
        public Seance Seance { get; set; }
        [Required(ErrorMessage = "L'Etudiant est obligatoire")]
        public Etudiant Etudiant { get; set; }

    }
}