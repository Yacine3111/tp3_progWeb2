using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [StringLength(100)]
        public required string Prenom { get; set; }
        [StringLength(100)]
        public required string Nom { get; set; }
        [StringLength(100)]
        public required string Pseudonyme { get; set; }
        [StringLength(100)]
        public string? Courriel { get; set; }
        [StringLength(100)]
        public required string MotDePasseActuel { get; set; }
    }
}
