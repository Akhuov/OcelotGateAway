using WepApi_1.Domain.Entities;
//Get,Create,update,
namespace WepApi_1.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository 
    {
        public ValueTask<string> Create(Employee employee);
        public ValueTask<string> Update(int id,Employee employee);
        public ValueTask<List<Employee>> GetAll();
        public ValueTask<string> Delete(int id);

        public ValueTask<Employee> GetById(int id);
    }
}
