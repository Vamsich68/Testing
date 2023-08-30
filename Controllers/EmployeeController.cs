using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Testing.DataBase;
using Testing.Models;

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = _context.Employees.ToList();
                if (employees.Count == 0)
                {
                    return NotFound("Not available");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id) 
        {

            try
            {
                var employee = _context.Employees.Find(id);
                if(employee == null)
                {
                    return NotFound("Not Found");  
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Ok("Object created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Data is invalid");
            }
            var emp = _context.Employees.Find(employee.EmployeeId);
            if (emp == null)
            {
                return NotFound("Not found");
            }
            try
            {
                emp.EmployeeDescription = employee.EmployeeDescription;
                emp.EmployeeName = employee.EmployeeName;
                emp.EmployeeAddress = employee.EmployeeAddress;
                emp.EmployeeAge = employee.EmployeeAge;
                emp.EmployeeDepartment = employee.EmployeeDepartment;
                emp.EmployeeDesignation = employee.EmployeeDesignation;
                _context.SaveChanges();
                return Ok("Details updated");
            }
            catch (Exception  ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IActionResult delete(string id)
        {
            try
            {
                var emp = _context.Employees.Find(id);
                if (emp == null)
                {
                    return NotFound("Not found");
                }
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return Ok("deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
