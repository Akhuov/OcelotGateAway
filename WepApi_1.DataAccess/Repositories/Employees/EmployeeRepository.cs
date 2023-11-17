using Microsoft.EntityFrameworkCore;
using WepApi_1.DataAccess.DataAccess;
using WepApi_1.Domain.Entities;

namespace WepApi_1.DataAccess.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask<Employee> Create(Employee employee)
        {
            try
            {
                await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
                return employee;
            }
            catch 
            {
                return null;
            }
        }

        public async ValueTask<List<Employee>> GetAll()
        {
            try
            {
                var res = await _appDbContext.Employees.AsNoTracking().ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async ValueTask<Employee> Update(int id,Employee employee)
        {
            try
            {
                var emp = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
                if (emp !=null) 
                { 
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    await _appDbContext.SaveChangesAsync();
                }
                return emp;
            }
            catch
            {
                return null;
            }
        }
    }
}
