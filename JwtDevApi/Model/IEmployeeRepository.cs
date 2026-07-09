namespace JwtDevApi.Model
{
    public interface IEmployeeRepository
    {
        //Vai ter doIS metodos ADICIONAR E LISTAR 
        void Add(Employee employee);

        List<Employee>GET();
    }
}
