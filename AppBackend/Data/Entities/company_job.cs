using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testData.Entities;

public class company_job
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string jobDescription { get; set; }
    public string jobTitle { get; set; }
    
    public int companyRefid { get; set; }
    [ForeignKey("companyRefid")]
    public Company company { get; set; }
}