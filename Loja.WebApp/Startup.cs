using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Loja.Application.Interfaces;
using Loja.Application.Services;
using Loja.Domain.Interfaces;
using Loja.Infrastructure.Repositories;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Loja.WebApp
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Obter a connection string da variável de ambiente
            string? connectionString = Configuration["CONNECTION_STRING_DB_LOJA"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'CONNECTION_STRING_DB_LOJA' not found.");
            }

            // Configurar o ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

            // Registrar serviços e repositórios
            services.AddScoped<ICompradorService, CompradorService>();
            services.AddScoped<ICompradorRepository, CompradorRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                // Configura o manipulador de exceções e HSTS para ambientes de produção
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                // Configura a página de detalhes de exceções para ambientes de desenvolvimento
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Compradores}/{action=Index}/{id?}");
            });
        }
    }
}