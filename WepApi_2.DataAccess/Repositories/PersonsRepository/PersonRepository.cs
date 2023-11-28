using Microsoft.EntityFrameworkCore;
using WepApi_2.DataAccess.DataAccess;
using WepApi_2.Domain.Entities;

namespace WepApi_2.DataAccess.Repositories.PersonsRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;
        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async ValueTask<string> Create(Person person)
        {
            try
            {
                await _appDbContext.People.AddAsync(person);
                await _appDbContext.SaveChangesAsync();
                return "Person Created";
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
                var res = await _appDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _appDbContext.People.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "Person Deleted";
                }
                else
                {
                    return "Person Not Found";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Person>> GetAll()
        {
            try
            {
                var res = await _appDbContext.People.ToListAsync();
                return res;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Person> GetById(int id)
        {
            try
            {
                var res = await _appDbContext.People.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (res!=null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> Update(int id, Person employee)
        {
            try
            {
                var res = await _appDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.FirstName = employee.FirstName;
                    res.LastName = employee.LastName;

                    await _appDbContext.SaveChangesAsync();
                    return "Person Updated";
                }
                else 
                {
                    return "Person not Found"; 
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
