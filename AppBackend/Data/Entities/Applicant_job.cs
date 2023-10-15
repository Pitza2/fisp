using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testData.Entities;

public class Applicant_job
{
    public enum Status
    {  
        pending,
        accepted,
        rejected

    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }


    public Status status { get; set; } = Status.pending;
    public int company_jobRefid { get; set; }
    [ForeignKey("company_jobRefid")]
    public company_job CompanyJob { get; set; }
    
    
    public int applicantRefid { get; set; }
    [ForeignKey("applicantRefid")]
    public Applicant Applicant { get; set; }
}