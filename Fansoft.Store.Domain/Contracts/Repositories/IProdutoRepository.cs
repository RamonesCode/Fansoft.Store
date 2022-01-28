using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto GetByNome(string nome);

        IEnumerable<Produto> GetAllWithCategorias();

        Task<IEnumerable<Produto>> GetAllWithCategoriasAsync();
    }
}
