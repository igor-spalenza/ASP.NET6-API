using ASP.NET6_API.Models;

namespace ASP.NET6_API.Service
{
    public interface IClienteService
    {
        Cliente AdicionarCliente(Cliente cliente);
        IEnumerable<Cliente> RecuperarClientes();
        Cliente RecuperarClientePorEmail(string email);
        bool AtualizarCliente(int id, Cliente clienteNovo);
        bool DeletarCliente(string email);
    }
}
