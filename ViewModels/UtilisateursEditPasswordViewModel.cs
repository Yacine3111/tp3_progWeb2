using System.ComponentModel.DataAnnotations;

namespace TP3.ViewModels
{
    public class UtilisateursEditPasswordViewModel
    {
        public int Id { get; set; }

        public required string MotDePasseActuel { get; set; }

        public required string MotDePasseNouveau { get; set; }

        public required string MotDePasseConfirmation { get; set; }
    }
}
