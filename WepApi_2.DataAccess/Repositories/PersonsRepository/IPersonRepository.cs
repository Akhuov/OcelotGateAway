using WepApi_2.Domain.Entities;

namespace WepApi_2.DataAccess.Repositories.PersonsRepository
{
    public interface IPersonRepository
    {
        public ValueTask<string> Create(Person employee);
        public ValueTask<string> Update(int id, Person employee);
        public ValueTask<List<Person>> GetAll();
        public ValueTask<string> Delete(int id);
        public ValueTask<Person> GetById(int id);
    }
}
