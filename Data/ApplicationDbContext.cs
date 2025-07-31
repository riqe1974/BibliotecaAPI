using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasMany(g => g.Livros)
                      .WithOne(l => l.Genero)
                      .HasForeignKey(l => l.GeneroId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasMany(a => a.Livros)
                      .WithOne(l => l.Autor)
                      .HasForeignKey(l => l.AutorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasOne(l => l.Genero)
                      .WithMany(g => g.Livros)
                      .HasForeignKey(l => l.GeneroId);

                entity.HasOne(l => l.Autor)
                      .WithMany(a => a.Livros)
                      .HasForeignKey(l => l.AutorId);
            });
        }
    }
}
