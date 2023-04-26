using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testData.Entities;

public class Companie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
}