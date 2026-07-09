using JwtDevApi.Model;
using JwtDevApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JwtDevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, null);
            _employeeRepository.Add(employee);
            return Ok();
        }


        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.GET();
            return Ok(employess);
        }
    }
}
