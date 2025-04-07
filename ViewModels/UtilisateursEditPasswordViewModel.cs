using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP3.ViewModels
{
    public class UtilisateursEditPasswordViewModel
    {
        public int Id { get; set; }

        [DisplayName("mot de passe actuel")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Password)]

        public required string MotDePasseActuel { get; set; }

        [DisplayName("nouveau mot de passe")]
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
    }
}
