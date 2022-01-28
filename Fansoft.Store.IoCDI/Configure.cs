using Fansoft.Store.Data.EF;
using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts.Data;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Fansoft.Store.IoCDI
{
    public static class Configure
    {
        public static void SetupServices(this IServiceCollection services)
        {
            services.AddScoped<StoreDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();

            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryEF>();
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryEF>();
            services.AddTransient<IPerfilRepository, PerfilRepositoryEF>();
        }
    }
}
