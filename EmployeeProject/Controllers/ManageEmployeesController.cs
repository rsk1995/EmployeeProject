using EmployeeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManageEmployeesController : ControllerBase
    {
        public readonly EmpDBContext EmpDbContext;

        public ManageEmployeesController(EmpDBContext dbContext)
        {
            EmpDbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AllEmployees()
        {
            return Ok(EmpDbContext.Employee.ToList());
        }

        [HttpGet]
        public IActionResult GetEmployeeByID(int EmpId)
        {
            var emp = EmpDbContext.Employee.FirstOrDefault(x => x.EmpID == EmpId);
            if (emp == null)
            {
                return NotFound("Employee not found for Employee ID: " + EmpId);
            }
            else
            {
                return Ok(emp);
            }
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmpDTO empDTO)
        {
            var exemp = EmpDbContext.Employee.FirstOrDefault(x=>x.Email==empDTO.Email);
            if (exemp == null)
            {
                EmpDbContext.Employee.Add(new Employee
                {
                    FirstName = empDTO.FirstName,
                    LastName = empDTO.LastName,
                    Project = empDTO.Project,
                    Designation = empDTO.Designation,
                    Email = empDTO.Email
                });
                EmpDbContext.SaveChanges();
                return Ok("Emplyee added successfully!");
            }
            else
            {
                return BadRequest("Employee already added!");
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int EmpId)
        {
            var exemp = EmpDbContext.Employee.FirstOrDefault(x => x.EmpID == EmpId);
            if (exemp == null)
            {
                return NotFound("Employee not found!");
            }
            else
            {
                EmpDbContext.Employee.Remove(exemp);
                EmpDbContext.SaveChanges();
                return Ok("Employee Deleted successfully!\n" + exemp);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployeeDetails(int EmpID, [FromBody] EmpDTO empDTO)
        {
            var exemp = EmpDbContext.Employee.Find(EmpID);
            if (exemp == null)
            {
                return NotFound("Employee not found!");
            }
            else
            {
                exemp.FirstName = empDTO.FirstName;
                exemp.LastName = empDTO.LastName;
                exemp.Project = empDTO.Project;
                exemp.Designation = empDTO.Designation;
                exemp.Email = empDTO.Email;

                EmpDbContext.SaveChanges();
                return Ok("Employee information updated successfully!");
            }
        }
    }
}
