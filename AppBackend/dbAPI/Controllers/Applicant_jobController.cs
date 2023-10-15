﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using testData.database;
using testData.Entities;

namespace dbAPI.Controllers;

[ApiController]
[Route("/api/jobs/applicant")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Applicant_jobController : ControllerBase
{
    private readonly testDbContext _dbContext;
    public Applicant_jobController(testDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public class Applicant_jobdto
    {
        public int company_jobRefid { get; set; }
        public int applicantRefid { get; set; }
    }

    [HttpPost]
    public async Task<ActionResult> apply(Applicant_jobdto aj)
    {
        if (_dbContext.ApplicantJobs.ToList().Exists(x =>
                x.applicantRefid == aj.applicantRefid && x.company_jobRefid == aj.company_jobRefid))
        {
            return new BadRequestResult();
        }
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Applicant_jobController.Applicant_jobdto, Applicant_job>());
        var mapper = new Mapper(config);
        var job = mapper.Map<Applicant_job>(aj);
        await _dbContext.ApplicantJobs.AddAsync(job);
        //var c = await _dbContext.Companii.FindAsync(job.companyRefid);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}