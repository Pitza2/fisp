using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using dbAPI.database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.Entities;

namespace dbAPI.Controllers;



[ApiController]
[Route("/api/jobs")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CompanyJobController : ControllerBase
{
    private readonly testDbContext _dbContext;

    public class jobdto
    {
        public string jobTitle { get; set; }
        public string jobDescription { get; set; }
        public int companyRefid { get; set; }
    }

    public class jobData
    {
        public string jobTitle { get; set; }
        public string jobDescription { get; set; }
    }

    public class jobCompany
    {
        public string jobTitle { get; set; }
        public string jobDescription { get; set; }
        public string companyName { get; set; }
        
        public int id { get; set; }
        public int companyRefid { get; set; }
    }
    public CompanyJobController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]

    public async Task<ActionResult<List<jobdto>>> getJobs()
    {
        var filteredList = await _dbContext.company_jobs.ToListAsync();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<company_job, jobdto>());
        var mapper =new Mapper(config);
        List<jobdto> jlist = new List<jobdto>();
        foreach (var job in filteredList)
        {
            jobdto j = mapper.Map<company_job,jobdto>(job);
            jlist.Add(j);
        }
        return Ok(jlist);
    }

    [HttpGet("id")]
    public async Task<ActionResult<jobCompany>> getById(int id)
    {
        var l = await _dbContext.company_jobs.Include(x=>x.company).FirstOrDefaultAsync(x => x.id == id);
        if (l == null)
            return NotFound();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<company_job, jobCompany>().
            ForMember(dest=>dest.companyName, 
                act=>act.MapFrom(src=>src.company.name)));
        var mapper = new Mapper(config);
        var fin = mapper.Map<jobCompany>(l);
        return Ok(fin);
    }
    [HttpGet("1")]
    public async Task<ActionResult<List<jobCompany>>> getJobsWCompanyName()
    {
        var fileredList = await _dbContext.company_jobs.Include(x => x.company).ToListAsync();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<company_job, jobCompany>().
            ForMember(dest=>dest.companyName, 
            act=>act.MapFrom(src=>src.company.name)));
        var mapper = new Mapper(config);
        List<jobCompany> lst = new List<jobCompany>();
        
        foreach (var chestie in fileredList)
        {
            jobCompany j = mapper.Map<jobCompany>(chestie);
            lst.Add(j);
        }
        return Ok(lst);

    }
    [HttpPost]
    public async Task<ActionResult> addJob(jobData jd)
    {
        jobdto j = new jobdto();
        j.jobDescription = jd.jobDescription;
        j.jobTitle = jd.jobTitle;
        string jwtToken = HttpContext.Request.Headers.Authorization;
        jwtToken=jwtToken.Substring(7);//get rid of bearer
        var token = new JwtSecurityToken(jwtEncodedString:jwtToken);
        var id = token.Claims.First(x => x.Type == "sid").Value;
        j.companyRefid = int.Parse(id);
        
        var config = new MapperConfiguration(cfg => cfg.CreateMap<jobdto, company_job>());
        var mapper =new Mapper(config);
        var job = mapper.Map<company_job>(j);
        await _dbContext.company_jobs.AddAsync(job);
        //var c = await _dbContext.Companii.FindAsync(job.companyRefid);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}