using JwtDevApi.Model;

namespace JwtDevApi.Infraestrutura
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context;

        public EmployeeRepository(ConnectionContext context)
        {
            _context = context;
        }
        //private readonly ConnectionContext context = new ConnectionContext();
        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GET()
        {
            throw new NotImplementedException();
        }
    }
}
