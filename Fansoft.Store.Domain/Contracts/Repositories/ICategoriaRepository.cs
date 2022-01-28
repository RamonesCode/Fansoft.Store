using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
	public interface ICategoriaRepository : IRepository<Categoria>
	{
		Task<int> CountProdsAsync(int categoriaId);

		Task<IEnumerable<Categoria>> GetAllWithProdutosAsync();

	}
}
