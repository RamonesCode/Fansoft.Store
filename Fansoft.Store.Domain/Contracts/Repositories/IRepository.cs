using Fansoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        //CRUD
        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(int id);
        TEntity Get(int id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
