using dbAPI.database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.Entities;

namespace dbAPI.Controllers;
[ApiController]
[Route("/api/students")]
public class StudentController : ControllerBase
{
    private readonly testDbContext _dbContext;
    public StudentController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student s)
    {
        if (s.name.Length < 5)
        {
            return BadRequest("name is too short");
        }

        var entry= await _dbContext.Students.AddAsync(s);
        await _dbContext.SaveChangesAsync();
        return Ok(entry.Entity);
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _dbContext.Students.ToListAsync();
        return Ok(students);
    }
}