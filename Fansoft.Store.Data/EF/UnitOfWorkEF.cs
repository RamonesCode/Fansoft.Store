using System.Threading.Tasks;
using Fansoft.Store.Domain.Contracts.Data;

namespace Fansoft.Store.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly StoreDbContext _ctx;

        public UnitOfWorkEF(StoreDbContext ctx) => _ctx = ctx;

        public void Commit()
        {
            _ctx.SaveChanges();
        }

		public async Task CommitAsync()
		{
            await _ctx.SaveChangesAsync();
        }

		public void RollBack()
        {
            return;
        }
    }
}
