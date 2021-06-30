using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGroupDatabase.Database;
using StudentGroupDatabase.Model;
using System.Linq;

namespace StudentGroupDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupDatabase _context;
        public GroupController(GroupDatabase context)
        {
            _context = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Groups.ToList();
            return Ok(data);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(GroupVm viewModel)
        {
            var data = new Group();
            data.Name = viewModel.Name;
            _context.Groups.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(Group model)
        {
            var data = _context.Groups.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Groups.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("bu id-li telebe yoxdur");
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("Deleted");
        }

        [Route("id")]
        [HttpGet]
        public IActionResult GetbyGroutId(int id)
        {
            var data = _context.Groups.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
                return BadRequest("Bu id-li telebe yoxdur");
            return Ok(data);

        }
    }
}
