using Fansoft.Store.IoCDI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;

namespace Fansoft.Store.UI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.SetupServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
           /* app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/node_modulos",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")) 

            });*/
            app.UseRouting();

            app.Use(async(ctx,next)=> {
                //ida
                //if (ctx.Request.Headers["language"] == "pt-BR") {
                if (true) { 
                    var cultureInfo = new CultureInfo("pt-BR");
                    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
                }
                await next();
                //volta
            });

            app.UseEndpoints(endpoints =>
            {
                //AddEdit/x -> Editar
                endpoints.MapControllerRoute("Edit", "{controller}/Editar/{id}", new { action = "AddEdit" } );

                //AddEdit - > Adicionar
                endpoints.MapControllerRoute("Add", "{controller}/Adicionar", new { action = "AddEdit" } );


                // {controller=home}/{action=index}/id?
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
