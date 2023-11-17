using WepApi_1.Domain.Entities;
using WepApi_1.Service.Dtos;

namespace WepApi_1.Service.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public ValueTask<string> CreateAsync(EmployeeDto employeeDto);
        public ValueTask<string> UpdateAsync(int id,EmployeeDto employeeDto);
        public ValueTask<List<Employee>> GetAll();
    }
}
