using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models;

[Table("postal")]
public class Postal
{

    [Column("postal_code")]
    [Key]
    public string PostalCode { get; set; }

    [Column("town_name")] 
    public string TownName { get; set; } = string.Empty;
}