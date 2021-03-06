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
    public class StudentGroupController : ControllerBase
    {
        private readonly GroupDatabase _context;
        public StudentGroupController(GroupDatabase context)
        {
            _context = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.StudentGroups.ToList();
            return Ok (data);
        }
        [HttpPost]
        public IActionResult Create(StudentGroupVm viewModel)
        {
            var data = new StudentGroup();
            data.StudentID = viewModel.StudentID;
            data.GroupID = viewModel.GroupID;
            _context.StudentGroups.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [HttpPut]
        public IActionResult Update(StudentGroup model)
        {
            var data = _context.StudentGroups.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.StudentGroups.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("Deleted");
        }
        [Route("id")]
        [HttpGet]
        public IActionResult GetbyID(int id)
        {
            var data = _context.StudentGroups.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            return Ok(data);
        }
    }
}
