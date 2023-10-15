using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testData.database;
using testData.Entities;

namespace dbAPI.Controllers;



[ApiController]
[Route("/api/jobs")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Company_jobController : ControllerBase
{
    private readonly testDbContext _dbContext;

    public class jobdto
    {
        public string jobTitle { get; set; }
        public string jobDescription { get; set; }
        public int companyRefid { get; set; }
    }

    public class jobCompany
    {
        public string jobTitle { get; set; }
        public string jobDescription { get; set; }
        public string companyName { get; set; }
        
        public int id { get; set; }
        public int companyRefid { get; set; }
    }
    public Company_jobController(testDbContext dbContext)
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
    public async Task<ActionResult> addJob(jobdto j)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<jobdto, company_job>());
        var mapper =new Mapper(config);
        var job = mapper.Map<company_job>(j);
        await _dbContext.company_jobs.AddAsync(job);
        //var c = await _dbContext.Companii.FindAsync(job.companyRefid);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}