using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.database;
using testData.Entities;
using Microsoft.IdentityModel.Tokens;

namespace dbAPI.Controllers;
[ApiController]
[Route("/api/general")]
public class GeneralController : ControllerBase
{
    private readonly testDbContext _dbContext;
    private readonly IConfiguration _configuration;
    public GeneralController(testDbContext dbContext,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
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

    [HttpGet]
    public async Task<ActionResult<General>> GetUserData()
    {
        string jwtToken = HttpContext.Request.Headers.Authorization;
        jwtToken=jwtToken.Substring(7);//get rid of bearer
        var token = new JwtSecurityToken(jwtEncodedString:jwtToken);
        General g = new General();
        g.username = token.Claims.First(c => c.Type == "username").Value;
        g.extra = token.Claims.First(c => c.Type == "extra").Value;
        g.isApplicant = token.Claims.First(c => c.Type == "role").Value == "Applicant";
        g.id =int.Parse(token.Claims.First(c=>c.Type=="sid").Value);
        return Ok(g);

    }

    [HttpPost]
    public async Task<ActionResult<General>> trylogin( [FromBody] login l)
    {
        
        General g = new General();
        Company? c = await _dbContext.Companii.FirstOrDefaultAsync(x => x.name == l.username);
        if (c != null)
        {
            if(ComputeSHA256(l.password)!=c.password){return NotFound();}
            g.username = l.username;
            g.extra = c.phone;
            g.isApplicant = false;
            g.id = c.id;
            string token = CreateToken(g);
            return Ok(token);
        }

        Applicant? a = await _dbContext.Applicants.FirstOrDefaultAsync(x => x.name == l.username);
        if (a != null)
        {
            if(ComputeSHA256(l.password)!=a.password){return NotFound();}
            g.username = l.username;
            g.extra = a.linkedin;
            g.isApplicant = true;
            g.id = a.id;
            string token = CreateToken(g);
            return Ok(token);
        }

        return NotFound();
    }

    private string CreateToken(General g)
    {
        string role = g.isApplicant ? "Applicant" : "Company";
        List<Claim> claims = new List<Claim>()
        {

            new Claim("username", g.username),
            new Claim("extra", g.extra),
            new Claim("role", role),
            new Claim("sid", g.id.ToString())
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]!));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            issuer: _configuration["Appsettings:Issuer"],
            audience: _configuration["Appsettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
   
}