using ASP.NET6_API.Models;
using ASP.NET6_API.Service;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = _clienteService.AdicionarCliente(cliente);
            return Ok(retorno);
        }

        [HttpGet]
        public IEnumerable<Cliente> RecuperarClientes()
        {
            return _clienteService.RecuperarClientes();
        }

        [HttpGet("{email}")]
        public IActionResult RecuperarClientePorEmail(string email)
        {
            var cliente = _clienteService.RecuperarClientePorEmail(email);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] Cliente clienteNovo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool clienteAtualizado = _clienteService.AtualizarCliente(id, clienteNovo);
            if (clienteAtualizado)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{email}")]
        public IActionResult DeletarCliente(string email)
        {
            bool clienteExcluido = _clienteService.DeletarCliente(email);

            if (clienteExcluido)
                return NoContent();

            return NotFound();
        }
    }
}
