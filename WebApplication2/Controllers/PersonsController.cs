using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApi_2.Service.Dtos;
using WepApi_2.Service.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(PersonDto personDto)
        {
            var res = _personService.CreateAsync(personDto);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = _personService.GetAll();
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(int id, PersonDto personDto)
        {
            var res = await _personService.UpdateAsync(id, personDto);
            return Ok(res);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int id)
        {
            var res = await _personService.DeleteAsync(id);
            return Ok(res);
        }

        [HttpGet("GetById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _personService.GetByIdAsync(id);
            return Ok(res);
        }
    }
}
