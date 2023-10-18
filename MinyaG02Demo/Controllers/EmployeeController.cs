using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinyaG02Demo.DTOs;
using MinyaG02Demo.Entity;
using MinyaG02Demo.Models;

namespace MinyaG02Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        CompanyContext db;
        public EmployeeController(CompanyContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> emps = db.Employees.Include(e=>e.Department).ToList();
            return Ok(emps);
          //  return Ok(new {msg="All Employees",emps = emps});
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Employee emp = db.Employees.Include(e => e.Department).FirstOrDefault(e=>e.Id== id);
            EmpWithDept empDTO = new EmpWithDept();
            if(emp != null)
            {
                empDTO.Age = emp.Age;
                empDTO.EmpName = emp.Name;
                empDTO.EmpAddress = emp.Address;
                empDTO.DeptName = emp.Department.Name;
                return Ok(empDTO);
            }
            return BadRequest();
          
            //  return Ok(new {msg="All Employees",emps = emps});
        }
    }
}
