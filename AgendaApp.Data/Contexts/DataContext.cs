using AgendaApp.Data.Entities;
using AgendaApp.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Data.Contexts
{
    /// <summary>
    /// Classe para conexão e configuração do BD no EntityFramework
    /// </summary>
    public class DataContext: DbContext
    {
        /// <summary>
        /// Método para configurar a string de conexão do banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAgendaApp;Integrated Security=True;");
        }

        /// <summary>
        /// Método para adicionarmos as classes de mapeamento ORM do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
