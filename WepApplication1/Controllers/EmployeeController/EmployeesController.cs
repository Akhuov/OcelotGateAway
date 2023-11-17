using Microsoft.AspNetCore.Mvc;
using WepApi_1.Service.Dtos;
using WepApi_1.Service.Services.EmployeeServices;

namespace WepApplication1.Controllers.EmployeeController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(EmployeeDto employeeDto)
        {
            var res = _employeeService.CreateAsync(employeeDto);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = _employeeService.GetAll();
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(int id, EmployeeDto employeeDto)
        {
            var res = await _employeeService.UpdateAsync(id, employeeDto);
            return Ok(res);
        }
    }
}
