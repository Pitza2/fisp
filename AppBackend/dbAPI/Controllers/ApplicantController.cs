using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.database;
using testData.Entities;

namespace dbAPI.Controllers;

[ApiController]
[Route("/api/applicants")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ApplicantController : ControllerBase
{
   

       
    static string ComputeSHA256(string s)
    {
        string hash = String.Empty;
 
        // Initialize a SHA256 hash object
        using (SHA256 sha256 = SHA256.Create())
        {
            // Compute the hash of the given string
            byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
 
            // Convert the byte array to string format
            foreach (byte b in hashValue) {
                hash += $"{b:X2}";
            }
        }
 
        return hash;
    }
    private readonly testDbContext _dbContext;
    public ApplicantController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplicant(Applicant s)
    {
        var applicants = await _dbContext.Applicants.ToListAsync();
        if (applicants.Aggregate(false, (acc, el) => acc || el.name == s.name))
        {
            return BadRequest("username already in use");
        }
        
        
        s.password = ComputeSHA256(s.password);
        var entry= await _dbContext.Applicants.AddAsync(s);
        await _dbContext.SaveChangesAsync();
        return Ok(entry.Entity);
    }
    [HttpGet]
   
    public async Task<ActionResult<List<Applicant>>> GetApplicants()
    {
       
        var applicants = await _dbContext.Applicants.ToListAsync();
        return Ok(applicants);
       
    }
}