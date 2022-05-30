using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_crud.Models;

namespace simple_crud.Interfaces
{
    public interface IEtudiantRepository
    {
        Task<IEnumerable<Etudiant>?> GetAll();
        Task<Etudiant?> GetById(int idEtudiant);
        Task Add(Etudiant etudiant);
        Task Update(Etudiant etudiant);
        Task Delete(Etudiant etudiant);
        Task Exclude(Etudiant etudiant);
        Task Include(Etudiant etudiant);
        Task<bool> Exists(int idEtudiant);
    }
}