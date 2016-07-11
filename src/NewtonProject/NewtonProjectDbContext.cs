using Microsoft.EntityFrameworkCore;
using NewtonProject.Models;

namespace NewtonProject
{

    /// <summary>
    /// Contexto de banco de dados da api
    /// </summary>
    public class NewtonProjectContext : DbContext
    {
        public NewtonProjectContext(DbContextOptions<NewtonProjectContext> options) : base(options)
        { }

        /// <summary>
        /// Pessoas no banco de dados
        /// </summary>
        public DbSet<Pessoa> Pessoas { get; set; }

        /// <summary>
        /// Atividades no banco de dados
        /// </summary>
        public DbSet<Atividade> Atividades { get; set; }

        /// <summary>
        /// Cardos no banco de dados
        /// </summary>
        public DbSet<Cargo> Cargos { get; set; }

        /// <summary>
        /// Clientes no banco de dados
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }

        /// <summary>
        /// Perfis no banco de dados
        /// </summary>
        public DbSet<Perfil> Perfis { get; set; }
    }
}
