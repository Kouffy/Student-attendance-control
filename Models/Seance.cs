using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Models
{
    class Seance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSeance { get; set; }
        [Required(ErrorMessage = "La date de seance est obligatoire")]
        public DateTime dateseance { get; set; }
        [Required(ErrorMessage = "L'heure de debut est obligatoire")]
        [DataType(DataType.Time)]
        public TimeSpan heuredebut { get; set; }
        [Required(ErrorMessage = "L'heure de fin est obligatoire")]
        [DataType(DataType.Time)]
        public TimeSpan heurefin { get; set; }
        [Required(ErrorMessage = "La classe est est obligatoire")]
        public int ClasseId { get; set; }
        [ForeignKey("ClasseId")]
        public Classe Classe { get; set; }
        [Required(ErrorMessage = "Le Professeur est obligatoire")]
        public int ProfesseurId { get; set; }
        [ForeignKey("ProfesseurId")]
        public Professeur Professeur { get; set; }
        public int IdSalle { get; set; }
        [ForeignKey("IdSalle")]
        public Salle Salle { get; set; }


    }
}