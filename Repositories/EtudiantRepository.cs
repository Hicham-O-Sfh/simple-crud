using Microsoft.EntityFrameworkCore;
using simple_crud.Data;
using simple_crud.Interfaces;
using simple_crud.Models;

namespace simple_crud.Repositories
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly DataContext _dataContext;
        public EtudiantRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(Etudiant etudiant)
        {
            await this._dataContext.Etudiants.AddAsync(etudiant);
            await this._dataContext.SaveChangesAsync();
        }

        public async Task Delete(Etudiant etudiant)
        {
            this._dataContext.Etudiants.Remove(etudiant);
            await this._dataContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int idEtudiant)
        {
            return await this._dataContext.Etudiants.AnyAsync(e => e.Id == idEtudiant);
        }

        public async Task<IEnumerable<Etudiant>?> GetAll()
        {
            return await this._dataContext.Etudiants.ToListAsync();
        }

        public async Task<Etudiant?> GetById(int idEtudiant)
        {
            return await this._dataContext.Etudiants.FirstOrDefaultAsync(etud => etud.Id == idEtudiant);
        }

        public async Task Include(Etudiant etudiant)
        {
            etudiant.IsExclut = false;
            this._dataContext.Entry(etudiant).State = EntityState.Modified;
            await this._dataContext.SaveChangesAsync();
        }

        public async Task Exclude(Etudiant etudiant)
        {
            etudiant.IsExclut = true;
            this._dataContext.Entry(etudiant).State = EntityState.Modified;
            await this._dataContext.SaveChangesAsync();
        }

        public async Task Update(Etudiant etudiant)
        {
            this._dataContext.Entry(etudiant).State = EntityState.Modified;
            await this._dataContext.SaveChangesAsync();
        }
    }
}