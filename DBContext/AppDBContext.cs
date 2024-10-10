using api_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace api_tarefas.DBContext
{
    public class AppDBContext : DbContext
    {
        //Cria uma conexão com o banco de dados
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

        //referencia das classes models para as tabelas do banco de dados
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Tarefa> tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.usuario)//relação de apenas um usuário
                .WithMany(u => u.tarefas)//relação de varias tarefas por usuário
                .HasForeignKey(t => t.usuario)//condição de relação (chave estrangeira)
                .OnDelete(DeleteBehavior.Restrict);//condição de deletar usuários
            base.OnModelCreating(modelBuilder);
        }
    }
}
