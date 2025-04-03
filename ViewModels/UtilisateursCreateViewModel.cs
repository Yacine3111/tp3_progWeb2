using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP3.ViewModels
{
    public class UtilisateursCreateViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ " + nameof(Prenom) + " est obligatoire")]
        public required string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ " + nameof(Nom) + " est obligatoire")]
        public required string Nom { get; set; }

        [Required(ErrorMessage = "Le champ " + nameof(Pseudonyme) + " est obligatoire")]
        [RegularExpression("^[a-zA-Z0-9_-]+$", ErrorMessage = "Le pseudonym ne peut qu'avoir des lettres sans accents, des chiffres,des _ et des -")]
        public required string Pseudonyme { get; set; }

        //l'anotation [EmailAdress] accepte le format abc@abc
        //Avec le regex on rend le abc@domaine.extention obligatoire
        [RegularExpression("^[a-zA-Z0-9$#_*-]+@[a-zA-Z]*[.]?[a-z]{2,}$",
            ErrorMessage = "\"Vous devez entrez un email avec par exemple le format  abc@cba.ca\"")]
        public string? Courriel { get; set; }

        [DisplayName("Info lettre")]
        public bool InfoLettre { get; set; }


        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^(\da-zA-Z)]).{8,}$",
            ErrorMessage = "Le mot de passe doit contenir une minuscule, une majuscule, un chiffre, un caractère spécial et avoir une" +
                           " longueur d'au moins 8 caractères")]
        public required string MotDePasseNouveau { get; set; }

        [DisplayName("Confirmation de mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Password)]
        [Compare(nameof(MotDePasseNouveau), ErrorMessage = "la confirmation de mot de passe est différente")]
        public required string MotDePasseConfirmation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (InfoLettre && string.IsNullOrWhiteSpace(Courriel))
            {
                yield return new ValidationResult("Le courriel doit être spécifié", new[] { nameof(this.Courriel) });
            }
        }
    }
}
