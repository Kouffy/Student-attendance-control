using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniProjet_alpha.Models
{
    class Professeur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfesseur { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [MaxLength(20)]
        public string nom { get; set; }
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [MaxLength(20)]
        public string prenom { get; set; }
        [Required(ErrorMessage = "Le matricule est obligatoire")]
        [MaxLength(10)]
        public string matericule { get; set; }
        [Required(ErrorMessage = "La date d'embauche est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime dateembauche { get; set; }
        [Required(ErrorMessage = "La Matiere est obligatoire")]

        public int MatiereId { get; set; }
        [ForeignKey("MatiereId")]
        public Matiere matiere { get; set; }
        [Required(ErrorMessage = "L'Utilisateur est obligatoire")]
        public Utilisateur Utilisateur { get; set; }


    }
}