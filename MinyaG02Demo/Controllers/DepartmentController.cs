using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using MinyaG02Demo.DTOs;
using MinyaG02Demo.Entity;
using MinyaG02Demo.Models;

namespace MinyaG02Demo.Controllers
{
    [Route("api/[controller]")]//Domain/api/Department + Verb
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        CompanyContext db;
        public DepartmentController(CompanyContext _db)
        {
            db = _db;
        }
        //getAll
        //public ActionResult<List<Department>> GetAllDepts()
        //{
        //    return db.Departments.ToList();
        //}
        [HttpGet]//URL=> Domain /api/Department ===> Get
        public IActionResult GetAll()
        {
            List<Department> depts = db.Departments.ToList();
            if (depts.Count > 0)
            {
                return Ok(depts);
            }
            else
            {
                return BadRequest();
            }
        }
        //getById
        [HttpGet("{id:int}",Name ="GetOne")]//Domian/api/Department/1 + Get
        public IActionResult GetById(int id)
        {
            //Department d = db.Departments.Find(id);
            //return Ok(d);
            Department d = db.Departments.Include(e=>e.Employees).FirstOrDefault(d=>d.Id == id);
            DeptwithEmps deptDto = new DeptwithEmps();
            
            if(d!= null)
            {
                deptDto.DepartmentName = d.Name;
                foreach(var e in d.Employees)
                {
                    deptDto.EmpNames.Add(e.Name);
                }
                return Ok(deptDto);
            }
            return BadRequest();
        }
        //[HttpGet("getbyname/{name}")]//Domain/api/department/sd
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            Department d = db.Departments.FirstOrDefault(x => x.Name == name);
            return Ok(d);
        }
        //Upadate
        [HttpPut]
        public IActionResult Edit(/*int id,*/Department Newd)
        {
            //Department Olddept = db.Departments.Find(id);
            //Olddept.Name = Newd.Name;
            //Olddept.MGRName = Newd.MGRName;
            db.Update(Newd);
            db.SaveChanges();
            return Ok(db.Departments.ToList());
        }
        //Add
        [HttpPost]
        public IActionResult Add(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Add(d);
                db.SaveChanges();
                string url = Url.Link("GetOne", new { id = d.Id });

                return Created(url, new {message="Department Added Successfully ",Department =d});
               // return Ok(db.Departments.ToList());//return Created
            }
            return BadRequest(ModelState);    
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department d = db.Departments.Find(id);
            db.Remove(d);
            
            db.SaveChanges();
            return NoContent();
           // return StatusCode(204)

        }
    }
}
