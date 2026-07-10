using JwtDevApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtDevApi.Services
{
    public class TokenServices
    {
        //Classe para gerar o token JWT
        public static object GenerateToken(Employee employee)
        {
            // configuaração do token 1º passo: criar a chave de segurança
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            // configuaração do token 2º passo: configurar o token 
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                  // 1ª configuaração salva o id do employee  

                    new Claim("employeeId", employee.id.ToString()),
                }),
                // 2ª configuaração define a expiração do token
                Expires = DateTime.UtcNow.AddHours(3),
                // 3ª configuaração define as credenciais de assinatura
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // Gerar o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            // Daqui retorna pra tela
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                Token = tokenString,
            };
        }
    }
}
