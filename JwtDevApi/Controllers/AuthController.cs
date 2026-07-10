using JwtDevApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtDevApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        // controller estatico não precisa ir ao banco pra autenticar  vai validar pelo proprio código 
        public IActionResult Auth(string username, string password)
        {
            if (username == "borges" && password == "123456")
            {
                var employee = new Model.Employee("Paulo Borges", 54, "admin");
                var token = TokenServices.GenerateToken(employee);
                return Ok(token);
            }
            return BadRequest("Usuário ou senha inválidos");

     }   }
}
