using Api.Data;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Usuariocontext _context;

        public UsuarioRepository(Usuariocontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> BuscaUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public void DeletaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // Adicionando método para autenticação
        public async Task<Usuario> VerificarUsuario(string nome, string senha)
        {
            // Aqui, a senha deve ser verificada (em um caso real, você deve usar uma técnica de hash para comparar a senha)
            return await _context.Usuarios
                .Where(u => u.Nome == nome && u.Senha == senha) // Comparação simples de nome e senha
                .FirstOrDefaultAsync();
        }
    }
}
