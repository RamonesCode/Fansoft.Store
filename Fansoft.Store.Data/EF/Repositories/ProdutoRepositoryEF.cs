using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDbContext ctx) : base(ctx){}

        public IEnumerable<Produto> GetAllWithCategorias()
        {
            return _dbSet.Include(x=>x.Categoria).ToList();
        }

		public async Task<IEnumerable<Produto>> GetAllWithCategoriasAsync()
		{
            return await _dbSet.Include(x => x.Categoria).ToListAsync();
        }

		public Produto GetByNome(string nome)
        {
            return _dbSet.FirstOrDefault(x=>x.Nome == nome);
        }
    }
}
