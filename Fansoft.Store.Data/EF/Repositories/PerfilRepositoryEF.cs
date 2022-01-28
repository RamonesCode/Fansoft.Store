using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class PerfilRepositoryEF : RepositoryEF<Perfil>, IPerfilRepository
    {
        public PerfilRepositoryEF(StoreDbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Perfil> GetAllWithUsuarios()
        {
            return _dbSet.Include(x => x.Usuarios).ToList();
        }

		public IEnumerable<Perfil> GetByIds(IEnumerable<int> ids)
		{
            return _dbSet.Where(x => ids.Contains(x.Id)).ToList();
		}

		public async Task<IEnumerable<Perfil>> GetByIdsAsync(IEnumerable<int> ids)
		{
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
	}
}
