using System.ComponentModel.DataAnnotations;
namespace simple_crud.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le Nom est Obligatoire.")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le Prénom est Obligatoire.")]
        public string Prenom { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Date de Naissance est Obligatoire.")]
        // [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "La Moyenne Générale est Obligatoire.")]
        [DisplayFormat(DataFormatString = "{0:00.00}", ApplyFormatInEditMode = true)]
        public Double MoyenneGenerale { get; set; } = 10.25d;

        public bool IsExclut { get; set; } = false; //default value
    }
}