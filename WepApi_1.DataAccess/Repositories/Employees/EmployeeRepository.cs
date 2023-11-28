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

        public async ValueTask<string> Create(Employee employee)
        {
            try
            {
                await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
                return "Created";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<string> Delete(int id)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);
                if (res != null)
                {
                    _appDbContext.Employees.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "Employee Deleted from Base";
                }
                else
                {
                    return "Employee not found!";
                }

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
                var res = await _appDbContext.Employees.AsNoTracking().ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async ValueTask<Employee> GetById(int id)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> Update(int id,Employee employee)
        {
            try
            {
                var emp = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
                if (emp !=null) 
                { 
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    await _appDbContext.SaveChangesAsync();
                    return "Updated";
                }
                return "Employee Not Found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
