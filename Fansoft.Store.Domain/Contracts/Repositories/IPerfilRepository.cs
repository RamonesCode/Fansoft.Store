using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Contracts.Repositories
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        IEnumerable<Perfil> GetAllWithUsuarios();
        IEnumerable<Perfil> GetByIds(IEnumerable<int> ids);

       Task< IEnumerable<Perfil>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
