using ASP.NET6_API.Data;
using ASP.NET6_API.Models;

namespace ASP.NET6_API.Service
{
    public class ClienteService : IClienteService
    {
        private ClienteContext _context;

        public ClienteService(ClienteContext context)
        {
            _context = context;
        }

        public Cliente AdicionarCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Cliente> RecuperarClientes()
        {
            return _context.Clientes;
        }

        public Cliente RecuperarClientePorEmail(string email)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Email == email);
        }

        public bool AtualizarCliente(int id, Cliente clienteNovo)
        {
            Cliente clienteAtual = _context.Clientes.Find(id);
            if (clienteAtual == null)
                return false;

            clienteAtual.Nome = clienteNovo.Nome;
            clienteAtual.Email = clienteNovo.Email;
            _context.SaveChanges();
            return true;
        }

        public bool DeletarCliente(string email)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Email == email);
            if (cliente == null)
                return false;

            _context.Remove(cliente);
            _context.SaveChanges();
            return true;
        }
    }
}
