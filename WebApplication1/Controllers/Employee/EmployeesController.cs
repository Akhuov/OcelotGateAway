using Microsoft.AspNetCore.Mvc;
using WepApi_1.Service.Dtos;
using WepApi_1.Service.Services.EmployeeServices;

namespace WebApplication1.Controllers.Employee
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

        [HttpGet]
        public async ValueTask<IActionResult> GetAllEmployeesAsync()
        {
            var res = await _employeeService.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var res = await _employeeService.CreateAsync(employeeDto);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var res = _employeeService.UpdateAsync(id, employeeDto);
            return Ok(res);
        }
    }
}
