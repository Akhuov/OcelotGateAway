using WepApi_2.DataAccess.Repositories.PersonsRepository;
using WepApi_2.Domain.Entities;
using WepApi_2.Service.Dtos;

namespace WepApi_2.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async ValueTask<string> CreateAsync(PersonDto personDto)
        {
            try
            {
                var newPer = new Person()
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                };

                var res = await _personRepository.Create(newPer);
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Person>> GetAll()
        {
            try
            {
                var res = await _personRepository.GetAll();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateAsync(int id, PersonDto personDto)
        {
            try
            {
                var emp = new Person()
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                };
                var res = await _personRepository.Update(id, emp);

                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
