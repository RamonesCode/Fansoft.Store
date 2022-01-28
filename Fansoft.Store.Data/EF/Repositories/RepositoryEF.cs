using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly StoreDbContext _ctx;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryEF(StoreDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

    
        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
          
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
           
        }

       

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
           
        }

	}
}
