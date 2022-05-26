using simple_crud.Models;

namespace simple_crud.Interfaces
{
    public interface IEtudiantService
    {
        Task<IEnumerable<Etudiant>> GetAll();
        Task<Etudiant> GetById(int idEtudiant);
        Task Update(Etudiant etudiant);
        Task Delete(int idEtudiant);
        Task<bool> Exists(int idEtudiant);
    }
}