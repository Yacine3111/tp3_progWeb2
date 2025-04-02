
using System.ComponentModel.DataAnnotations;

namespace TP3.ViewModels
{
    public class UtilisateursCreateViewModel
    {
        public int Id { get; set; }

        public required string Prenom { get; set; }

        public required string Nom { get; set; }

        public required string Pseudonyme { get; set; }

        public string? Courriel { get; set; }

        public required string MotDePasseNouveau { get; set; }

        public required string MotDePasseConfirmation { get; set; }
    }
}
