namespace JwtDevApi.Model
{
    public interface IEmployeeRepository
    {
        //Vai ter metodos ADICIONAR 
        void Add(Employee employee);
        
        //Vai ter metodos LISTAR

        List<Employee> GET(int pageNumber, int pageQuantity);
       
        //Vai ter metodos LISTAR por ID 

        Employee? GET(int id);

    }
}
