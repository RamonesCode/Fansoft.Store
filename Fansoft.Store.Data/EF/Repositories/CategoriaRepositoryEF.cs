using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class CategoriaRepositoryEF : RepositoryEF<Categoria>, ICategoriaRepository
    {
        public CategoriaRepositoryEF(StoreDbContext ctx) : base(ctx)
        {
        }

		public async Task<int> CountProdsAsync(int categoriaId)
		{
			return (await _dbSet.Include(x => x.Produtos)
				.FirstOrDefaultAsync(x => x.Id == categoriaId)).Produtos
				.Count();

			//return await _dbSet.Include(x => x.Produtos)
			//	.Where(x => x.Id == categoriaId)
			//	.Select(x => x.Produtos)
			//	.CountAsync();


		}

		public async Task<IEnumerable<Categoria>> GetAllWithProdutosAsync()
		{
			return await _dbSet.Include(x => x.Produtos).ToListAsync();
		}
	}
}
