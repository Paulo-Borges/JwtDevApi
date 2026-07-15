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
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        // pra usar com PAGINACAO
        public List<Employee> GET(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
             
        }

        public Employee? GET(int id)
        {
            return _context.Employees.Find(id);
        }

       
    }
}
