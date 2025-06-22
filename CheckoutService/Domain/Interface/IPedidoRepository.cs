namespace Domain.Interface;

public interface IPedidoRepository
{
    Task<int> RecuperarPedidoPorIdAsync(int id);
}