using simple_crud.Models;

namespace simple_crud.Data
{
    public static class DataInitializer
    {
        public static List<Etudiant> SeedEtudiantData()
        {
            return new List<Etudiant>()
            {
                new Etudiant(){Id = 1,DateNaissance = DateTime.Now,MoyenneGenerale = 17.5d,Nom = "nom_1",Prenom = "prenom_1"},
                new Etudiant(){Id = 2,DateNaissance = DateTime.Now,MoyenneGenerale = 16.5d,Nom = "nom_2",Prenom = "prenom_2"},
                new Etudiant(){Id = 3,DateNaissance = DateTime.Now,MoyenneGenerale = 15.5d,Nom = "nom_3",Prenom = "prenom_3"},
                new Etudiant(){Id = 4,DateNaissance = DateTime.Now,MoyenneGenerale = 14.5d,Nom = "nom_4",Prenom = "prenom_4"}
            };
        }
    }
}