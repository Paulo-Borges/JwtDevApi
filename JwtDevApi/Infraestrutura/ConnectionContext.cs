using JwtDevApi.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtDevApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options): base(options)
        {
            
        }
        //Nome da tabela  
        public DbSet<Employee> Employees { get; set; }
    }
}
