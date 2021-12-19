using ImageUploadProject.Business.Interfaces;
using ImageUploadProject.DataAccess.Interfaces;
using ImageUploadProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageUploadProject.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task AddAsync(TEntity entity)
        {
           await _genericDal.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
           await _genericDal.DeleteAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
           return await _genericDal.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _genericDal.GetAllAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
