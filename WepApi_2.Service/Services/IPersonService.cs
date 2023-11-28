using WepApi_2.Domain.Entities;
using WepApi_2.Service.Dtos;

namespace WepApi_2.Service.Services
{
    public interface IPersonService
    {
        public ValueTask<string> CreateAsync(PersonDto personDto);
        public ValueTask<string> UpdateAsync(int id, PersonDto personDto);
        public ValueTask<List<Person>> GetAll();
        public ValueTask<string> DeleteAsync(int id);
        public ValueTask<Person> GetByIdAsync(int id);
    }
}
