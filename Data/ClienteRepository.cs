using ASP.NET6_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET6_API.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> opt) : base(opt)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
