using System.Threading.Tasks;

namespace Fansoft.Store.Domain.Contracts.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();

        void RollBack();
    }
}
