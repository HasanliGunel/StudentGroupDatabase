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
    [Route ("[controller]")]
    public class StudentGroupController : ControllerBase
    {
        private readonly GroupDatabase _context;
        public StudentGroupController(GroupDatabase context)
        {
            _context = context;
        }
        [Route("GetAllStudent")]
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var data = _context.Students.ToList();
            return Ok(data);
        }
        [Route("GetAllGroup")]
        [HttpGet]
        public IActionResult GetAllGroup()
        {
            var data = _context.Groups.ToList();
            return Ok(data);
        }
        [Route("CreateStudent")]
        [HttpPost]
        public IActionResult Create(StudentVm viewModel)
        {
            var data = new Student();
            data.Name = viewModel.Name;
            data.Surname = viewModel.Surname;
            _context.Students.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [Route("CreateGroup")]
        [HttpPost]
        public IActionResult Create(GroupVm viewModel)
        {
            var data = new Group();
            data.Name = viewModel.Name;
            _context.Groups.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [Route("UpdateStudent")]
        [HttpPut]
        public IActionResult Update(Student model)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if(data==null)
            {
                return BadRequest("Bu id-li telebe yoxdur");
            }
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }
        [Route("UpdateGroup")]
        [HttpPut]
        public IActionResult Update(Group model)
        {
            var data = _context.Groups.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if(data==null)
            {
                return BadRequest("Bu id-li telebe yoxdur");
            }
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }
    }
}
