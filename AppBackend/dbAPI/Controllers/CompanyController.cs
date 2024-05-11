using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using dbAPI.database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.Entities;

namespace dbAPI.Controllers;

[ApiController]
[Route("/api/companies")]
public class CompanyController : ControllerBase
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
    public CompanyController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public class Companydtg
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateCompany(Companydtg s)
    {
        var companies = await _dbContext.Companii.ToListAsync();
        if (companies.Aggregate(false, (acc, el) => acc || el.name == s.name))
        {
            return BadRequest("username already in use");
        }
        
        
        s.password = ComputeSHA256(s.password);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Companydtg, Company>());
        var mapper = new Mapper(config);
        
        var entry= await _dbContext.Companii.AddAsync(mapper.Map<Company>(s));
        await _dbContext.SaveChangesAsync();
        return Ok(entry.Entity);
    }
    [HttpGet]
    public async Task<ActionResult<List<Company>>> GetCompanies()
    {
       
        var companies = await _dbContext.Companii.ToListAsync();
        return Ok(companies);
       
    }
}