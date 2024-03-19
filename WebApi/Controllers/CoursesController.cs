using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]

        public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (course != null)
            {
                return Ok(course);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne(CourseEntity model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Courses.Add(model);
                    await _context.SaveChangesAsync();

                    return Created("", model);
                }

                catch
                {
                    return Problem("Unable to create course.");
                }
            }

            return BadRequest();
        }

    }
}
