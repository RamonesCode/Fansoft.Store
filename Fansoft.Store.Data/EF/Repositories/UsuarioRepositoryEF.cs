using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(StoreDbContext ctx) : base(ctx)
        {
        }

		public IEnumerable<Usuario> GetAllWithPerfis()
		{
			return _dbSet.Include(x => x.Perfis).ToList();
		}

		public async Task<IEnumerable<Usuario>> GetAllWithPerfisAsync()
		{
			return await _dbSet.Include(x => x.Perfis).ToListAsync();
		}

		public Usuario GetByIdWithPerfis(int id)
		{
			return _dbSet.Include(x => x.Perfis).FirstOrDefault(x => x.Id == id);
		}

		public async Task<Usuario> GetByIdWithPerfisAsync(int id)
		{
			return await _dbSet.Include(x => x.Perfis).FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
