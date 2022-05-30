using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_crud.Interfaces;
using simple_crud.Models;

namespace simple_crud.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository _etudiantRepository;
        public EtudiantService(IEtudiantRepository etudiantRepository)
        {
            this._etudiantRepository = etudiantRepository;
        }

        public async Task Add(Etudiant etudiant)
        {
            await this._etudiantRepository.Add(etudiant);
        }

        public async Task Delete(int idEtudiant)
        {
            var etudiant = await this._etudiantRepository.GetById(idEtudiant);
            await this._etudiantRepository.Delete(etudiant!);
        }

        public async Task<bool> Exists(int idEtudiant)
        {
            return await this._etudiantRepository.Exists(idEtudiant);
        }

        public async Task<IEnumerable<Etudiant>?> GetAll()
        {
            return await this._etudiantRepository.GetAll();
        }

        public async Task<Etudiant?> GetById(int idEtudiant)
        {
            return await this._etudiantRepository.GetById(idEtudiant);
        }

        public async Task Include(Etudiant etudiant)
        {
            await this._etudiantRepository.Include(etudiant);
        }

        public async Task Exclude(Etudiant etudiant)
        {
            await this._etudiantRepository.Exclude(etudiant);
        }

        public async Task Update(Etudiant etudiant)
        {
            await this._etudiantRepository.Update(etudiant);
        }
    }
}