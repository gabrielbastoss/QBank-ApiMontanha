using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Usuariocontext : DbContext
    {
        public Usuariocontext(DbContextOptions<Usuariocontext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("tb_usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.Saldo).HasColumnName("saldo");
            usuario.Property(x => x.Senha).HasColumnName("senha");  // Adicionando a coluna para armazenar a senha
        }
    }
}
