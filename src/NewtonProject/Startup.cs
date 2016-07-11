using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using NewtonProject.Models;
using NewtonProject.Repository;

namespace NewtonProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            //Definindo banco de dados
            var connection = @"Server=(localdb)\mssqllocaldb;Database=PortalDeAtividadesDB;Trusted_Connection=True;";
            services.AddDbContext<NewtonProjectContext>(options => options.UseSqlServer(connection));

            //Adicionando repositorios a injeção de dependencia.
            services.AddTransient<IRepository<Atividade>, AtividadeRepository>();
            services.AddTransient<IRepository<Cargo>, CargoRepository>();
            services.AddTransient<IRepository<Cliente>, ClienteRepository>();
            services.AddTransient<IRepository<Perfil>, PerfilRepository>();
            services.AddTransient<IRepository<Pessoa>, PessoaRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseCors(builder =>
                        builder.WithOrigins("http://localhost:55706").AllowAnyHeader());

            app.UseMvc();
        }
    }
}
