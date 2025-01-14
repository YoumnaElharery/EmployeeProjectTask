using EmployeeProjectTask.DAL.Entities;
using EmployeeProjectTask.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProjectTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees() => Ok(_context.EmployeesInfos.ToList());

        [HttpGet("{id}")]
        public IActionResult GetEmployeeByID(int id) =>
            Ok(_context.EmployeesInfos.FirstOrDefault(e => e.Id == id));


        //[HttpGet("{name}")]
        //public IActionResult GetEmployeeByName(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //        return BadRequest("Name cannot be null or empty.");

        //    var employee = _context.EmployeesInfos.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        //    if (employee == null)
        //        return NotFound($"Employee with name '{name}' not found.");

        //    return Ok(employee);
        //}


        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            //Here We can Use a map function to auto map between API obj and DB
            new EmployeesInfo();
            _context.EmployeesInfos.Add(new EmployeesInfo() { 
                                        Department = employee.Department,
                                        Name = employee.Name,
                                        Salary = employee.Salary});


            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = employee.Id }, employee);
        }
       
    }
}
