using System.ComponentModel.DataAnnotations;

namespace TP3.ViewModels
{
    public class UtilisateursEditViewModel
    {
        public int Id { get; set; }

        public required string Prenom { get; set; }

        public required string Nom { get; set; }

        public required string Pseudonyme { get; set; }

        public string? Courriel { get; set; }
    }
}
