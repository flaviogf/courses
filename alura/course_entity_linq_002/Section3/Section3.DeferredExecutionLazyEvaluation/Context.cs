using Microsoft.EntityFrameworkCore;

namespace Section3.DeferredExecutionLazyEvaluation
{
    public class Context : DbContext
    {
        public DbSet<Employe> Employes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section3\Section3.DeferredExecutionLazyEvaluation\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>()
                .ToTable("Funcionario");

            modelBuilder.Entity<Employe>()
                .Property(it => it.Id).HasColumnName("FuncionarioId");

            modelBuilder.Entity<Employe>()
                .Property(it => it.Name).HasColumnName("PrimeiroNome");

            modelBuilder.Entity<Employe>()
                .Property(it => it.Birthday).HasColumnName("DataNascimento");
        }
    }
}
