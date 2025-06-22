namespace Domain.Interface;

public interface IUsuarioRepository
{
    Task<int> RecuperarUsuariosPorIdAsync(int id);
}