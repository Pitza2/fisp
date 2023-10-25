using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testData.Entities;

public class Applicant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string name { get; set; }
    public string linkedin { get; set; }
    public string password { get; set; }

    public Applicant()
    {
        id = -1;
        name = "null";
        linkedin = "null";
        password = "null";
    }
}