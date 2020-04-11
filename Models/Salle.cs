using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Models
{
    class Salle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSalle { get; set; }

        [Required(ErrorMessage = "Veillier indiquer le libelle")]
        public string Libelle { get; set; }

    }
}