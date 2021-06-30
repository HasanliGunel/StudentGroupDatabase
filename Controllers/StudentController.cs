using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGroupDatabase.Database;
using StudentGroupDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly GroupDatabase _context;
        public StudentController (GroupDatabase context)
        {
            _context = context;
        }
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var data = _context.Students.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create (StudentVm viewModel)
        {
            var data = new Student();
            data.Name = viewModel.Name;
            data.Surname = viewModel.Surname;
            _context.Students.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [HttpPut]
        public IActionResult Update(Student model)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("Deleted");
        }
        [Route ("id")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            return Ok(data);
        }
    }
}
