using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {

        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var livro = modelBuilder.Entity<Livro>();
            livro.ToTable("tb_livros");
            livro.HasKey(x => x.Id);
            livro.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            livro.Property(x => x.DataPublicacao).HasColumnName("dt_publicacao");
            livro.Property(x => x.Nome).HasColumnName("nm_livro");
            livro.Property(x => x.NomeEscritor).HasColumnName("nm_escritor");
            livro.Property(x => x.Sinopse).HasColumnName("ds_sinopse");
        }
    }
}