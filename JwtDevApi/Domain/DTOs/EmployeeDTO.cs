namespace JwtDevApi.Domain.DTOs
{
    public class EmployeeDTO
    {
        // E quase a mesma coisa que Employee e usado só pra tranferir Dados entre camadas
        public int Id { get; set; }
        public string NameEmployeee { get; set; }
        public string? Photo { get; set; }

    }
}
