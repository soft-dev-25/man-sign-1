using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("postal")]
public class Postal
{
    [Column("postal_code")]
    public int PostalCode { get; set; }

    [Column("town_name")] 
    public string TownName { get; set; } = string.Empty;
}