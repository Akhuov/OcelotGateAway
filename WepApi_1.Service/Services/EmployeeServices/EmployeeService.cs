using WepApi_1.DataAccess.Repositories.Employees;
using WepApi_1.Domain.Entities;
using WepApi_1.Service.Dtos;
//Delete,Patch,GetbyId
namespace WepApi_1.Service.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async ValueTask<string> CreateAsync(EmployeeDto employeeDto)
        {
            try
            {
                var newEmp = new Employee()
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                };

                var res = await _employeeRepository.Create(newEmp);
                return res;
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        public async ValueTask<string> DeleteAsync(int id)
        {
            try
            {
                var res = await _employeeRepository.Delete(id);
                return res;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Employee>> GetAll()
        {
            try
            {
                var res = await _employeeRepository.GetAll();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async ValueTask<Employee> GetByIdAsync(int id)
        {
            try
            {
                var res = await _employeeRepository.GetById(id);
                return res;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateAsync(int id,EmployeeDto employeeDto)
        {
            try
            {
                var emp = new Employee()
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                };
                var res = await _employeeRepository.Update(id,emp);

                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
