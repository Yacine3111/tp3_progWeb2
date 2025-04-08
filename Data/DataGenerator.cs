using Bogus;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Data
{
    public class DataGenerator
    {

        public DataGenerator()
        {
            Randomizer.Seed = new Random(12345);
        }

        public void SeedEverything(ModelBuilder modelBuilder)
        {
            SeedUtilisateur(modelBuilder);
        }

        public IList<Utilisateur> SeedUtilisateur(ModelBuilder modelBuilder)
        {


            // regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^(\da-zA-Z)]).{8,}$";

            var utilisateurFaker = new Faker<Utilisateur>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Prenom, f => f.Name.FirstName())
                .RuleFor(u => u.Nom, f => f.Name.LastName())
                .RuleFor(u => u.Pseudonyme, (f, u) => f.Internet.UserName(u.Prenom, u.Nom))
                .RuleFor(u => u.InfoLettre, f => f.Random.Bool(0.4f))
                .RuleFor(u => u.Courriel, (f, u) =>
                {
                    if (u.InfoLettre)
                    {
                        return f.Internet.Email(u.Prenom, u.Nom);
                    }
                    else
                    {
                        return f.Random.WeightedRandom([f.Internet.Email(u.Prenom, u.Nom), null], [0.5f, 0.5f]);
                    }

                })
                .RuleFor(u => u.MotDePasseActuel, f => f.Internet.Password())
                ;

            var listUtilisateurs = utilisateurFaker.Generate(20);

            modelBuilder.Entity<Utilisateur>()
                .HasData(listUtilisateurs);

            return listUtilisateurs;
        }


    }
}
