using JwtDevApi.Domain.DTOs;
using JwtDevApi.Domain.Model;

namespace JwtDevApi.Infraestrutura.Repositories
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
        public List<EmployeeDTO> GET(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b =>
                new EmployeeDTO()
                {
                    Id = b.id,
                    NameEmployeee = b.name,
                    Photo = b.photo
                }).ToList();            
        }

        public Employee? GET(int id)
        {
            return _context.Employees.Find(id);
        }

       
    }
}
