using WepApi_1.Domain.Entities;
//Get,Create,update,
namespace WepApi_1.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public ValueTask<Employee> Create(Employee employee);
        public ValueTask<Employee> Update(int id,Employee employee);
        public ValueTask<List<Employee>> GetAll();
    }
}
