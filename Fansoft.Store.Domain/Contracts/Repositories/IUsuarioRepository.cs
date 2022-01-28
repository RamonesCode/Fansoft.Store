using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByIdWithPerfis(int id);
       Task< Usuario> GetByIdWithPerfisAsync(int id);
        IEnumerable<Usuario> GetAllWithPerfis();

       Task<IEnumerable<Usuario>> GetAllWithPerfisAsync();
    }
}
