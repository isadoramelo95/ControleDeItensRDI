using Domain.Models;
using Domain.ResourceTeste;

namespace Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<Usuario> GetUsusarioAsync(LoginResource resource, CancellationToken cancellationToken);
    }
}
