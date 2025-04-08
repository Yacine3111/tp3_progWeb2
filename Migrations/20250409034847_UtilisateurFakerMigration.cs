using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class UtilisateurFakerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "Courriel", "InfoLettre", "MotDePasseActuel", "Nom", "Prenom", "Pseudonyme" },
                values: new object[,]
                {
                    { 1, "Annabelle.Bernier50@gmail.com", false, "D4f2tqBRBc", "Bernier", "Annabelle", "Annabelle_Bernier79" },
                    { 2, "Kraig51@hotmail.com", true, "N8iMJNcJ9C", "Mraz", "Kraig", "Kraig_Mraz39" },
                    { 3, null, false, "x0GmrehBfc", "Dare", "Royce", "Royce_Dare61" },
                    { 4, "Icie28@gmail.com", true, "7sVSYiKcxT", "Hirthe", "Icie", "Icie_Hirthe" },
                    { 5, "Donato.Huel@yahoo.com", true, "mx0pCw4pkG", "Huel", "Donato", "Donato11" },
                    { 6, "Nelle16@hotmail.com", true, "ASZKqZkhH_", "Fritsch", "Nelle", "Nelle.Fritsch5" },
                    { 7, "Skyla_Prosacco34@yahoo.com", false, "JocBVBPiOo", "Prosacco", "Skyla", "Skyla7" },
                    { 8, "Dora36@yahoo.com", true, "fqT2Zsq7nl", "Bailey", "Dora", "Dora_Bailey" },
                    { 9, "Susie76@gmail.com", true, "8ttZ6FFgBz", "Fahey", "Susie", "Susie89" },
                    { 10, "Aurelio_Stokes@yahoo.com", false, "XZJOn7qxzJ", "Stokes", "Aurelio", "Aurelio_Stokes16" },
                    { 11, "Jayda6@yahoo.com", true, "D_BbzRb6tt", "Koelpin", "Jayda", "Jayda79" },
                    { 12, "Stacey4@yahoo.com", true, "03VN9XvE3O", "Ebert", "Stacey", "Stacey.Ebert98" },
                    { 13, null, false, "CM1jPjgZsV", "Shanahan", "Jimmie", "Jimmie.Shanahan57" },
                    { 14, "Trinity93@hotmail.com", true, "jxdtQMsCdp", "Kub", "Trinity", "Trinity_Kub27" },
                    { 15, null, false, "S2foRl8srp", "Pfannerstill", "Carrie", "Carrie.Pfannerstill" },
                    { 16, null, false, "udFa0aJ5rO", "Feest", "Lelia", "Lelia65" },
                    { 17, "Kiara84@gmail.com", true, "sEYZId4_pg", "Ruecker", "Kiara", "Kiara.Ruecker97" },
                    { 18, "Nicholaus24@yahoo.com", false, "jgl9QGdRU8", "Ratke", "Nicholaus", "Nicholaus_Ratke" },
                    { 19, "Ed.Emmerich@hotmail.com", false, "X_KjKDC8vE", "Emmerich", "Ed", "Ed.Emmerich28" },
                    { 20, "Bernard86@hotmail.com", true, "O38d7IS3ZI", "Hilpert", "Bernard", "Bernard90" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
