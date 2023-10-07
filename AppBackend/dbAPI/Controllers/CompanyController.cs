using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.database;
using testData.Entities;

namespace dbAPI.Controllers;

[ApiController]
[Route("/api/companies")]
public class CompanyController : ControllerBase
{
     public static class SecretHasher
    {
        private const int _saltSize = 16; // 128 bits
        private const int _keySize = 32; // 256 bits
        private const int _iterations = 100000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';

        public static string Hash(string input)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }

        public static bool Verify(string input, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
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
    public async Task<IActionResult> CreateCompany(Companydtg s)
    {
        var companies = await _dbContext.Companii.ToListAsync();
        if (companies.Aggregate(false, (acc, el) => acc || el.name == s.name))
        {
            return BadRequest("username already in use");
        }
        
        
        s.password = SecretHasher.Hash(s.password);
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