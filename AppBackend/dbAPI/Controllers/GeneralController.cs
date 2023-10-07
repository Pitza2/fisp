using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.database;
using testData.Entities;

namespace dbAPI.Controllers;
[ApiController]
[Route("/api/general")]
public class GeneralController : ControllerBase
{
    private readonly testDbContext _dbContext;
    public GeneralController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }
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
    
    [HttpPost]
    public async Task<ActionResult<General>> trylogin( [FromBody] login l)
    {
        Console.WriteLine(CompanyController.SecretHasher.Hash(l.password));
        General g = new General();
        Company? c = await _dbContext.Companii.FirstOrDefaultAsync(x => x.name == l.username);
        if (c != null)
        {
            if(ComputeSHA256(l.password)!=c.password){return NotFound();}
            g.username = l.username;
            g.extra = c.phone;
            g.isApplicant = false;
            g.id = c.id;
            return Ok(g);
        }

        Applicant? a = await _dbContext.Applicants.FirstOrDefaultAsync(x => x.name == l.username);
        if (a != null)
        {
            if(ComputeSHA256(l.password)!=a.password){return NotFound();}
            g.username = l.username;
            g.extra = a.linkedin;
            g.isApplicant = true;
            g.id = a.id;
            return Ok(g);
        }

        return NotFound();
    }
}